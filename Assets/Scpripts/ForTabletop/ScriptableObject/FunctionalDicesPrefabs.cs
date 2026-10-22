using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "FunctionalScripts", menuName = "Scriptable Objects/FunctionalScripts")]
public class FunctionalScripts : ScriptableObject
{
    [SerializeField] private List<Dice> prefabs;

    public List<Dice> Prefabs { get => prefabs;}
}
