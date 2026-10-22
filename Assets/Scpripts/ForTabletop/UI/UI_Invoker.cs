using Unity.VisualScripting;
using UnityEngine;

public class UI_Invoker : MonoBehaviour
{
    [SerializeField] private Canvas UI;
    private void Awake()
    {
        Instantiate(UI);
    }

}
