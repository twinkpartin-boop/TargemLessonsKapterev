using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private List<Dice> Dices;

    void Awake()
    {
        if (text == null)
        {
            text = GetComponent<TMP_Text>();
        }    
        text.text = "0";
        Player.NewRoll += UpdateScore;
        Player.Rolled += UpdateScore;
        NewRoundButton.NewRoundEvent += UpdateScore;
    }

    private void Start()
    {
        Dices = Player.Instance.Dices_;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        text.text = Player.Instance.PlayerScore.ToString();
    }


}
