using UnityEngine.SceneManagement;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;

public class PauseMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public GameObject ui;
    public BuildManager buildManager;
    private AudioSource ButtonClick;

    private void Start()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }

    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Escape))
         {
            Toggle();
         }
    }

    public void Toggle()
    {
        ButtonClick.Play();
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
        Toggle();
        sceneFader.FadeTo("MainMenu");
    }
}
