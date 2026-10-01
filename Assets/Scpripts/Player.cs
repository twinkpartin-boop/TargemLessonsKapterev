using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Dice> Dices;
    void Awake()
    {
        Dices = new List<Dice>(FindObjectsByType<Dice>(FindObjectsSortMode.None));
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
    }
}
