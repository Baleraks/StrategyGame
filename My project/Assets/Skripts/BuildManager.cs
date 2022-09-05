using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private BuildingInfo BuildingToBuild;
    private Field selectedFielde;

    public bool canBuild { get { return BuildingToBuild != null; } }
    public bool enoughMoney { get { return PlayerStats.money >= BuildingToBuild.cost; } }
    public string[] tags = { "StandartBuilding", "Tower", "road", "Castle" };

    public BuildingInfo GetTurretToBuild()
    {
        return BuildingToBuild;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    public void SelectNode(Field fielde)
    {
        if (selectedFielde == fielde)
        {
            DiselectNode();
            return;
        }
        selectedFielde = fielde;
        BuildingToBuild = null;
        //nodeUI.SetTarget(node);
    }

    public void DiselectNode()
    {
        selectedFielde = null;
        //nodeUI.Hide();
    }

    public void SelectTurretToBuild(BuildingInfo building)
    {
        BuildingToBuild = building;
        DiselectNode();
    }
}


