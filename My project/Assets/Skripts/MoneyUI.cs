using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text money;
    void Update()
    {
        money.text = "Money:" + PlayerStats.money.ToString();
    }
}
