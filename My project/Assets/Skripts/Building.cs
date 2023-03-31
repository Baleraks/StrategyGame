using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : IObject
{
    public override GameObject SelfIndification(Field field)
    {
        PlayerStats.buildNumber++;
        int prefSelect = 0;
        switch (field.tag)
        {
            case "Lake":
                {
                    prefSelect = 1;
                    break;
                }
            case "Grass":
                {
                    prefSelect = 2;
                    break;
                }
            case "Mountain":
                {
                    prefSelect = 3;
                    break;
                }
            default: 
                {
                    break;
                }
        }
        return gameObjects[prefSelect];
    }
}
