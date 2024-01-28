using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class King_Man : MonoBehaviour
{
    public GameObject canvasText;
    public GameObject textBox;
    public GameObject jugglingIcon;
    public GameObject balloonsIcon;
    public int selectedGame;

    public GameObject balloonPrefab;
    public GameObject JuggleGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void renderTextBox()
    {
        canvasText.SetActive(true);
    }

    public void deRenderTextBox()
    {
        canvasText.SetActive(false);

        if (selectedGame == 1)
        {
            JuggleGame.SetActive(true);
            JuggleGame.GetComponentInChildren<Juggling>().StartMinigame();
            //Instantiate(balloonPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        }

        if (selectedGame == 2)
        {
            Instantiate(balloonPrefab, new Vector3(-1, 2, 0), Quaternion.identity);
        }
    }

    public void loadGameOver()
    {
        SceneManager.LoadScene("Game_Over_Scene");
    }
}
