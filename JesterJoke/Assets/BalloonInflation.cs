using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInflation : MonoBehaviour
{
    Vector3 inflationChange = new(0.3f, 0.3f, 0.3f);
    Vector3 deflationChange = new(0.1f, 0.1f, 0.1f);

    [SerializeField] float winCondition;

    bool inflate = false;

    [HideInInspector] public static bool win = false;

    void Start()
    {
        transform.localScale = new(0.5f, 0.5f, 0.5f);
        transform.position = Vector3.zero;
    }

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
            this.transform.localScale += inflationChange * Time.deltaTime;
            transform.position = Vector3.zero;
            inflate = false;
        }
        else
        {
            if (transform.localScale.x > 0.5f)
            {
                this.transform.localScale -= deflationChange * Time.deltaTime;
                transform.position = Vector3.zero;
            }
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
    }
}
