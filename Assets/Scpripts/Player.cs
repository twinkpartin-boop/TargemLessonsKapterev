using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Dice> Dices;
    private Score Tablescore;
    void Awake()
    {
        Dices = new List<Dice>(FindObjectsByType<Dice>(FindObjectsSortMode.None));
        Tablescore = FindAnyObjectByType<Score>();
        foreach (var dice in Dices)
        {
            dice.TableScore = Tablescore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRoll()
    {
        foreach (var dice in Dices)
        {
            dice.Roll();
        }
        Tablescore.UpdateScore(0);
    }
}
