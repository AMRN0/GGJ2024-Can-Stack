using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseGame : MonoBehaviour
{

    public Camera camera;
    public GameObject pauseMenu, kingUI;
    public Volume postProcess;

    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }


    public void PauseGameAction()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            kingUI.SetActive(false);
            pauseMenu.SetActive(true);
            postProcess.enabled = true;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            kingUI.SetActive(true);
            pauseMenu.SetActive(false);
            postProcess.enabled = false;
            isPaused = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { PauseGameAction(); }
    }
}
