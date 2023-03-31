using UnityEngine.SceneManagement;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public BuildManager buildManager;

    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
         {
            Toggle();
         }
    }

    public void Toggle()
    {
        buildManager.ClearInfo();
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;

        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }
}
