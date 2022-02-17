using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _aim;
    [SerializeField] private float _offsetFromPlayer;
    public Vector3 _aimPosition { get; private set; }
    private Camera _mainCamera;
    private Transform _cameraTransform;
    private Vector3 _screenCenter;
    private bool _RMB;

    private void Start()
    {
        _mainCamera = Camera.main;
        _cameraTransform = _mainCamera.transform;
        _screenCenter = new Vector3(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        _RMB = Input.GetMouseButton(1);
    }

    private void LateUpdate()
    {
        print("Работает");
        CalculateAimPosition();
        SetAim();
    }

    private void CalculateAimPosition()
    {
        Vector3 offset = _player.forward * _offsetFromPlayer;
        Ray ray;
        if (_RMB)
        {
            ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        }
        else
        {
            ray = _mainCamera.ScreenPointToRay(_screenCenter);
        }

        Plane plane = new Plane(-_cameraTransform.forward, _player.position + offset);
        plane.Raycast(ray, out float enter);
        _aimPosition = ray.GetPoint(enter);
    }
    
    private void SetAim()
    {
        _aim.LookAt(_cameraTransform.position);
        _aim.position = _aimPosition;
    }
    
    
}
