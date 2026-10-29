using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Scriptable Objects/PlayerData")]
public class EntityData : ScriptableObject
{
    [SerializeField] private float maxHp;
    [SerializeField] private float baseDamage;
    [SerializeField] private float baseSpeed;

    public float MaxHp { get => maxHp;}
    public float BaseDamage { get => baseDamage;}
    public float BaseSpeed { get => baseSpeed;}
}
