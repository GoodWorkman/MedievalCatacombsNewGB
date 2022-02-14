using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraWall : MonoBehaviour
{
    //у нас есть максимальная дальность камеры
    //нам нужно проверять, есть ли на расстоянии и в направлении камеры от игрока обьекты с коллайдерами
    
    //если нет - камера на максимальной дистанции
    //если есть - камера перемещается на расстояние до коллайдера


    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _camera;
    private float _maxCameraDistance;

    private void Start()
    {
        _maxCameraDistance = Vector3.Distance(_player.position, _camera.position);
    }

    private void Update()
    {
        CorrectCameraPosition();
    }

    private void CorrectCameraPosition()
    {
        //0,0,1
        //0,0,-1
        
        Vector3 direction = _player.position - _camera.position;
        
        /*
            
         */
        Ray ray = new Ray(_player.position, direction);
        if(Physics.Raycast(ray, out RaycastHit hit, _maxCameraDistance, _targetLayer))//, _maxCameraDistance, _targetLayer))
        {
            Vector3 normDirection = direction.normalized;
            _camera.position = (normDirection * hit.distance) + _player.position;
        }
    }
}
