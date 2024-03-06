using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGameScenes : MonoBehaviour
{

    public GameObject splashScreens;
    public Animator splashAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
            splashAnim.StopPlayback();
            splashScreens.SetActive(false);
        }
    }

    public void loadCutscene()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void quitGame()
    {
#if UNITY_WEBGL
        SceneManager.LoadScene("Menu");
#else
        Application.Quit();
#endif
    }
}
