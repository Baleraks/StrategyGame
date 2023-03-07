using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private int turnNum; 
    [SerializeField] private float costMultiplier;
    [SerializeField] private int moneyMultiplier;
    [SerializeField] private Shop shop;
    [SerializeField] private MapManager mapManager;

    public void GameOver()
    {
        gameOverText.active = true;
    }

    public void EndTurn()
    {
        turnNum++;        
        int size = mapManager.Fields.GetLength(1);
        mapManager.used = new bool[size, size];
        PlayerStats.conectNumber = mapManager.Bfs((size / 2 + 1, size / 2)) + mapManager.Bfs((size / 2 - 1, size / 2)) 
            + mapManager.Bfs((size / 2, size / 2 + 1)) + mapManager.Bfs((size / 2, size / 2 - 1));
        if (PlayerStats.scoreFactor <= 1)
        {
            GameOver();
        }
        PlayerStats.scoreFactor = 1;
        PlayerStats.money += moneyMultiplier * PlayerStats.buildNumber;
        PlayerStats.money += moneyMultiplier * PlayerStats.conectNumber;
        PlayerStats.buildFactor += costMultiplier;
        shop.standardBuilding.cost = (int)(shop.standardBuilding.cost * PlayerStats.buildFactor);
        shop.Road.cost = (int)(shop.Road.cost * PlayerStats.buildFactor);
    }
}
