using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject gameOverUI;
    [SerializeField] public static int turnNum=1;
    [SerializeField] public static int eventIsActive = 0;
    [SerializeField] private float costMultiplier;
    [SerializeField] public int moneyMultiplier;
    [SerializeField] public static int eventBuildCount=0;
    [SerializeField] public static int eventRoadCount = 0;
    [SerializeField] private Shop shop;
    [SerializeField] private MapManager mapManager;
    [SerializeField] private BuildManager buildManager;
    public Event ev;
  
    public GameObject quest;
    public GameObject questItem;
    public GameObject questHouse;
   

    public void GameOver()
    {
       
        buildManager.ClearInfo();
        gameOverUI.SetActive(true);
    }

    public void EndTurn()
    {
        turnNum++;
        eventBuildCount = PlayerStats.buildNumber;
        eventRoadCount = PlayerStats.roadNumber;

        

        if (turnNum == 5 && eventIsActive != 1)
        {
            eventIsActive = 1;
            ev.EventGenerator();
            turnNum = 0;
        }

        ev.QuestConsec();

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
