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
        if (PlayerStats.money < info.cost)
        {
            Debug.Log("NOT ENOUGH MONEY");
            return;
        }
        int prefSelect = 0;
        switch (tag)
        {
            case "Fielde":
                {
                    prefSelect = 0;
                    break;
                }            
            case "Lake":
                {
                    prefSelect = 1;
                    break;
                }
            case "Grass":
                {
                    prefSelect = 2;
                    break;
                }
            case "Mountain":
                {
                    prefSelect = 3;
                    break;
                }
        }
        GameObject turret = (GameObject)Instantiate(info.prefarb[prefSelect], GetBuildPosition(), transform.rotation);
        this.turret = turret;
        buildingInfo = info;

        PlayerStats.money -= info.cost;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = mainColor;
    }
}


