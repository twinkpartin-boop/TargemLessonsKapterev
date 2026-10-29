using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float id;
    [SerializeField] private float armor;
}
