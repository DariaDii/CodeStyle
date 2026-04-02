using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementByWaypoints : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsConteiner;
    [SerializeField] private Transform[] _arrayWaypoints;
    [SerializeField] private int _numberOfCurrentPoint;

    private float _distanceToTargetPoint = 0.1f;

    private void Start() 
    {
        _arrayWaypoints = new Transform[_waypointsConteiner.childCount];

        for (int i = 0; i < _waypointsConteiner.childCount; i++)
            _arrayWaypoints[i] = _waypointsConteiner.GetChild(i);
    }

    private void Update()
    {
        var currentPoint = _arrayWaypoints[_numberOfCurrentPoint];
        transform.position = Vector3.MoveTowards(transform.position , currentPoint.position, _speed * Time.deltaTime);

        if ((transform.position - currentPoint.position).sqrMagnitude < _distanceToTargetPoint)
            ChangeToNextPoint();
    }

    private void ChangeToNextPoint()
    {
        _numberOfCurrentPoint++;

        if (_numberOfCurrentPoint == _arrayWaypoints.Length)
            _numberOfCurrentPoint = 0;
    }
}