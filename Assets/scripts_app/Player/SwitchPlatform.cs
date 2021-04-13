using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    [SerializeField]
    bool windowsPlatform;

    [SerializeField]
    PlayerControllerWindows playerControllerWindows;

    [SerializeField]
    PlayerControllerWebGL playerControllerWebGL;

    [SerializeField]
    GameObject NetworkCommponent;

    public bool WindowsPlatform { get => windowsPlatform; set => windowsPlatform = value; }

    void Start()
    {
        if (WindowsPlatform)
        {
            NetworkCommponent.SetActive(false);
            playerControllerWebGL.enabled = false;
            playerControllerWindows.enabled = true;
        }
        else {
            NetworkCommponent.SetActive(true);
            playerControllerWebGL.enabled = true;
            playerControllerWindows.enabled = false;
        }
    }

   
}
