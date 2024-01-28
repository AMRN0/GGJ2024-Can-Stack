using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInflation : MonoBehaviour
{
    Vector3 inflationChange = new(0.35f, 0.35f, 0.35f);
    Vector3 deflationChange = new(0.01f, 0.01f, 0.01f);

    [SerializeField] float winCondition = 3.0f;

    bool inflate = false;

    [HideInInspector] public static bool win = false;

    void Start()
    {
        transform.localScale = new(0.5f, 0.5f, 0.5f);
        transform.position = Vector3.zero;
    }
    //cheeseburger
    void Update()
    {
        if (transform.localScale.x <= 0.5f)
        {
            transform.localScale = new(0.5f, 0.5f, 0.5f);
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
            this.transform.localScale += inflationChange;// * Time.deltaTime;
            transform.position = Vector3.zero;
            inflate = false;
        }
        else
        {
            if (transform.localScale.x > 0.5f)
            {
                this.transform.localScale -= deflationChange;// * Time.deltaTime;
                transform.position = Vector3.zero;
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
            gameObject.SetActive(false);
        }
    }

    void LoseCondition()
    {
        win = false;
        gameObject.SetActive(false);
    }

    public void ResetMiniGame()
    {
        inflationChange = new(0.3f, 0.3f, 0.3f);
        deflationChange = new(0.1f, 0.1f, 0.1f);
        transform.localScale = new(0.5f, 0.5f, 0.5f);
        transform.position = Vector3.zero;
        inflate = false;
        win = false;
    }
}
