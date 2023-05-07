using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private AudioSource ButtonClick;
    public SceneFader sceneFader;

    private void Start()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }

    public void Play()
    {
        ButtonClick.Play();
        sceneFader.FadeTo("SampleScene");
    }
    public void Settings()
    {
        ButtonClick.Play();
        sceneFader.FadeTo("OptionsView");
    }

    public void Quit()
    {
        ButtonClick.Play();
        Application.Quit();
    }
}
