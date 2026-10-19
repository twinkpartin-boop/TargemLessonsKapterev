using UnityEngine;
using TMPro;
using System.Linq;

public class WinCondtion : MonoBehaviour
{
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text loseText;

    [SerializeField] private GameObject win;
    [SerializeField] private GameObject draw;
    [SerializeField] private GameObject lose;
    private int minPossible;
    private int maxPossible;

    private int winCondtion;
    private int loseCondtion;

    public int MinPossible { set { minPossible = value; } }
    public int MaxPossible { set { maxPossible = value; } }


    void Start()
    {
        if (winText == null) winText = GetComponentInChildren<TMP_Text>();
        if (loseText == null) winText = GetComponentInChildren<TMP_Text>();
        if (Player.Instance.Dices_.Count != 0)
        {
            minPossible = Player.Instance.Dices_.Count;
            maxPossible = (int)Player.Instance.Dices_.Sum(dice => dice.Power);
        }
        UpdateCondition();
        HideResult();
        Player.Rolled += ShowResult;
        Player.NewRoll += HideResult;
        NewRoundButton.NewRoundEvent += OffCondtions;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCondition()
    {
        loseCondtion = Random.Range(minPossible, maxPossible);
        loseText.text = "Поражение = " + loseCondtion.ToString();
        winCondtion = Random.Range(loseCondtion + 1, maxPossible + 1);
        winText.text = "Победа = " + winCondtion.ToString();
    }

    public void CountPossibles(int dicePower, int amount)
    {
        minPossible += amount;
        maxPossible += dicePower * amount;
        UpdateCondition();
    }

    public void CountPossibles(uint dicePower, uint amount)
    {
        CountPossibles((int)dicePower, (int)amount);
    }

    private void ShowResult()
    {
        var score = Player.Instance.PlayerScore;
        if (score > 0)
        {
            if (score < loseCondtion) lose.SetActive(true);
            else if (score >= winCondtion) win.SetActive(true);
            else draw.SetActive(true);
        }
    }

    public void HideResult()
    {
        lose.SetActive(false);
        win.SetActive(false);
        draw.SetActive(false);
    }

    private void OffCondtions()
    {
        HideResult();
        loseText.text = "Поражение = ?";
        winText.text = "Победа = ?";
        minPossible = 0;
        maxPossible = 0;
    } 

}
