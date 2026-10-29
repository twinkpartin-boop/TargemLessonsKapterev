using UnityEngine;

[CreateAssetMenu(fileName = "ThrowPower", menuName = "Scriptable Objects/ThrowPower")]
public class ThrowPower : ScriptableObject
{
    [SerializeField] private float maxFy;
    [SerializeField] private float maxRx;
    [SerializeField] private float maxRy;
    [SerializeField] private float maxRz;

    public float MaxRz { get => maxRz; }
    public float MaxRy { get => maxRy; }
    public float MaxRx { get => maxRx; }
    public float MaxFy { get => maxFy; }
}
