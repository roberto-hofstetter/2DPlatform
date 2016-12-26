using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PanelUI;

    private bool paused = false;

    void Start()
    {
        PanelUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;            
        }

        if (paused)
        {
            PanelUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PanelUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
