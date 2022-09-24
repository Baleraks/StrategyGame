using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject Object;
    public static int money;
    public static int score;
    public int startMoney;
    public int buildFactor;
    public static int scoreFactor;
    

    private void Start()
    {
        money = startMoney;
        score = 0;
    }
}
   
  
