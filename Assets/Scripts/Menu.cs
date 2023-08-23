using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public Canvas pauseCanvas;
    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
    }
    public void loadLevel(string name)
    {
        Application.LoadLevel(name);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void appPause()
    {
        pauseCanvas.gameObject.SetActive(true);
    }

    public void appContinue()
    {
        pauseCanvas.gameObject.SetActive(false);
    }
}
