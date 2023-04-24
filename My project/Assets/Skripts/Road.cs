using System.Collections.Generic;
using UnityEngine;

public class Road : IObject
{
    public List<Map.position> ObjectPos;

    public override GameObject SelfIndification(Field field)
    {
        PlayerStats.roadNumber++;
        int prefSelect = 0;
        ObjectPos = new List<Map.position>();
        LookUpMap(field);
        switch (ObjectPos.Count)
        {
            case 1:
                {
                    prefSelect = 1;
                    break;
                }
            case 2:
                {
                    if (ObjectPos.Contains(Map.position.up) && ObjectPos.Contains(Map.position.down) || ObjectPos.Contains(Map.position.left) && ObjectPos.Contains(Map.position.right))
                    {
                        prefSelect = 2;
                    }
                    else
                    {
                        prefSelect = 3;
                    }
                    break;
                }
            case 3:
                {
                    prefSelect = 4;
                    break;
                }
            case 4:
                {
                    prefSelect = 5;
                    break;
                }
            default: 
                { 
                    break; 
                }
        }
        return gameObjects[prefSelect];
    }

    public override Quaternion GetRotation()
    {
        Quaternion rotation = transform.rotation;
        switch (ObjectPos.Count)
        {
            case 1:
                {
                    rotation = OnePointRoad();
                    break;
                }
            case 2:
                {
                    rotation = TwoPointRoad();
                    break;
                }
            case 3:
                {
                    rotation = ThreePointRoad();
                    break;
                }
            default:
                {
                    break;
                }
        }
        return rotation;
    }

    public new void LookUpMap(Field field)
    {
        for (int i = 0; i < MapManager.Deltas.Length; i++)
        {
            int x = field.mapPosition.x + MapManager.Deltas[i].x;
            int y = field.mapPosition.y + MapManager.Deltas[i].y;
            if (x < MapManager.Size && x >= 0 && y < MapManager.Size && y >= 0)
            {
                Map.state state = mapManager.Fields[x, y].GetComponent<Field>().building;
                if (state == Map.state.road || state == Map.state.build || state == Map.state.castle)
                {
                    ObjectPos.Add((Map.position)i);
                }
            }
        }
    }

    private Quaternion OnePointRoad()
    {
        Quaternion rotation = transform.rotation;
        switch (ObjectPos[0])
        {
            case Map.position.up: { rotation = Quaternion.Euler(0, 180, 0); break; }
            case Map.position.down: { rotation = Quaternion.Euler(0, 0, 0); break; }
            case Map.position.left: { rotation = Quaternion.Euler(0, 90, 0); break; }
            case Map.position.right: { rotation = Quaternion.Euler(0, 270, 0); break; }
        }
        return rotation;
    }

    private Quaternion TwoPointRoad()
    {
        Quaternion rotation = transform.rotation;
        if (ObjectPos.Contains(Map.position.left) && ObjectPos.Contains(Map.position.right) || ObjectPos.Contains(Map.position.left) && ObjectPos.Contains(Map.position.down))
        {
            rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (ObjectPos.Contains(Map.position.left) && ObjectPos.Contains(Map.position.up))
        {
            rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (ObjectPos.Contains(Map.position.up) && ObjectPos.Contains(Map.position.right))
        {
            rotation = Quaternion.Euler(0, 270, 0);
        }
        return rotation;
    }

    private Quaternion ThreePointRoad()
    {
        Quaternion rotation = transform.rotation;
        if (ObjectPos.Contains(Map.position.left) && ObjectPos.Contains(Map.position.right) && ObjectPos.Contains(Map.position.up))
        {
            rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (ObjectPos.Contains(Map.position.down) && ObjectPos.Contains(Map.position.up) && ObjectPos.Contains(Map.position.left))
        {
            rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (ObjectPos.Contains(Map.position.up) && ObjectPos.Contains(Map.position.down) && ObjectPos.Contains(Map.position.right))
        {
            rotation = Quaternion.Euler(0, 270, 0);
        }
        return rotation;
    }
}
