using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TMP_Text text;
    private uint score;

    public uint TableScore {  
        get { return score; }
        set { score = value; }
    }

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(uint newScore)
    {
        text.text = newScore.ToString();
        score = newScore;
    }
}
