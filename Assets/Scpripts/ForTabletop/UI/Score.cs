using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(TMP_Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        text.text = "0";
    }

    private void OnEnable()
    {
        ModelEvents.FinishRoll += UpdateScore;
        ModelEvents.NewRoll += UpdateScore;
        UIEvents.NewRound += UpdateScore;
    }

    private void OnDisable()
    {
        ModelEvents.FinishRoll -= UpdateScore;
        ModelEvents.NewRoll -= UpdateScore;
        UIEvents.NewRound -= UpdateScore;
    }

    public void UpdateScore()
    {
        text.text = Player.Instance.PlayerScore.ToString();
    }


}
