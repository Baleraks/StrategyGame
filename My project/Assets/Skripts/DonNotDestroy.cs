using UnityEngine;
using UnityEngine.SceneManagement;

public class DonNotDestroy : MonoBehaviour
{
    [SerializeField] private string GameScene;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BGSound");
        //GameObject[] soundObj = GameObject.FindGameObjectsWithTag("SoundSource");
        if (musicObj.Length > 1)
        {
             GayMagick();
        }
        //else if (soundObj.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}
        DontDestroyOnLoad(this.gameObject);
    }

    public void GayMagick()
    {
            Destroy(this.gameObject);
    }
}
