using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Man : MonoBehaviour
{
    public GameObject canvasText;
    public GameObject textBox;
    public GameObject jugglingIcon;
    public GameObject balloonsIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void renderTextBox()
    {
        canvasText.SetActive(true);
    }

    public void deRenderTextBox()
    {
        canvasText.SetActive(false);
    }
}
