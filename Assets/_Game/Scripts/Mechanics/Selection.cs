using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public void Interact()
    {
        if (Plug.Instance.isSelected)
        {
            Plug.Instance.Connect();
        }
    }
}
