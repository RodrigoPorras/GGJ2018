using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour
{
    // public properties

    public static Plug Instance;
    public bool isSelected;

    // private properties

    Transform plugTransform;
    Vector3 initialPos;
    

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        plugTransform = transform;
        initialPos = plugTransform.position;
    }

    void Update()
    {
        if (isSelected)
        {
            Move(GvrPointerInputModule.CurrentRaycastResult.worldPosition);
        }
    }

    public void Interact()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        isSelected = true;
    }

    public void Reset()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        isSelected = false;
        plugTransform.position = initialPos;
    }

    public void Connect()
    {
        isSelected = false;
    }

    public void Move(Vector3 pointerPos)
    {
        Vector3 newPos = plugTransform.position;
        newPos.x = pointerPos.x;
        newPos.y = pointerPos.y;
        plugTransform.position = newPos;
    }
}
