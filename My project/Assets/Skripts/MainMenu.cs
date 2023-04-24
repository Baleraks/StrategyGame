using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo("SampleScene");
    }
    public void Settings()
    {
        sceneFader.FadeTo("OptionsView");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
