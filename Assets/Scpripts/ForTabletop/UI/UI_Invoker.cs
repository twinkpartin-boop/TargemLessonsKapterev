using Unity.VisualScripting;
using UnityEngine;

public class UI_Invoker : MonoBehaviour
{
    [SerializeField] private Canvas UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instantiate(UI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
