using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _speed;    
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;
    [SerializeField] private Rigidbody _rigidbody;

    private _isWork = true;
    
    private void Start() 
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        float delay = new WaitForSeconds(_delay);

        while (_isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            _rigidbody.transform.up = direction;
            _rigidbody.velocity = direction * _speed;

            yield return delay;
        }
    }   
}