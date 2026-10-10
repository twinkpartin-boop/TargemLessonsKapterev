using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private List<Dice> Dices;

    void Awake()
    {
        if (text == null)
        {
            text = GetComponent<TMP_Text>();
        }    
        if (Dices == null || Dices.Count == 0)
        {
            Dices = new List<Dice>(FindObjectsByType<Dice>(FindObjectsSortMode.None));
        }
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.IsReadoToCount || Player.Instance.DiceRolled == 0)
        {
            UpdateScore(Player.Instance.PlayerScore);
        }
    }

    public void UpdateScore(uint newScore)
    {
        text.text = newScore.ToString();
    }


}
