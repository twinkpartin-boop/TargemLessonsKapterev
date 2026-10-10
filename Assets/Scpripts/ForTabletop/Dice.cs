using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] private float maxFy;
    [SerializeField] private float maxRx;
    [SerializeField] private float maxRy;
    [SerializeField] private float maxRz;
    [SerializeField] private uint power;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private List<Face> faces;
    [SerializeField] private float checkInterval;
    private Score Tablescore;
    private uint Dicescore;
    private bool isRolled;
    private float mass;
    private Coroutine _waitRoutine;

    public uint Power { 
        get { return power; }
    }

    public Score TableScore {
        get { return Tablescore; }
        set { Tablescore = value; }
    }

    public bool IsRolled { get => isRolled; }

    void Awake()
    {        
        if (Rigidbody == null )
        {
            Rigidbody = GetComponent<Rigidbody>();
        }   
        if (faces.Count < power)
        {
            faces = new List<Face>(GetComponentsInChildren<Face>());
        }
        foreach (var face in faces)
        {
            face.ParentDice = this;
        }
        if (checkInterval == default(float)) checkInterval = 0.1f;
        isRolled = false;
        mass = Rigidbody.mass;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Roll()
    {
        Rigidbody.AddForce(new Vector3(Random.Range(1, mass * 10), Random.Range(mass * 10, maxFy * mass), Random.Range(1, mass * 10)), ForceMode.Force);
        Rigidbody.AddTorque(new Vector3(Random.Range(mass, maxRx * mass), Random.Range(mass, maxRy * mass), Random.Range(mass, maxRz * mass)), ForceMode.Force);


        if (_waitRoutine != null) StopCoroutine(_waitRoutine);
        _waitRoutine = StartCoroutine(WaitForStop());
    }

    private IEnumerator WaitForStop()
    {
        yield return new WaitForSeconds(0.3f);

        var wait = new WaitForSeconds(checkInterval);
        while (!Rigidbody.IsSleeping())
            yield return wait;

        Player.Instance.AddRolled(Dicescore);
        _waitRoutine = null;
    }

    public void UpdateScore(uint value)
    {
        Dicescore = value;
    }
}
