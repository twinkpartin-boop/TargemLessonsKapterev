using UnityEngine;

using UiButton = UnityEngine.UI.Button;
[RequireComponent(typeof(UiButton))] 
public class NavArrow : MonoBehaviour
{
    [SerializeField] private SpawnDiceButton spawnButton;
    [SerializeField] private UiButton arrowButton;
    [SerializeField] private navType side;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (spawnButton == null) Debug.LogError("SerializeField for spawnButtom in navArrow is empty");
        if (side == default(navType)) side = navType.left;
        arrowButton.onClick.AddListener(Change);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Change()
    {
        spawnButton.ChangeType(side);
    }


}
