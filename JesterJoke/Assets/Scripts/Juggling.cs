using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Juggling : MonoBehaviour
{
    public GameObject leftButton, rightButton;

    bool leftActive, rightActive;


    float promtTime = 0.5f;


    void ActivateLeft()
    {
        leftActive = true;
        leftButton.SetActive(true);
        leftTimer = Time.time + promtTime;
        leftButton.GetComponent<Image>().color = Color.white;

    }
    void ActivateRight()
    {
        rightActive = true;
        rightButton.SetActive(true);
        rightTimer = Time.time + promtTime;
        rightButton.GetComponent<Image>().color = Color.white;
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
    }




    

    // Start is called before the first frame update
    void Start()
    {
        ActivateButtons();

    }

    float leftTimer, rightTimer;

    // Update is called once per frame
    void Update()
    {

        if(leftActive)
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
            if(leftActive)
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

    async void ActivateButtons()
    {

        await Task.Delay(1000);

        ActivateLeft();
        await Task.Delay(1000);
        ActivateRight();

        ActivateButtons();
    }
}
