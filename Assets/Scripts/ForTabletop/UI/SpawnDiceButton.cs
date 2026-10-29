using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class SpawnDiceButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private FunctionalScripts prefabs;
    [SerializeField] private TMP_Text diceName;
    [SerializeField] private float spawnDelay;
    private Coroutine spawnRoutine;
    private Dictionary<uint, Dice> DicesByPower;
    private uint curPowerChosen;
    private uint amount;
    private int cursorPos; // from 1 to dicesPrefabs.Count

    public uint CurPowerChosen {  
        get { return curPowerChosen; } 
        set { if (DicesByPower.ContainsKey(value)) {
                curPowerChosen = value;
            }            
        }
    }
    public uint Amount { set { amount = value; }  }

    private void Awake()
    {
        button.onClick.AddListener(SpawnDice);
        if (diceName == null) Debug.LogError("Text not found on SpawnDiceButton");
        if (spawnDelay == default(float)) spawnDelay = 0.05f;
        if (prefabs == null) Debug.LogError("No prefabs of dices in SpawnDiceButton");
        curPowerChosen = 6;
        amount = 1;
        cursorPos = 2;
        diceName.text = "D6";
    }

    private void Start()
    {
        DicesByPower = new Dictionary<uint, Dice>();
        foreach (var dice in prefabs.Prefabs)
        {
            DicesByPower[dice.Power] = dice;
        }
        prefabs.Prefabs.OrderBy(dice => dice.Power).ToList();
        
    }

    private void OnEnable()
    {
        Player.Instance.NewRoll += Deactivate;
        Player.Instance.Rolled += Activate;
        UIEvents.ChangeAmount += ChangeAmount;
        UIEvents.TypeChanged += ChangeType;
    }

    private void OnDisable()
    {
        Player.Instance.NewRoll -= Deactivate;
        Player.Instance.Rolled -= Activate;
        UIEvents.ChangeAmount -= ChangeAmount;
        UIEvents.TypeChanged -= ChangeType;
    }


    private void SpawnDice()
    {
        if (spawnRoutine != null) return; 
        spawnRoutine = StartCoroutine(SpawnDiceRoutine());
    }

    private IEnumerator SpawnDiceRoutine()
    {
        var prefab = DicesByPower[curPowerChosen];
        UIEvents.RaiseDiceSpawn(curPowerChosen, amount);
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
        if (cursorPos <= 0) cursorPos = prefabs.Prefabs.Count;
        else if (cursorPos > prefabs.Prefabs.Count) cursorPos = 1;
        curPowerChosen = prefabs.Prefabs[cursorPos-1].Power;
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

    private void ChangeAmount(uint amount)
    {
        Amount = amount;
    }
}
