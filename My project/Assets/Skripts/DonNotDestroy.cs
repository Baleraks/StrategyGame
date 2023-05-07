using UnityEngine;
using UnityEngine.SceneManagement;

public class DonNotDestroy : MonoBehaviour
{
    [SerializeField] private string GameScene;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BGSound");
        if (musicObj.Length > 1)
        {
             GayMagick();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void GayMagick()
    {
            Destroy(this.gameObject);
    }
}
