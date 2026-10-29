using UnityEngine;
using TMPro;

[RequireComponent (typeof(TMP_InputField))]
public class DiceAmountInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private void Awake()
    {
        inputField.text = "1";
        inputField.onEndEdit.AddListener(ChangeAmount);
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
            UIEvents.RaiseChangeAmount(amount);
        }
        else { inputField.text = "неверный Ввод"; }
    }
}
