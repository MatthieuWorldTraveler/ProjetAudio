using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _padSensitivity;
    [SerializeField] private float _mouseYMin;
    [SerializeField] private float _mouseYMax;
    private Transform _cameraTransform;
    private Transform _transform;
    private float _vertical;
    private float _horizontal;

    private void Awake()
    {
        _transform = transform;
        _cameraTransform = GetComponentInChildren<Camera>().transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        float manetteX = Input.GetAxis("RightHorizontal") * _padSensitivity * Time.deltaTime;
        float manetteY = Input.GetAxis("RightVertical") * _padSensitivity * Time.deltaTime;
        _horizontal += mouseX + manetteX;
        _vertical += mouseY + manetteY;
        _vertical = Mathf.Clamp(_vertical, _mouseYMin, _mouseYMax);
        _transform.eulerAngles = new Vector3(_transform.eulerAngles.x, _horizontal, _transform.eulerAngles.z);
        _cameraTransform.eulerAngles = new Vector3(_vertical, _cameraTransform.eulerAngles.y, _cameraTransform.eulerAngles.z);
    }
}
