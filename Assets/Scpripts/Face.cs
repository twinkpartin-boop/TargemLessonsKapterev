using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private uint points;
    private Dice parentDice;

    public Dice ParentDice { set { parentDice = value; } }

    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        parentDice.UpdateScore(parentDice.Power + 1 - points);
    }
}
