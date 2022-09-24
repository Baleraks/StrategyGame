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
        
        if (PlayerStats.scoreFactor <= 1)
        {
            GameOver();
        }
        PlayerStats.scoreFactor = 1;
        PlayerStats.money = PlayerStats.money + 2 * PlayerStats.buildNumber;
       
    } 


}
