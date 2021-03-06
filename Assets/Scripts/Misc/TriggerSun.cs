﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sunrise when the player/elevator touches this zone

public class TriggerSun : MonoBehaviour
{
    public GameObject sun;
    public float waitBeforeLerp;
    public static bool sunTriggered;
    public static bool titleTriggered;
    Animator m_Animator;
    
    void Start()
    {
        
        m_Animator = sun.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Elevator Floor" && transform.name == "Suntrigger")
        {
            m_Animator.SetBool("SunUp", true);
            StartCoroutine(wait());
            
            
        }
        if (other.gameObject.name == "Elevator Floor" && transform.name == "Titletrigger")
        {
            titleTriggered = true;
        }


    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitBeforeLerp);
        sunTriggered = true;
    }
}
