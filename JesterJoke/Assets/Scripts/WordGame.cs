using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Threading.Tasks;

public class WordGame : MonoBehaviour
{
    int wins = 0;
    int fails = 0;
    bool running;

    public GameObject WordGameParent;

    public TextMeshProUGUI letterText;
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
        WordGameParent.SetActive(false);
    }

    //if minigame won
    public void MinigamePassed()
    {
        running = false;
        Debug.Log("Passed Minigame");
        //he he hu hah
        GameObject.Find("NPC_Manager").GetComponent<NPC_Manager>().winTrigger();
        GameObject.Find("Main Camera").GetComponent<Player>().performing = false;
        WordGameParent.SetActive(false);


    }
    void ResetMinigame()
    {
        fails = 0;
        wins = 0;
    }

    string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    string letterSelected;
    bool letterActive;
    void ShowLetter()
    {
        int rand = Random.Range(0, letters.Length);
        letterSelected = letters[rand];
        timer = Time.time + promtTime;
        letterActive = true;
    }
    float promtTime = 2.0f;
    float timer;
    void LetterTimeout(bool fail)
    {
        
        if(Time.time > timer || fail)
        {
            letterActive = false;
            letterText.text = string.Empty;
        }
    }

    void ButtonPress()
    {
        if(letterSelected != string.Empty)
        {
            if (Input.GetKeyDown(letterSelected))
            {
                Debug.Log("Correct");
                wins++;
                if(wins >= 10)
                {
                    MinigamePassed();
                }
            }
            else if(Input.anyKeyDown)
            {
                LetterTimeout(true);
                Debug.Log("YOU FOOL");
                fails++;
                if(fails > 2)
                {
                    MinigameFailed();
                }
            }
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        letterSelected = string.Empty;
        ActivateLetters();
    }

    // Update is called once per frame
    void Update()
    {
        ButtonPress();
        if(letterActive)
        {
            letterText.text = letterSelected;
            LetterTimeout(false);
        }
    }

    async void ActivateLetters()
    {

        await Task.Delay(3000);
        ShowLetter();
        ActivateLetters();




    }
}
