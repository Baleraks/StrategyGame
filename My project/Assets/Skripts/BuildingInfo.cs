using UnityEngine;

[System.Serializable]
public class BuildingInfo
{
    public GameObject[] prefarb;
    public Map.state name;
    public int cost;
    public int score;

    public BuildingInfo(GameObject[] prefarb, Map.state name, int cost, int score)
    {
        this.prefarb = prefarb;
        this.name = name;
        this.cost = cost;
        this.score = score;
    }
}
