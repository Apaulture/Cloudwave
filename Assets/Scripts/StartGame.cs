﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject noteController;
    public Scene mainScene;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("IsStartButton", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        switch(other.gameObject.name)
        {
            case "LeftHandAnchor":
                OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.LTouch);
                break;
            case "RightHandAnchor":
                OVRInput.SetControllerVibration(0.2f, 0.2f, OVRInput.Controller.RTouch);
                break;
        }

        if (this.gameObject.name == "Start Button")
        {
            noteController.SetActive(true);
        } else if (this.gameObject.name == "Play Button")
        {
            print("LOAD SCENE PAUL");
            SceneManager.LoadSceneAsync("Paul");
        }
        


        // Instantiate(noteController, Vector3.zero, Quaternion.identity, transform.parent);
        m_Animator.SetBool("IsTouched", true); // play touch animation
        StartCoroutine(SetInactiveAfterTouching());
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "LeftHandAnchor":
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
                break;
            case "RightHandAnchor":
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
                break;
        }
    }

    IEnumerator SetInactiveAfterTouching()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
