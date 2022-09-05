using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public PlayerStats playerStats;


    public void GameOver()
    {
        gameOverText.active = true;
    }

    public void EndTurn()
    {
        if (playerStats.scoreFactor <= 0)
        {
            GameOver();
        }
    }


}
