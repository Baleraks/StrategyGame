using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject Object;
    public static int money;
    public static int score;
    public int startMoney;
    //��������� �����
    public float buildFactor;
    //���������� ������
    public static int buildNumber;
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
   
  
