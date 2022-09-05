using UnityEngine.UI;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public Text score;
    public PlayerStats playerStats;


    void Update()
    {
        score.text = playerStats.score.ToString();
    }
}
