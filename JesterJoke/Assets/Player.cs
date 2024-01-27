using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider progressBar;
    public Gradient gradientColour;
    public Image fill;
    public int progress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = progress;

        fill.color = gradientColour.Evaluate(progressBar.normalizedValue);
    }
}
