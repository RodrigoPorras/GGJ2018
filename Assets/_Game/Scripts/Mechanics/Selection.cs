using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Agent agent;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Interact()
    {
        if (Plug.Instance.isSelected)
        {
            Plug.Instance.Connect();
        }
    }

    public void UpdateSlot()
    {
        image.sprite = agent.face.faceSprite;
    }
}
