using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Button btn;
    TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        buttonText.color = Color.black;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        buttonText.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
