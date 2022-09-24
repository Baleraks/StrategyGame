using UnityEngine;
public class Field : MonoBehaviour
{
    public Color changeColorGood;
    private Color mainColor;
    //public int money = 5;
    //public int costForBuild = 5;
    private Renderer rend;
    private string tag;
    public GameObject turret;
    public Vector3 positionOffset;
    BuildManager buildManager;
    public BuildingInfo buildingInfo;
    public PlayerStats playerStats;
    public bool isUpgrated = false;
    

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        mainColor = rend.material.color;
        buildManager = BuildManager.instance;
        tag = this.gameObject.tag;
    }

    void OnMouseEnter()
    {
        if ( buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        GetComponent<Renderer>().material.color = changeColorGood;
    }

    void OnMouseDown()
    {
        if (!buildManager.canBuild || buildingInfo.prefarb[0] != null)
        {
            return;
        }
        BuildBuilding(buildManager.GetTurretToBuild());
        PlayerStats.scoreFactor++;
    }

    private void BuildBuilding(BuildingInfo info)
    {
        if (PlayerStats.money <= info.cost)
        {
            Debug.Log("NOT ENOUGH MONEY");
            return;
        }
        int prefSelect = 0;
        switch (tag)
        {
            case "Field":
                {
                    info.cost = 1;
                    prefSelect = 0;
                    PlayerStats.score += 2;
                    break;
                }            
            case "Lake":
                {
                    info.cost = 2;
                    prefSelect = 1;
                    PlayerStats.score += 3;
                    break;
                }
            case "Grass":
                {
                    info.cost = 3;
                    prefSelect = 2;
                    PlayerStats.score += 3;
                    break;
                }
            case "Mountain":
                {
                    info.cost = 4;
                    prefSelect = 3;
                    PlayerStats.score += 4;
                    break;
                }
        }
        GameObject turret = (GameObject)Instantiate(info.prefarb[prefSelect], GetBuildPosition(), transform.rotation);
        this.turret = turret;
        buildingInfo = info;
        PlayerStats.money -= info.cost;
        info.cost = 0;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = mainColor;
    }
}


