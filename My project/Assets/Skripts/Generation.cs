using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private BuildingInfo castle;
    private int edgeX = -2;
    private int edgeZ = -2;
    private int fieldeSize = 5;
    private float fieldeMultiplier = 2.0f;
    private System.Random rand = new System.Random();
    private Field startField;
    private BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        int indexToSpawn;
        var indexX = edgeX;
        var indexZ = edgeZ;
        Vector3 pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
        for(int i=0;i< fieldeSize; i++)
        {
            for(int j=0;j< fieldeSize; j++)
            {
                indexToSpawn = rand.Next(0, 4);
                if (indexX == 0 && indexZ == 0)
                {
                    startField = Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)).GetComponent<Field>();
                }
                else
                {
                    Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                }
                indexX++;
                pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
            }
            indexX = edgeX;
            indexZ++;
            pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
        }
        GameObject building = (GameObject)Instantiate(castle.prefarb[0], new Vector3(0, 0.5f, 0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        startField.turret = building;
        startField.buildingInfo = castle;
        edgeX--; edgeZ--; fieldeSize += 2;
        buildManager.ClearInfo();
    }

    

    public void Expansion()
    {
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
                    Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
                    indexX++;
                    pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
                }
                else
                {
                    indexX++;
                    pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
                }
            }
            indexX = edgeX;
            indexZ++;
            pointToSpawn = new Vector3(indexX * fieldeMultiplier, 0.0f, indexZ * fieldeMultiplier);
        }
        edgeX--; edgeZ--; fieldeSize += 2 ;
    }
}
