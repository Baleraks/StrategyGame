using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[,] Fields;
    public bool[,] used;
    public static (int x, int y)[] Deltas = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
    public static int Size;

    private void Start()
    {
        Size = Fields.GetLength(1);
    }

    public int Bfs((int x, int y) point)
    {
        bool isConected = false;
        Queue<(int x, int y)> q = new Queue<(int x, int y)>();
        q.Enqueue(point);
        (int x, int y) index;
        int build = 0;
        while (q.Count != 0)
        {
            index = q.Peek();
            q.Dequeue();
            used[index.x, index.y] = true;
            for (int i = 0; i < Deltas.Length; i++)
            {
                int x = index.x + Deltas[i].x;
                int y = index.y + Deltas[i].y;
                if (x < Size && x >= 0 && y < Size && y >= 0)
                {

                    if (Fields[x, y].GetComponent<Field>().building == Map.state.road && !used[x, y])
                    {
                        q.Enqueue((x, y));
                    }
                    if (Fields[x, y].GetComponent<Field>().building == Map.state.build && !used[x, y])
                    {
                        build++;
                        used[x, y] = true;
                    }
                    if (Fields[x, y].GetComponent<Field>().building == Map.state.castle)
                    {
                        isConected = true;
                    }
                }
            }
        }
        if (!isConected)
        {
            build = 0;
        }
        return build;
    }
}
