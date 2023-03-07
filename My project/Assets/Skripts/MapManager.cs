using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[,] Fields;
    public bool[,] used;

    private static (int x, int y)[] deltas = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

    public int Bfs((int x, int y) point)
    {
        bool isConected = false;
        int size = Fields.GetLength(1);
        Queue<(int x, int y)> q = new Queue<(int x, int y)>();
        q.Enqueue(point);
        (int x, int y) index;
        int build = 0;
        while (q.Count != 0)
        {
            index = q.Peek();
            q.Dequeue();
            used[index.x, index.y] = true;
            for (int i = 0; i < deltas.Length; i++)
            {
                int x = index.x + deltas[i].x;
                int y = index.y + deltas[i].y;
                if (x < size && x >= 0 && y < size && y >= 0)
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
        // Console.WriteLine(build);
    }
}
