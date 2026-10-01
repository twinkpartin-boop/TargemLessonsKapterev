using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private float maxFy;
    [SerializeField] private float maxRx;
    [SerializeField] private float maxRy;
    [SerializeField] private float maxRz;
    private Rigidbody Rigidbody;
    private float mass;
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        mass = Rigidbody.mass;
        if (Rigidbody == null )
        {
            Debug.LogError("Нет компонента Rigidbody", this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Roll()
    {
        Rigidbody.AddForce(new Vector3(Random.Range(1, mass * 10), Random.Range(mass * 10, maxFy * mass), Random.Range(1, mass * 10)), ForceMode.Force);
        Rigidbody.AddTorque(new Vector3(Random.Range(mass, maxRx * mass), Random.Range(mass, maxRy * mass), Random.Range(mass, maxRz * mass)), ForceMode.Force);
    }
}
