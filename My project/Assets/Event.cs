using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public GameObject quest;
    public  GameObject ui;

    public void Good()
    {
        ui.SetActive(false);
    }

    public  void Bad()
    {
        ui.SetActive(false);
        quest.SetActive(true);
       
    }
}
