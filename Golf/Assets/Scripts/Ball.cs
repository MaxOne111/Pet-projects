using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private List<Vector3> _Directions;

    private void Awake()
    {
        GameEvents._Ball_Is_Stopped += OffsetFromWall;
        
        AddDirection(Vector3.forward);
        AddDirection(Vector3.right);
        AddDirection(Vector3.left);
        AddDirection(Vector3.back);
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            GameEvents.NewMove();
            GameEvents.BallIsStopped();
        }
    }

    private void AddDirection(Vector3 _direction)
    {
        if(!_Directions.Contains(_direction))
            _Directions.Add(_direction);
    }

    private void OffsetFromWall()
    {
        float _x = transform.position.x;
        float _y = transform.position.y;
        float _z = transform.position.z;
        
        RaycastHit _hit;
        float _offset = 0.2f;
        float _distance_To_Wall = 0.15f;
        for (int i = 0; i < _Directions.Count; i++)
        {
            if (Physics.Raycast(transform.position, _Directions[i], out _hit, _distance_To_Wall))
            {
                if (_hit.collider.CompareTag("Field"))
                {
                    if (_Directions[i] == Vector3.forward)
                        transform.position = new Vector3(_x, _y, _z - _offset);
                    
                    if (_Directions[i] == Vector3.right)
                        transform.position = new Vector3(_x - _offset, _y, _z);
                    
                    if (_Directions[i] == Vector3.left)
                        transform.position = new Vector3(_x + _offset, _y, _z - _offset);
                    
                    if (_Directions[i] == Vector3.back)
                        transform.position = new Vector3(_x, _y, _z + _offset);
                }
            }
        }
    }

    private void OnDisable()
    {
        GameEvents._Ball_Is_Stopped -= OffsetFromWall;
    }

    private void OnDestroy()
    {
        GameEvents._Ball_Is_Stopped -= OffsetFromWall;
    }
}
