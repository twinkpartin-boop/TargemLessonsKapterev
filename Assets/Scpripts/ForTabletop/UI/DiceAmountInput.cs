using UnityEngine;
using TMPro;

[RequireComponent (typeof(TMP_InputField))]
public class DiceAmountInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private SpawnDiceButton spawnButton;
    void Awake()
    {
        inputField.text = "1";
        inputField.onEndEdit.AddListener(ChangeAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeAmount(string text)
    {
        uint amount;
        if (uint.TryParse(text, out amount))
        {
            if (amount > 10)
            {
                inputField.text = "10";
                amount = 10;
            }
            spawnButton.Amount = amount;
        }
        else { inputField.text = "неверный Ввод"; }

    }
}
