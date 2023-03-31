using System.Collections.Generic;
using UnityEngine;

public abstract class IObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    public MapManager mapManager;
    public List<Field> Neighbours;

    public virtual GameObject SelfIndification(Field field)
    {
        return null;
    }

    public virtual Quaternion GetRotation()
    {
        return transform.rotation;
    }

    public void LookUpMap(Field field)
    {
        for (int i = 0; i < MapManager.Deltas.Length; i++)
        {
            int x = field.mapPosition.x + MapManager.Deltas[i].x;
            int y = field.mapPosition.y + MapManager.Deltas[i].y;
            if (x < MapManager.Size && x >= 0 && y < MapManager.Size && y >= 0)
            {
                Field bfu = mapManager.Fields[x, y].GetComponent<Field>();
                if (bfu.building == Map.state.road)
                {
                    Neighbours.Add(bfu);                
                }
            }
        }
    }

    public void NeighboursUpdait(Field field)
    {
        Neighbours = new List<Field>();
        LookUpMap(field);
        for(int i = 0; i< Neighbours.Count; i++)
        {
            BuildingInfo buf = Neighbours[i].buildingInfo;
            Destroy(Neighbours[i].Prefab);
            Neighbours[i].SetBuilding(buf);
        }
    }
}
