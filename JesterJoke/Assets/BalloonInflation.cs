using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInflation : MonoBehaviour
{
    public bool performing;

    Vector3 inflationChange = new(0.3f, 0.3f, 0.3f);
    Vector3 deflationChange = new(0.1f, 0.1f, 0.1f);

    [SerializeField] float winCondition;

    bool inflate = false;

    public GameObject confettiPrefab;

    [HideInInspector] public static bool win = false;

    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<Player>().performing = true;
        transform.localScale = new(0.5f, 0.5f, 0.5f);
        //transform.position = Vector3.zero;
    }

    void Update()
    {
        if (transform.localScale.x <= 0.25f)
        {
            LoseCondition();
        }

        CheckInput();

        print(inflate);

        Inflation();

        WinCondition();
    }

    private void Inflation()
    {
        if (inflate)
        {
            this.transform.localScale += inflationChange * Time.deltaTime;
            //transform.position = Vector3.zero;
            inflate = false;
        }
        else
        {
            //if (transform.localScale.x > 0.5f)
            //{
            //    this.transform.localScale -= deflationChange * Time.deltaTime;
            //    transform.position = Vector3.zero;
            //}
            this.transform.localScale -= deflationChange * Time.deltaTime;
            //transform.position = Vector3.zero;
        }
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            inflate = true;
            print("pressed");
        }
    }

    void WinCondition()
    {
        if (transform.localScale.x > winCondition)
        {
            win = true;
            Instantiate(confettiPrefab, new Vector3(-1, 2, 0), Quaternion.identity);
            GameObject.Find("NPC_Manager").GetComponent<NPC_Manager>().winTrigger();
            GameObject.Find("Main Camera").GetComponent<Player>().performing = false;
            gameObject.SetActive(false);
        }
    }

    void LoseCondition()
    {
        win = false;
        GameObject.Find("NPC_Manager").GetComponent<NPC_Manager>().loseTrigger();
        GameObject.Find("Main Camera").GetComponent<Player>().performing = false;
        gameObject.SetActive(false);
    }

    public void ResetMiniGame()
    {
        inflationChange = new(0.3f, 0.3f, 0.3f);
        deflationChange = new(0.1f, 0.1f, 0.1f);
        transform.localScale = new(0.5f, 0.5f, 0.5f);
        //transform.position = Vector3.zero;
    }
}
