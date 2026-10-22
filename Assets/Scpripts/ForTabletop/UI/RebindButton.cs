using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Button))]
public class RebindButton : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    [SerializeField] private TMP_Text keyname;
    [SerializeField] private Button button;
    private void Awake()
    {
        if (keyname is null)
        {
            Debug.LogError("Нет текста в RebindButton");
        }      
        if (inputAction is null)
        {
            Debug.LogError("Нет ссылки на действие в RebindButton");
        }
        button.onClick.AddListener(Rebind);
    }

    public void Rebind()
    {
        keyname.text = "<New key>";
        inputAction.action.Disable();
        InputSystem.onAnyButtonPress.CallOnce(control =>
        {
            var newPath = $"<Keyboard>/{control.name}";
            keyname.text = control.name;     
            inputAction.action.ApplyBindingOverride(0, newPath);
        });
        inputAction.action.Enable();
    }
}
