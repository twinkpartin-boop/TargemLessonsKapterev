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
