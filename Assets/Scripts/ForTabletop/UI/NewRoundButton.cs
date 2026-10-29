using System;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class NewRoundButton : MonoBehaviour
{

    [SerializeField] private Button button;
    private void Awake()
    {
        button.onClick.AddListener(NewRound);
        
    }

    private void OnEnable()
    {
        Player.Instance.Rolled += Activate;
        Player.Instance.NewRoll += Deactivate;
    }

    private void OnDisable()
    {
        Player.Instance.Rolled -= Activate;
        Player.Instance.NewRoll -= Deactivate;
    }

    private void NewRound()
    {
        foreach(var dice in Player.Instance.Dices_)
        {
            Destroy(dice.gameObject);
        }
        Player.Instance.Dices_.Clear();
        Player.Instance.PlayerScore = 0;
        UIEvents.RaiseNewRound();
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
