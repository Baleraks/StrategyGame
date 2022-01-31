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
        Vector3 pointToSpawn = new Vector3(0.0f, 0.0f, 0.0f);
        for(int i=0;i<5;i++)
        {
            for(int j=0;j<5;j++)
            {
                indexToSpawn = rand.Next(0, 4);
                Instantiate(objects[indexToSpawn], pointToSpawn, new Quaternion(0.0f,0.0f,0.0f,0.0f));
                pointToSpawn += new Vector3(2.25f, 0.0f, 0.0f);
            }
            pointToSpawn -= new Vector3(2.25f*5, 0.0f, 0.0f);
            pointToSpawn += new Vector3(0.0f, 0.0f, 2.25f);
        }
        Instantiate(castle, new Vector3(2.25f*2, 1.0f, 2.25f*2), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
    }
}
