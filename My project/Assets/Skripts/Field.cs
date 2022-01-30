using UnityEngine;

public class Field : MonoBehaviour
{
    public Color changeColorGood;
    private Color mainColor;
    public int money = 5;
    public int costForBuild = 5;
    private bool isBuild = false;
    void Start ()
    {
        mainColor = GetComponent<Renderer>().material.color;
    }
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = changeColorGood;
    }
    void OnMouseExit() 
    {
        GetComponent<Renderer>().material.color = mainColor;
    }
}
