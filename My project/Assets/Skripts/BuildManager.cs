using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    [SerializeField] private BuildingInfo BuildingToBuild;
    [SerializeField] private Field selectedFielde;

    public bool canBuild { get { return BuildingToBuild != null; } }
    
    public bool enoughMoney { get { return PlayerStats.money >= BuildingToBuild.cost; } }

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
        ClearInfo();
        //nodeUI.SetTarget(node);
    }

    public void ClearInfo()
    {
        BuildingToBuild = null;
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


