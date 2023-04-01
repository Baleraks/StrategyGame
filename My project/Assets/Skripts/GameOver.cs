using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public BuildManager buildManager;
    public Text scoreText;
    public GameObject ui;

    void OnEnable()
    {
        scoreText.text = PlayerStats.score.ToString();
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu ()
    {
       
        Debug.Log("Go to Menu");
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
}
