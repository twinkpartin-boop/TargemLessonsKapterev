using UnityEngine;

public class Face : MonoBehaviour
{
    [SerializeField] private uint points;
    private Dice parentDice;

    public Dice ParentDice { set { parentDice = value; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Desk")) parentDice.UpdateScore(parentDice.Power + 1 - points);
    }
}
