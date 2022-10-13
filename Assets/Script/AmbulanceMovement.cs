using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceMovement : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _maxDistance = 0;
    [SerializeField] float _minDistance = -200f;
    bool _isFacingNorth;
    Rigidbody _rb;
    Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _rb = GetComponent<Rigidbody>();
        _isFacingNorth = true;
        PushForward();
    }

    private void Update()
    {
        if (_isFacingNorth && _transform.position.z >= _maxDistance)
        {
            UTurn();
        }
        else if (!_isFacingNorth && _transform.position.z <= _minDistance)
        {
            UTurn();
        }
    }

    void PushForward()
    {
        _rb.velocity = _transform.forward * _speed;
    }
    

    void UTurn()
    {
        _transform.forward = -_transform.forward;
        _isFacingNorth = !_isFacingNorth;
        PushForward();
    }
}
