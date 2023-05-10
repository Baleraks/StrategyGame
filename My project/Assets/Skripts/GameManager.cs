using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject gameOverUI;
    [SerializeField] public static int turnNum=1;
    [SerializeField] public static int eventIsActive = 0;
    [SerializeField] public static float costMultiplier;
    [SerializeField] public static int eventBuildCount=0;
    [SerializeField] public static int eventRoadCount = 0;
    [SerializeField] private Shop shop;
    [SerializeField] private MapManager mapManager;
    [SerializeField] private BuildManager buildManager;
    public Event ev;
    public GameObject quest;
    public GameObject questItem;
    public GameObject questHouse;
    private AudioSource ButtonClick;

    private void GetButtonClickSound()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }
    private void Start()
    {
        GetButtonClickSound();
        DonNotDestroy musicObj = FindObjectOfType<DonNotDestroy>();
        musicObj.GayMagick();
    }

    public void GameOver()
    {
        buildManager.ClearInfo();
        gameOverUI.SetActive(true);
    }

    public void EndTurn()
    {
        ButtonClick.Play();
        turnNum++;
        eventBuildCount = PlayerStats.buildNumber;
        eventRoadCount = PlayerStats.roadNumber;

        if (turnNum == 5 && eventIsActive != 1)
        {
            eventIsActive = 1;
            ev.EventGenerator();
            turnNum = 0;
            costMultiplier = 0.01f;
            PlayerStats.moneyMultiplier = 5;
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
        PlayerStats.money += PlayerStats.moneyMultiplier * PlayerStats.buildNumber;
        PlayerStats.money += PlayerStats.moneyMultiplier * PlayerStats.conectNumber;
        PlayerStats.buildFactor += costMultiplier;
        shop.standardBuilding.cost = (int)(shop.standardBuilding.cost * PlayerStats.buildFactor);
        shop.Road.cost = (int)(shop.Road.cost * PlayerStats.buildFactor);
    }   
}
