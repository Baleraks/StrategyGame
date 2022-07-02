using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text money;
    public PlayerStats playerStats;

    void Update()
    {
        money.text = playerStats.money.ToString();
    }
}
