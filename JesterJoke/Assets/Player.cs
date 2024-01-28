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

    public bool performing;

    // Start is called before the first frame update
    void Start()
    {
        performing = false;
    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = progress;

        fill.color = gradientColour.Evaluate(progressBar.normalizedValue);
    }
}
