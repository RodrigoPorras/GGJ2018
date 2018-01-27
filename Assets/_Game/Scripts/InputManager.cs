using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool plugGrabbed;
    Plug plug;

    private void Awake()
    {
        plug = FindObjectOfType<Plug>();
    }

    
}
