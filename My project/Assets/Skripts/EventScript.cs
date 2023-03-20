using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
   
    public  GameObject ui;

    public void Good()
    {
        ui.SetActive(false);
    }

    public  void Bad()
    {
        ui.SetActive(false);
    }
}
