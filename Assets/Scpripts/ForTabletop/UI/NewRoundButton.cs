using System;
using UnityEngine;

using UiButton = UnityEngine.UI.Button;
[RequireComponent(typeof(UiButton))]
public class NewRoundButton : MonoBehaviour
{
    [SerializeField] private UiButton button;
    void Awake()
    {
        button.onClick.AddListener(NewRound);
        Player.Rolled += Activate;
        Player.NewRoll += Deactivate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NewRound()
    {
        foreach(var dice in Player.Instance.Dices_)
        {
            Destroy(dice.gameObject);
        }
        Player.Instance.Dices_.Clear();
        Player.Instance.PlayerScore = 0;
        NewRoundEvent?.Invoke();
    }

    private void Deactivate()
    {
        button.interactable = false;
    }

    private void Activate()
    {
        button.interactable = true;
    }

    public static event Action NewRoundEvent;
}
