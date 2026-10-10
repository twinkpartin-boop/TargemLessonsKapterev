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
    private float radiusSaved;
    private float distanceSaved;
    private bool change;
    private uint amountSaved;

    private GameObject curobj;
    private float newx;
    private float newz;

    void Awake()
    {
        if (radius < 0) radius = 0;
        if (distance < 0) distance = 0;
        else 
        { 
            distance = Mathf.Min(distance, 2 * radius * (Mathf.PI) / ((float)amount)); 
        }
        angleDistance = distance / radius;
        objects = new GameObject[amount];
        for (int i = 0; i < amount; i++)
        {
            curobj = Instantiate(RotatingObject, transform);
            newx = radius * Mathf.Sin(i * angleDistance);
            newz = radius * Mathf.Cos(i * angleDistance);
            curobj.transform.localPosition = new Vector3(newx, 0, newz);
            objects[i] = curobj;
        }
        change = false;
        amountSaved = amount;
        distanceSaved = distance;
        radiusSaved = radius;
    
    }

    // Update is called once per frame
    void Update()
    {
        CheckChange();
        for (int i = 0; i < amountSaved; i++)
        {
            curobj = objects[i];
            newx = (curobj.transform.localPosition.x)*Mathf.Cos(speed) - (curobj.transform.localPosition.z)*Mathf.Sin(speed);
            newz = (curobj.transform.localPosition.x) * Mathf.Sin(speed) + (curobj.transform.localPosition.z) * Mathf.Cos(speed);
            curobj.transform.localPosition = new Vector3 (newx, 0, newz);
        }
    }

    private void CheckChange()
    {
        if (radiusSaved != radius)
        {
            change = true;
            if (radius < 0) radius = 0;
            radiusSaved = radius;
        }
        if ( distanceSaved != distance)
        {
            change = true;
            if (distance < 0) distance = 0;
            else { distance = Mathf.Min(distance, 2 * radius * (Mathf.PI) / ((float)amount)); }
            distanceSaved = distance;
        }
        if (change)
        {
            angleDistance = distance / radius;
            for (int i = 0; i < amountSaved; i++)
            {
                newx = radius * Mathf.Sin(i * angleDistance);
                newz = radius * Mathf.Cos(i * angleDistance);
                objects[i].transform.localPosition = new Vector3(newx, 0, newz);
            }
            change = false;
        }
        else return;
    }
}
