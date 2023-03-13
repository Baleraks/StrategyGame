using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private int turnNum=1;
    [SerializeField] private int eventNum = 0;
    [SerializeField] private float costMultiplier;
    [SerializeField] public int moneyMultiplier;
    [SerializeField] private Shop shop;
    [SerializeField] private MapManager mapManager;
    public GameObject eventUI;
    public GameObject quest;

    public void GameOver()
    {
        gameOverText.active = true;
    }

    public void EndTurn()
    {
        
        turnNum++;
        
        if(turnNum >= 5 && PlayerStats.buildNumber >= 10 && PlayerStats.scoreFactor !=1)
        {
            eventUI.SetActive(true);
            turnNum = 0;
            eventNum++;
            quest.SetActive(false);
        }
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
