using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    void OnEnable()
    {
        scoreText.text = PlayerStats.score.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu ()
    {
        Time.timeScale = 1f;
        Debug.Log("Go to Menu");
    }
}
