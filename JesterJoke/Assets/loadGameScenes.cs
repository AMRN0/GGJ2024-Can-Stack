using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGameScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadCutscene()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
