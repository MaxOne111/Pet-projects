using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //private Animator _Animator;
    private GameObject _Player;

    //[SerializeField] private GameObject _Head;
    [SerializeField] private Transform _Gunpoint;
    [SerializeField] private GameObject _Bullet;

    private void Awake()
    {
        //_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        //_Animator.SetTrigger("Attack");
        //Instantiate(_Bullet, _Gunpoint);
        transform.LookAt(_Player.transform);
    }
}
