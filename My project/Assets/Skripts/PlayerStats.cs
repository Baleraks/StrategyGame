using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject Object;
    public static int money;
    public int score;
    public int startMoney;
    public double buildFactor;
    public int scoreFactor;

    private void Start()
    {
        money = startMoney;
        score = 0;
    }
}
   
  
