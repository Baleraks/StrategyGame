using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject castle;
    private System.Random rand = new System.Random();
    void Start()
    {
        int indexToSpawn;
        var indexX = -2.0f;
        var indexZ = -2.0f;
        Vector3 pointToSpawn = new Vector3(indexX*2.25f, 0.0f, indexZ*2.25f);
        for(int i=0;i<5;i++)
        {
            for(int j=0;j<5;j++)
            {
                indexToSpawn = rand.Next(0, 4);
                Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f,0.0f,0.0f,0.0f));
                indexX++;
                pointToSpawn = new Vector3(indexX * 2.25f, 0.0f, indexZ * 2.25f);
            }
            indexX = -2.0f;
            indexZ++;
            pointToSpawn = new Vector3(indexX * 2.25f, 0.0f, indexZ * 2.25f);
        }
        Instantiate(castle, new Vector3(0,0.5f,0), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
    }
}
