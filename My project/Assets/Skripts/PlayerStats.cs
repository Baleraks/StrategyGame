using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int score;
    public int startMoney;
    //��������� �����
    [SerializeField] public static float buildFactor;
    //���������� ������
    public static int buildNumber;
    public static int rockNumber;
    public static int lakeNumber;
    public static int grassNumber;
    //���������� �����
    public static int roadNumber;
    //���������� ������ ������ -> ������ -> �����
    public static int conectNumber;
    [SerializeField] public static int scoreFactor;
    

    private void Start()
    {
        buildFactor = 1.0f; 
        scoreFactor = 1;
        money = startMoney;
        score = 0;
    }
}
   
  
