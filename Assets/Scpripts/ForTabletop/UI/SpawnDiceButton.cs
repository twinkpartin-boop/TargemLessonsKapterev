using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UiButton = UnityEngine.UI.Button;
[RequireComponent (typeof(UiButton))]
public class SpawnDiceButton : MonoBehaviour
{
    // Тут бы сериализованный словарь, но мне пока лень
    [SerializeField] private UiButton button;
    [SerializeField] private List<Dice> dicesPrefabs;
    [SerializeField] private TMP_Text diceName;
    [SerializeField] private float spawnDelay;
    [SerializeField] private WinCondtion condtion;
    private Coroutine spawnRoutine;
    private uint amountOfPowers;
    private Dictionary<uint, Dice> DicesByPower;
    private uint curPowerChosen;
    private uint amount;
    private int cursorPos; // от 1 до dicesPrefabs.Count

    public uint CurPowerChosen {  
        get { return curPowerChosen; } 
        set { if (DicesByPower.ContainsKey(value)) {
                curPowerChosen = value;
            }            
        }
    }
    public uint Amount { set { amount = value; }  }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (button == null) button = GetComponent<UiButton>();
        button.onClick.AddListener(SpawnDice);
        if (diceName == null) diceName = GetComponentInChildren<TMP_Text>();
        if (spawnDelay == default(float)) spawnDelay = 0.05f;
        curPowerChosen = 6;
        amount = 1;
        cursorPos = 2;
        diceName.text = "D6";
    }

    private void Start()
    {
        DicesByPower = new Dictionary<uint, Dice>();
        foreach (var dice in dicesPrefabs)
        {
            DicesByPower[dice.Power] = dice;
        }
        dicesPrefabs.OrderBy(dice => dice.Power).ToList();
        Player.NewRoll += Deactivate;
        Player.Rolled += Activate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnDice()
    {
        if (spawnRoutine != null) return; 
        spawnRoutine = StartCoroutine(SpawnDiceRoutine());
    }

    private IEnumerator SpawnDiceRoutine()
    {
        var prefab = DicesByPower[curPowerChosen];
        condtion.CountPossibles(curPowerChosen, amount);
        condtion.HideResult();
        var wait = new WaitForSeconds(spawnDelay);
        for (var i = 0; i < amount; i++)
        {
            Player.Instance.AddDice(Instantiate(prefab, Player.Instance.transform.position, prefab.transform.rotation));
            yield return wait;
        }
        spawnRoutine = null;
    }

    public void ChangeType(navType nav)
    {
        cursorPos += (int)nav;
        if (cursorPos <= 0) cursorPos = dicesPrefabs.Count;
        else if (cursorPos > dicesPrefabs.Count) cursorPos = 1;
        curPowerChosen = dicesPrefabs[cursorPos-1].Power;
        diceName.text = "D"+curPowerChosen.ToString();
    }

    private void Deactivate()
    {
        button.interactable = false;
    }
    private void Activate()
    {
        button.interactable = true;
    }
}
