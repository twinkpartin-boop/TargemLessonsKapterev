using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

using UiButton = UnityEngine.UI.Button; // Я случайно назвал кнопку ребинда именем класса для кнопки в юнити и теперь не знаю как переименовать, не удаляя файл скрипта и переписывая код. Потому использовал синоним
[RequireComponent(typeof(UiButton))]
public class Button : MonoBehaviour
{
    [SerializeField] private InputActionReference inputAction;
    [SerializeField] private TMP_Text keyname;
    [SerializeField] private UiButton button;
    void Awake()
    {
        if (keyname is null)
        {
            keyname = GetComponentsInChildren<TMP_Text>().FirstOrDefault(txt => txt.CompareTag("GameController"));
        }      
        if (inputAction is null)
        {
            Debug.LogError("Нет ссылки на действие");
        }
        button.onClick.AddListener(Rebind);
    }

    // Update is called once per frame
    void Update()
    {
        
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
