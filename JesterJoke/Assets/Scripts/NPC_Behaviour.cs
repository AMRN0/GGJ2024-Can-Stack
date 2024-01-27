using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviour : MonoBehaviour
{
    Animator anim;
    public float NPC_Type;
    int randomInt;

    public bool isExecutioner;
    int executioner_Animation_Number = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetFloat("NPC_Type", NPC_Type);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("NPC_Type", NPC_Type);

        if(Input.GetKeyDown(KeyCode.L))
        {
            NPC_Look_At_King();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if(!isExecutioner)
            {
                NPC_Extremely_Shocked_At_What_They_Have_Just_Seen();
            }

            if (isExecutioner)
            {
                Executioner_Extremely_Shocked_At_What_They_Have_Just_Seen();
                executioner_Animation_Number += 1;
                if(executioner_Animation_Number > 3)
                {
                    executioner_Animation_Number = 1;
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            NPC_Going_For_A_Celebration();
        }
    }

    public void NPC_Look_At_King()
    {
        anim.SetTrigger("Look_At_King");
        anim.SetTrigger("Erm_Acctually");
    }

    public void NPC_Extremely_Shocked_At_What_They_Have_Just_Seen()
    {
        anim.SetTrigger("Bamboozled");
    }

    public void NPC_Going_For_A_Celebration()
    {
        anim.SetTrigger("Time_For_A_Celebration");
    }


    public void Executioner_Extremely_Shocked_At_What_They_Have_Just_Seen()
    {
        if (executioner_Animation_Number == 1)
        {
            anim.SetTrigger("Bamboozled1");
        }

        if (executioner_Animation_Number == 2)
        {
            anim.SetTrigger("Bamboozled2");
        }

        if (executioner_Animation_Number == 3)
        {
            anim.SetTrigger("Bamboozled3");
        }
    }
}
