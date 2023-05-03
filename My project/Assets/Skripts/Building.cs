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
                    PlayerStats.lakeNumber++;
                    prefSelect = 1;
                    break;
                }
            case "Grass":
                {
                    PlayerStats.grassNumber++;
                    prefSelect = 2;
                    break;
                }
            case "Mountain":
                {
                    PlayerStats.rockNumber++;
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
