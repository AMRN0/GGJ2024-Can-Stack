using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Juggling : MonoBehaviour
{
    public GameObject leftButton, rightButton;

    bool leftActive, rightActive;





    void ActivateLeft()
    {
        leftActive = true;
        leftButton.SetActive(true);
    }
    void ActivateRight()
    {
        rightActive = true;
        rightButton.SetActive(true);
    }








    // Start is called before the first frame update
    void Start()
    {
        ActivateButtons();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(leftActive)
            {
                leftButton.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (rightButton)
            {
                rightButton.SetActive(false);
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
