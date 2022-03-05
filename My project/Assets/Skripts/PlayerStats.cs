using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject Object;
    public static int money;
    public int startMoney = 0;
   private void GetStartMoney()
   {
      
   }
    private void Start()
    {
        money = startMoney;
    }
}
   
  
