using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Dice : MonoBehaviour
{
    [SerializeField] private ThrowPower throwPowerData;
    [SerializeField] private uint power;
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private List<Face> faces;
    [SerializeField] private float checkInterval;
    private uint Dicescore;
    private float mass;
    private Coroutine _waitRoutine;

    public uint Power { 
        get { return power; }
    }

    private void Awake()
    {
        if (power < 4) Debug.LogError("Check power in Dice one more time");
        if (faces.Count != power || faces.Count==0)
        {
            Debug.LogError($"Incorrect number of faces in Dice D{power}");
        }
        foreach (var face in faces)
        {
            face.ParentDice = this;
        }
        if (checkInterval == default(float)) checkInterval = 0.1f;
        mass = Rigidbody.mass;
    }

    public void Roll()
    {
        Rigidbody.AddForce(new Vector3(Random.Range(1, mass * 10), Random.Range(mass * 10, throwPowerData.MaxFy * mass), Random.Range(1, mass * 10)), ForceMode.Force);
        Rigidbody.AddTorque(new Vector3(Random.Range(mass, throwPowerData.MaxRx * mass), Random.Range(mass, throwPowerData.MaxRy * mass), Random.Range(mass, throwPowerData.MaxRz * mass)), ForceMode.Force);


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
