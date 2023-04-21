using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public GameObject quest;
    public GameObject ui;
    public GameObject questItem;
    public GameObject questHouse;
    public Text questText;
    public Text buttonText;
    public Text consecText;
    static System.Random rand = new System.Random();
    public static int eventPriorityOne = 5 + rand.Next(1,5);
    public static int eventPriorityTwo = 5 + rand.Next(1,5);
    public bool eventproc = false;
    public bool eventproc2 = false;
   

    public void Good()
    {
        ui.SetActive(false);
        questItem.SetActive(true);
        if(eventproc)
        {
            buttonText.text = "Build houses to provide residents with houses.";
            consecText.text = " You have 5 turns to build 10 houses.";
        }

        if(eventproc2)
        {
            buttonText.text = "You have built too many roads, your residents have nowhere to live.";
            consecText.text = "You have 5 turns to build 5 roads.";
        }
        
    }

    public  void Bad()
    {
        ui.SetActive(false);
        quest.SetActive(true);
       
    }

    public void mainEvent()
    {
        ui.SetActive(true);
        GameManager.eventBuildCount = 0;
        GameManager.eventRoadCount = 0;
    }

    public  void EventGenerator()
    {
        if(eventPriorityOne>eventPriorityTwo)
        {
            mainEvent();
            questText.text = "You have built too many roads, your residents have nowhere to live.";
            eventPriorityOne = 5;
            eventproc = true;
            eventproc2 = false;

        }

        if (eventPriorityOne == eventPriorityTwo)
        {
              eventPriorityOne += rand.Next(1, 5);
              eventPriorityTwo += rand.Next(1, 5);
        }

        if (eventPriorityOne < eventPriorityTwo)
        {
            mainEvent();
            questText.text = "You have built too many buildings, the inhabitants are starving";
            eventPriorityTwo = 5;
            eventproc2 = true;
            eventproc = false;

        }

    }

    public void QuestConsec()
    {
        if (questHouse.activeSelf == true && eventproc)
        {
            if (GameManager.turnNum == 5 && GameManager.eventBuildCount >= 5)
            {
                GameManager.eventIsActive = 0;
                questHouse.SetActive(false);
                PlayerStats.money += 10000;
                GameManager.turnNum = 0;
            }
            else if (GameManager.turnNum == 5 && GameManager.eventBuildCount < 5)
            {
                GameManager.eventIsActive = 0;
                questHouse.SetActive(false);
                PlayerStats.money -= 5000;
                GameManager.turnNum = 0;
            }
        }

        if (questHouse.activeSelf == true && eventproc2)
        {
            if (GameManager.turnNum == 5 && GameManager.eventRoadCount >= 5)
            {
                GameManager.eventIsActive = 0;
                questHouse.SetActive(false);
                PlayerStats.money += 10000;
                GameManager.turnNum = 0;
            }
            else if (GameManager.turnNum == 5 && GameManager.eventRoadCount < 5)
            {
                GameManager.eventIsActive = 0;
                questItem.SetActive(false);
                PlayerStats.money -= 5000;
                GameManager.turnNum = 0;
            }
        }

        if (quest.activeSelf == true)
        {
            if (GameManager.turnNum == 5)
            {
                GameManager.eventIsActive = 0;
                quest.SetActive(false);
                PlayerStats.money -= 10000;
                GameManager.turnNum = 0;
            }
        }
    }
}
