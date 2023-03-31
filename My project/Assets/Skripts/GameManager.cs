using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private int turnNum=1;
    [SerializeField] private int eventNum = 0;
    [SerializeField] private float costMultiplier;
    [SerializeField] public int moneyMultiplier;
    [SerializeField] public int eventBuildCount=0;
    [SerializeField] public int eventRoadCount = 0;
    [SerializeField] private Shop shop;
    [SerializeField] private MapManager mapManager;
    [SerializeField] private BuildManager buildManager;   
    public GameObject eventUINoRoads;
    public GameObject eventUINoHouses;
    public GameObject quest;
    public GameObject questItem;
    public GameObject questHouse;

    public void GameOver()
    {
        buildManager.ClearInfo();
        gameOverText.SetActive(true);
    }

    public void EndTurn()
    {
        turnNum++;
        eventBuildCount = PlayerStats.buildNumber;
        eventRoadCount = PlayerStats.roadNumber;

        if(turnNum == 5 && eventBuildCount >= 10 && PlayerStats.scoreFactor !=1 )
        {
            eventUINoRoads.SetActive(true);
            turnNum = 0;
            eventNum++;
            eventBuildCount = 0;
            eventRoadCount = 0;
        }

        if (turnNum == 5  && PlayerStats.scoreFactor != 1 && eventRoadCount >=5)
        {
            eventUINoHouses.SetActive(true);
            turnNum = 0;
            eventNum++;
            eventBuildCount = 0;
            eventRoadCount = 0;
        }

        if (questHouse.activeSelf == true)
        {
            if(turnNum==5 && eventBuildCount>=5)
            {
                questHouse.SetActive(false);
                PlayerStats.money += 10000;
                turnNum = 0;
            }
            else if(turnNum == 5 && eventBuildCount < 5)
            {
                questHouse.SetActive(false);
                PlayerStats.money -= 5000;
                turnNum = 0;
            }
        }

        if (questItem.activeSelf == true)
        {
            if (turnNum == 5 && eventRoadCount >= 5)
            {
                questItem.SetActive(false);
                PlayerStats.money += 10000;
                turnNum = 0;
            }
            else if (turnNum == 5 && eventRoadCount < 5)
            {
                questItem.SetActive(false);
                PlayerStats.money -= 5000;
                turnNum = 0;
            }
        }

        if (quest.activeSelf == true)
        {
            if (turnNum == 5 )
            {
                quest.SetActive(false);
                PlayerStats.money -= 10000;
                turnNum = 0;
            }
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
