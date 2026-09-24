using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class RotateCenter : MonoBehaviour
{
    [SerializeField] private GameObject RotatingObject;
    [SerializeField] private uint amount;
    [SerializeField] private float radius;
    [SerializeField] private float distance;
    [SerializeField]
    [Tooltip("”глова€ скорость движени€ обьектов в радианах/кадр")]
    private float speed;
    private float angleDistance;
    private GameObject[] objects;

    void Awake()
    {
        if (radius < 0) radius = 0;
        if (distance < 0) distance = 0;
        else { distance = Mathf.Min(distance, 2 * radius * (Mathf.PI) / ((float)amount)); }
        angleDistance = distance / radius;
        objects = new GameObject[amount];
        for (int i = 0; i < amount; i++)
        {
            GameObject newObj = Instantiate(RotatingObject, transform);
            float x = radius * Mathf.Sin(i * angleDistance);
            float z = radius * Mathf.Cos(i * angleDistance);
            newObj.transform.localPosition = new Vector3(x, 0, z);
            objects[i] = newObj;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = objects[i];
            float newx = (obj.transform.localPosition.x)*Mathf.Cos(speed) - (obj.transform.localPosition.z)*Mathf.Sin(speed);
            float newz = (obj.transform.localPosition.x) * Mathf.Sin(speed) + (obj.transform.localPosition.z) * Mathf.Cos(speed);
            obj.transform.localPosition = new Vector3 (newx, 0, newz);
        }
    }
}
