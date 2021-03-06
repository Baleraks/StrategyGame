using UnityEngine;
public class Field : MonoBehaviour
{
    public Color changeColorGood;
    private Color mainColor;
    //public int money = 5;
    //public int costForBuild = 5;
    private bool isBuild = false;
    private Renderer rend;
    public GameObject turret;
    public Vector3 positionOffset;
    BuildManager buildManager;
    public BuildingInfo buildingInfo;
    public bool isUpgrated = false;
    public PlayerStats playerStats;


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        mainColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = changeColorGood;
    }

    void BuildBuilding(BuildingInfo info)
    {
        if (playerStats.money < info.cost)
        {
            Debug.Log("NOT ENOUGH OXYGEN");
            return;
        }
        GameObject turret = (GameObject)Instantiate(info.prefarb, GetBuildPosition(), transform.rotation);
        this.turret = turret;
        buildingInfo = info;
        playerStats.money -= info.cost;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = mainColor;
    }
}


