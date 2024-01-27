using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviour : MonoBehaviour
{
    Animator anim;
    public float NPC_Type;
    int randomInt;

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

        if(Input.GetKey(KeyCode.L))
        {
            NPC_Look_At_King();
        }

        if (Input.GetKey(KeyCode.B))
        {
            NPC_Extremely_Shocked_At_What_They_Have_Just_Seen();
        }
    }

    public void NPC_Look_At_King()
    {
        anim.SetTrigger("Look_At_King");
    }

    public void NPC_Extremely_Shocked_At_What_They_Have_Just_Seen()
    {
        anim.SetTrigger("Bamboozled");
    }
}
