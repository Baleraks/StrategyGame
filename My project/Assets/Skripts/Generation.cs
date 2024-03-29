using System;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private GameObject castle;
    [SerializeField] private MapManager mapManager;
    [SerializeField] private int expentionCoast;
    private int edgeX = -2;
    private int edgeZ = -2;
    private int fieldeSize = 5;
    private float fieldeMultiplier = 2f;
    private System.Random rand = new System.Random();
    private Field startField;
    private BuildManager buildManager;
    private AudioSource ButtonClick;

    private void GetButtonClickSound()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }

    void Start()
    {
        GetButtonClickSound();
        buildManager = BuildManager.instance;
        mapManager.Fields = new GameObject[fieldeSize, fieldeSize];
        int indexToSpawn;
        var indexX = edgeX;
        var indexZ = edgeZ;
        Vector3 pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
        for (int i = 0; i < fieldeSize; i++)
        {
            for (int j = 0; j < fieldeSize; j++)
            {
                indexToSpawn = rand.Next(0, 4);
                if (indexX == 0 && indexZ == 0)
                {
                    GameObject field = Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    mapManager.Fields[i, j] = field;
                    startField = field.GetComponent<Field>();
                }
                else
                {
                    mapManager.Fields[i, j] = Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                }
                indexX++;
                pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
                mapManager.Fields[i, j].GetComponent<Field>().mapPosition = (i,j);
            }
            indexX = edgeX;
            indexZ++;
            pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
        }
        GameObject building = (GameObject)Instantiate(castle, new Vector3(0, 0.5f, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        startField.Prefab = building;
        startField.building = Map.state.castle;
        buildManager.ClearInfo();     
        edgeX--; edgeZ--; fieldeSize += 2;
    }

    

    public void Expansion()
    {
        if(PlayerStats.money < expentionCoast)
        {
            return;
        }
        ButtonClick.Play();
        GameObject[,] buf = new GameObject[fieldeSize, fieldeSize];
        PlayerStats.money -= expentionCoast;
        int indexToSpawn;
        var indexX = edgeX;
        var indexZ = edgeZ;
        Vector3 pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
        for (int i = 0; i < fieldeSize; i++)
        {
            for (int j = 0; j < fieldeSize; j++)
            {
                if ((indexX == edgeX || indexX == Math.Abs(edgeX)) || (indexZ == edgeZ || indexZ == Math.Abs(edgeZ)))
                {
                    indexToSpawn = rand.Next(0, 4);
                    buf[i,j] = Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    indexX++;
                    pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
                }
                else
                {
                    indexX++;
                    pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
                    buf[i, j] = mapManager.Fields[i - 1, j - 1];
                }
                buf[i, j].GetComponent<Field>().mapPosition = (i, j);
            }
            indexX = edgeX;
            indexZ++;
            pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
        }
        mapManager.Fields = buf;
        MapManager.Size = buf.GetLength(1);
        edgeX--; edgeZ--; fieldeSize += 2 ;
    }
}
