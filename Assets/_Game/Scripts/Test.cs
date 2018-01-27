using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    Image im;
    Material ma;
    private bool selected;
    Transform myTransform;
    public LayerMask defaultLayer;
    public LayerMask ignoreLayer;

    private void Awake()
    {
        im = GetComponent<Image>();
        ma = GetComponent<Renderer>().material;
        myTransform = transform;
    }

    private void Update()
    {
        if (selected)
        {
            Vector3 newPos = myTransform.position;
            newPos.x = GvrPointerInputModule.CurrentRaycastResult.worldPosition.x;
            newPos.y = GvrPointerInputModule.CurrentRaycastResult.worldPosition.y;
            myTransform.position = newPos;
        }
    }
    public void HighlightUI()
    {
        im.color = Color.yellow;
    }

    public void Highlight()
    {
        ma.color = Color.yellow;
    }

    public void UnHighlight()
    {
        ma.color = Color.white;
    }

    public void Press()
    {
        if (!selected)
        {
            selected = true;
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }
}
