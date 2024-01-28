using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Juggling : MonoBehaviour
{
    public GameObject leftButton, rightButton;

    bool leftActive, rightActive;
    bool running;

    float promtTime = 0.5f;

    int fails = 0;
    int wins = 0;

    public GameObject JuggleMinigameParent;

    //Call to start minigame
    public void StartMinigame()
    {
        ResetMinigame();
        //ActivateButtons();
        running = true;
        GameObject.Find("Main Camera").GetComponent<Player>().performing = true;

    }


    //if minigame failed 
    public void MinigameFailed()
    {
        running = false;
        Debug.Log("Failed Minigame");
        //sad king
        GameObject.Find("NPC_Manager").GetComponent<NPC_Manager>().loseTrigger();
        GameObject.Find("Main Camera").GetComponent<Player>().performing = false;
        JuggleMinigameParent.SetActive(false);
    }

    //if minigame won
    public void MinigamePassed()
    {
        running = false;
        Debug.Log("Passed Minigame");
        //he he hu hah
        GameObject.Find("NPC_Manager").GetComponent<NPC_Manager>().winTrigger();
        GameObject.Find("Main Camera").GetComponent<Player>().performing = false;
        JuggleMinigameParent.SetActive(false);


    }

    void ResetMinigame()
    {
        fails = 0;
        wins = 0;
    }
    void ActivateLeft()
    {
        leftActive = true;
        leftButton.SetActive(true);
        leftTimer = Time.time + promtTime;
        leftButton.GetComponent<Image>().color = Color.white;
        CheckWin();

    }
    void ActivateRight()
    {
        rightActive = true;
        rightButton.SetActive(true);
        rightTimer = Time.time + promtTime;
        rightButton.GetComponent<Image>().color = Color.white;
        CheckWin();
    }

    void CheckWin()
    {
        wins++;
        if(wins > 10)
        {
            if(running)
                MinigamePassed();
        }
    }

    void Deactivate(bool isLeft)
    {
        if(isLeft)
        {
            leftActive = false;
            leftButton.SetActive(false);
        }
        else
        {
            rightActive = false;
            rightButton.SetActive(false);
        }
    }


    async void JugglingMiss(bool isLeft)
    {

        if(isLeft)
        {
            leftButton.GetComponent<Image>().color = Color.red;
            await Task.Delay(500);
            Deactivate(true);
        }
        else
        {
            rightButton.GetComponent<Image>().color = Color.red;
            await Task.Delay(500);
            Deactivate(false);

        }
        fails++;
        if (fails > 2 && running)
            MinigameFailed();

        //Missed Knife add sound effect + king sadness
    }


    

    // Start is called before the first frame update
    void Start()
    {
        StartMinigame();
    }

    float leftTimer, rightTimer;

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            if (leftActive)
            {
                if (leftTimer <= Time.time)
                {
                    JugglingMiss(true);
                }
            }

            if (rightActive)
            {
                if (rightTimer <= Time.time)
                {
                    JugglingMiss(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (leftActive)
                {
                    Deactivate(true);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (rightButton)
                {
                    Deactivate(false);

                }
            }
        }
        else
        {
            Deactivate(true);
            Deactivate(false);
        }
        
    }

    async void ActivateButtons()
    {

        await Task.Delay(1000);

        ActivateLeft();
        await Task.Delay(1000);
        ActivateRight();

        ActivateButtons();
    }
}
