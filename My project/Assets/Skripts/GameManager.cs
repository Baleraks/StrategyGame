using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private int turnNum; 
    [SerializeField] private float costMultiplier;
    [SerializeField] private int moneyMultiplier;
    [SerializeField] private Shop shop;

    public void GameOver()
    {
        gameOverText.active = true;
    }

    public void EndTurn()
    {
        turnNum++;        
        if (PlayerStats.scoreFactor <= 1)
        {
            GameOver();
        }
        PlayerStats.scoreFactor = 1;
        PlayerStats.money += moneyMultiplier * PlayerStats.buildNumber;
        PlayerStats.buildFactor += costMultiplier;
        shop.standardBuilding.cost = (int)(shop.standardBuilding.cost * PlayerStats.buildFactor);
    }
}
