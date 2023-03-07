using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public BuildingInfo standardBuilding;
    public BuildingInfo Road;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartBuilding()
    {
        buildManager.SelectTurretToBuild(standardBuilding);
    }

    public void SelectRoad()
    {
        buildManager.SelectTurretToBuild(Road);
    }
}
