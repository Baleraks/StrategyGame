using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public BuildingInfo standardBuilding;
    public BuildingInfo Road;
    private AudioSource ButtonClick;

    private void Start()
    {
        buildManager = BuildManager.instance;
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }
    public void SelectStandartBuilding()
    {
        ButtonClick.Play();
        buildManager.SelectTurretToBuild(standardBuilding);
    }

    public void SelectRoad()
    {
        ButtonClick.Play();
        buildManager.SelectTurretToBuild(Road);
    }
}
