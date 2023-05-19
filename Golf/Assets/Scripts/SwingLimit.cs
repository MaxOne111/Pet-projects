using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingLimit : MonoBehaviour
{
    public bool IsTouch { get;  set; }
    public float LimitLength { get; set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            IsTouch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Field"))
        {
            IsTouch = false;
        }
    }
}
