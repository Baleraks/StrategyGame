using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public GameObject quest;
    public GameObject ui;
    public GameObject questItem;
    public Text questText;
    public Text buttonText;
    public Text buttonText2;
    public Text consecText;
    static System.Random rand = new System.Random();
    public static int eventPriorityOne = 5 + rand.Next(1, 5);
    public static int eventPriorityTwo = rand.Next(1, 5) + PlayerStats.lakeNumber;
    public static int eventPriorityThree = rand.Next(1, 5) + PlayerStats.rockNumber;
    public bool eventproc = false;
    public bool eventproc2 = false;
    public bool eventproc3 = false;
    public bool eventproc4 = false;
    private AudioSource ButtonClick;

    private void Start()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }




    public void Good()
    {
        ButtonClick.Play();
        ui.SetActive(false);
        questItem.SetActive(true);

    }

    public void Bad()
    {
        ButtonClick.Play();
        ui.SetActive(false);
        quest.SetActive(true);

    }

    public void mainEvent()
    {
        ui.SetActive(true);
        GameManager.eventBuildCount = 0;
        GameManager.eventRoadCount = 0;
        PlayerStats.grassNumber = 0;
    }

    public void EventGenerator()
    {
        if (GameManager.eventRoadCount >= 7)
        {
            mainEvent();
            buttonText.text = "It's horrible";
            buttonText2.text = "It's horrible";
            consecText.text = " You have cost multiplier increased for 5 turns";
            questText.text = "You have built too many roads,plague in your settlement";
            eventPriorityOne = 5;
            eventproc = true;
            eventproc2 = false;
            eventproc3 = false;

        }

        if (GameManager.eventBuildCount > 7)
        {
            mainEvent();
            questText.text = "There was a disaster, our food was stolen by bandits, our settlement is starving.";
            buttonText.text = "I try to fix it";
            consecText.text = "You have 5 turns to build 5 farms on grass";
            eventPriorityTwo = 5;
            eventproc2 = true;
            eventproc = false;
            eventproc3 = false;
        }
        if (PlayerStats.rockNumber > 3 && eventPriorityThree >= 5)
        {
            mainEvent();
            buttonText.text = "Okay";
            buttonText2.text = "Nice";
            consecText.text = "You get 1000 gold coins";
            questText.text = "Residents found gold in one of the mines, you got money.";
            eventPriorityThree = 5;
            eventproc3 = true;
            eventproc = false;
            eventproc2 = false;
            PlayerStats.rockNumber = 0;
        }

        if (PlayerStats.lakeNumber > 3 && eventPriorityTwo >= 5)
        {
            mainEvent();
            buttonText.text = "Okay";
            buttonText2.text = "Nice";
            consecText.text = "You get more money at the end of your turn";
            questText.text = "Due to the large number of settlements near the water, the inhabitants began whaling. Now your buldings are more effective";
            eventPriorityThree = 5;
            eventproc4 = true;
            eventproc = false;
            eventproc2 = false;
            eventproc3 = false;
            PlayerStats.lakeNumber = 0;
        }

    }
    public void QuestConsec()
    {
        if (questItem.activeSelf == true && eventproc)
        {
            if (GameManager.eventRoadCount >= 5)
            {
                GameManager.eventIsActive = 0;
                questItem.SetActive(false);
                GameManager.costMultiplier = 0.05f;
                GameManager.turnNum = 0;
            }


            if (questItem.activeSelf == true && eventproc2)
            {
                if (PlayerStats.grassNumber >= 5)
                {
                    GameManager.eventIsActive = 0;
                    questItem.SetActive(false);
                    PlayerStats.money += 1000;
                    GameManager.turnNum = 0;
                }
                else if (GameManager.eventBuildCount < 5)
                {
                    GameManager.eventIsActive = 0;
                    questItem.SetActive(false);
                    PlayerStats.money -= 500;
                    GameManager.turnNum = 0;
                }
            }
            if (questItem.activeSelf == true && eventproc3)
            {
                GameManager.eventIsActive = 0;
                questItem.SetActive(false);
                PlayerStats.money += 1000;
            }

            if (questItem.activeSelf == true && eventproc4)
            {
                GameManager.eventIsActive = 0;
                questItem.SetActive(false);
                PlayerStats.moneyMultiplier = 6;
            }


            //cringe
            if (quest.activeSelf == true)
            {
                if (GameManager.turnNum == 5)
                {
                    GameManager.eventIsActive = 0;
                    quest.SetActive(false);
                    PlayerStats.money -= 1000;
                    GameManager.turnNum = 0;
                }
            }

            if (quest.activeSelf == true && eventproc3)
            {
                GameManager.eventIsActive = 0;
                quest.SetActive(false);
                PlayerStats.money += 1000;
                GameManager.turnNum = 0;
            }
            if (quest.activeSelf == true && eventproc)
            {
                GameManager.eventIsActive = 0;
                quest.SetActive(false);
                GameManager.costMultiplier = 0.05f;
                GameManager.turnNum = 0;

            }
            if (quest.activeSelf == true && eventproc4)
            {
                GameManager.eventIsActive = 0;
                questItem.SetActive(false);
                PlayerStats.moneyMultiplier = 6;
            }
        }
    }
}
