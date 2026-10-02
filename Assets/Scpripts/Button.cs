using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using System.Collections.Generic;
using System.Linq;

public class Button : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    private TMP_Text keyName;
    void Awake()
    {
        keyName = GetComponentsInChildren<TMP_Text>().FirstOrDefault(txt => txt.CompareTag("GameController"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rebind()
    {
        keyName.text = "<New key>";
        inputAction.action.Disable();
        InputSystem.onAnyButtonPress.CallOnce(control =>
        {
            var newPath = $"<Keyboard>/{control.name}";
            keyName.text = control.name;     
            inputAction.action.ApplyBindingOverride(0, newPath);
        });
        inputAction.action.Enable();
    }
}
