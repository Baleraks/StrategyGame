using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public GameObject quest;
    public  GameObject ui;
    public GameObject questItem;

    public void Good()
    {
        ui.SetActive(false);
        questItem.SetActive(true);
    }

    public  void Bad()
    {
        ui.SetActive(false);
        quest.SetActive(true);
       
    }
}
