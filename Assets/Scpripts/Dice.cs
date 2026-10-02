using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Dice : MonoBehaviour
{
    [SerializeField] private float maxFy;
    [SerializeField] private float maxRx;
    [SerializeField] private float maxRy;
    [SerializeField] private float maxRz;
    [SerializeField] private uint power;
    private Score Tablescore;
    private uint Dicescore;
    private Rigidbody Rigidbody;
    private float mass;
    private List<Face> faces;

    public uint Power { 
        get { return power; }
    }

    public Score TableScore {
        get { return Tablescore; }
        set { Tablescore = value; }
    }

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        mass = Rigidbody.mass;
        if (Rigidbody == null )
        {
            Debug.LogError("Нет компонента Rigidbody", this);
        }   
        faces = new List<Face>(GetComponentsInChildren<Face>());
        foreach (var face in faces)
        {
            face.ParentDice = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Dicescore > 0 && Rigidbody.angularVelocity.sqrMagnitude < 0.001 && Rigidbody.linearVelocity.sqrMagnitude < 0.001)
        {
            Tablescore.UpdateScore(Tablescore.TableScore + Dicescore);
            Dicescore = 0;
        }
    }

    public void Roll()
    {
        Rigidbody.AddForce(new Vector3(Random.Range(1, mass * 10), Random.Range(mass * 10, maxFy * mass), Random.Range(1, mass * 10)), ForceMode.Force);
        Rigidbody.AddTorque(new Vector3(Random.Range(mass, maxRx * mass), Random.Range(mass, maxRy * mass), Random.Range(mass, maxRz * mass)), ForceMode.Force);
    }

    public void UpdateScore(uint value)
    {
        Dicescore = value;
        
    }
}
