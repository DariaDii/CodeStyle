using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacesPoint;
    [SerializeField] private Transform[] _arrayPlaces;
    [SerializeField] private int _numberOfCurrentPlace;

    private float _distanceToTargetPoint = 0.1f;

    private void Start() 
    {
        _arrayPlaces = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
            _arrayPlaces[i] = _allPlacesPoint.GetChild(i);
    }

    private void Update()
    {
        var currentPlace = _arrayPlaces[_numberOfCurrentPlace];
        transform.position = Vector3.MoveTowards(transform.position , currentPlace.position, _speed * Time.deltaTime);

        if ((transform.position - currentPlace.position).sqrMagnitude < _distanceToTargetPoint)
            GetNextPlace();
    }

    private void GetNextPlace()
    {
        _numberOfCurrentPlace++;

        if (_numberOfCurrentPlace == _arrayPlaces.Length)
            _numberOfCurrentPlace = 0;
    }
}