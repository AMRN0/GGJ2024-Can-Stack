using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    public GameObject[] NPCs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    winTrigger();
        //}
        if (GameObject.Find("Main Camera").GetComponent<Player>().progress <= 0)
        {
            gameOverTrigger();
        }
    }

    public void winTrigger()
    {
        foreach(GameObject person in NPCs)
        {
            if (GameObject.Find("Main Camera").GetComponent<Player>().progress > 0)
            {
                person.GetComponent<Animator>().SetTrigger("Time_For_A_Celebration");
            }
        }
    }

    public void loseTrigger()
    {
        foreach (GameObject person in NPCs)
        {
            person.GetComponent<Animator>().SetTrigger("Bamboozled");

            if (person.GetComponent<NPC_Behaviour>().isExecutioner)
            {
                person.GetComponent<NPC_Behaviour>().executioner_Animation_Number += 1;
                if (person.GetComponent<NPC_Behaviour>().executioner_Animation_Number > 3)
                {
                    person.GetComponent<NPC_Behaviour>().executioner_Animation_Number = 1;
                }

                if (person.GetComponent<NPC_Behaviour>().executioner_Animation_Number == 1)
                {
                    person.GetComponent<Animator>().SetTrigger("Bamboozled1");
                }

                if (person.GetComponent<NPC_Behaviour>().executioner_Animation_Number == 2)
                {
                    person.GetComponent<Animator>().SetTrigger("Bamboozled2");
                }

                if (person.GetComponent<NPC_Behaviour>().executioner_Animation_Number == 3)
                {
                    person.GetComponent<Animator>().SetTrigger("Bamboozled3");
                }
            }
        }
    }

    public void gameOverTrigger()
    {
        foreach (GameObject person in NPCs)
        {
            person.GetComponent<Animator>().SetTrigger("Game_Over");
        }
    }
}
