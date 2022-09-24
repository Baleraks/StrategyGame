using UnityEngine.UI;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public Text score;
 


    void Update()
    {
        score.text = PlayerStats.score.ToString();
    }
}
