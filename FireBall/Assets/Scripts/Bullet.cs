using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _Speed;
    private void Update()
    {
        transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
    }
}
