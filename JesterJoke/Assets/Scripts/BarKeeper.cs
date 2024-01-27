using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class BarKeeper : MonoBehaviour, IPointerDownHandler
{
    private void Start()
    {
        AddPhysics2DRaycaster();
    }

    public AudioClip[] voices;
    public AudioSource voiceSource;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        Debug.Log("click detect");
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
    int previous;
    public void PlayVoiceLine()
    {
        int rand = Random.Range(0, voices.Length );
        while (rand == previous)
        {
            rand = Random.Range(0, voices.Length);
        }
        voiceSource.PlayOneShot(voices[rand]);
        previous = rand;
    }


}
