using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Dice> Dices;
    private static Player instance;
    private uint diceRolled;
    private uint playerScore;

    public static Player Instance { get { return instance; } }
    public uint PlayerScore { get { return playerScore; } set { playerScore = value; } }
    public uint DiceRolled {  get { return diceRolled; } }
    public bool IsReadoToCount { get { return Dices.Count == diceRolled; } }
    void Awake()
    {
        playerScore = 0;
        if (Dices is null || Dices.Count == 0)
        {
            Dices = new List<Dice>(FindObjectsByType<Dice>(FindObjectsSortMode.None));
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnRoll() // От InputSystem
    {
        foreach (var dice in Dices)
        {
            dice.Roll();
        }
        instance.ReRoll();
    }

    public void AddRolled(uint scoreValue)
    {
        diceRolled += 1;
        playerScore += scoreValue;
    }

    public void ReRoll()
    {
        diceRolled = 0;
        playerScore = 0;
    }
}
