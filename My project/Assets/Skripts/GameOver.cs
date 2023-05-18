using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;
    public BuildManager buildManager;
    public Text scoreText;
    public GameObject ui;
    private AudioSource ButtonClick;

    private void Start()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }

    void Update()
    {
        scoreText.text = PlayerStats.score.ToString();
    }

    public void Retry()
    {
        ButtonClick.Play();
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu ()
    {
        ButtonClick.Play();
        sceneFader.FadeTo("MainMenu");
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
