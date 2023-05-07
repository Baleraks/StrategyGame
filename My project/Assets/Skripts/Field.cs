using UnityEngine;
public class Field : MonoBehaviour
{
    public UnityEngine.Color changeColorGood;
    private UnityEngine.Color mainColor;
    public Map.state building;
    private Renderer rend;
    public GameObject Prefab;
    public Vector3 positionOffset;
    BuildManager buildManager;
    public BuildingInfo buildingInfo;
    public PlayerStats playerStats;
    public bool isUpgrated = false;
    public (int x, int y) mapPosition;
    public AudioSource BuildSound;

    private void GetButtonClickSound()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("BuildSound");
        BuildSound = soundObj[0].GetComponent<AudioSource>();
    }

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
        GetButtonClickSound();
    }

    void OnMouseDown()
    {
        if (!buildManager.canBuild || buildingInfo.Object != null)
        {
            return;
        }
        BuildBuilding(buildManager.GetTurretToBuild());
    }

    private void BuildBuilding(BuildingInfo info)
    {
        if (!buildManager.enoughMoney)
        {
            Debug.Log("NOT ENOUGH MONEY");
            return;
        }
        BuildSound.Play();
        PlayerStats.scoreFactor++;
        SetBuilding(info);
        info.Object.NeighboursUpdait(transform.GetComponent<Field>());
        PlayerStats.score += info.score * PlayerStats.scoreFactor;
        PlayerStats.money -= info.cost;
    }

    public void SetBuilding(BuildingInfo info)
    {
        this.Prefab = (GameObject)Instantiate(info.Object.SelfIndification(transform.GetComponent<Field>()), GetBuildPosition(), info.Object.GetRotation());
        Instantiate(info.Object.GetEffect(transform.GetComponent<Field>()), GetBuildPosition(), info.Object.GetRotation());
        buildingInfo = info;
        this.building = info.name;
    }
}


