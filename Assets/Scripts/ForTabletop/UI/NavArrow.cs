using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] 
public class NavArrow : MonoBehaviour
{
    [SerializeField] private Button arrowButton;
    [SerializeField] private navType side;

    private void Awake()
    {
        if (side == default(navType)) Debug.LogError("No navType in NavArrow");
        arrowButton.onClick.AddListener(Change);
    }

    private void Change()
    {
        UIEvents.RaiseTypeChanged(side);
    }


}
