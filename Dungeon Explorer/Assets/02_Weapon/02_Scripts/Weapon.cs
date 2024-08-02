using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _porjectilePrefab;
    [SerializeField] private GameObject _weaponProjectileSpawn;

    [SerializeField] private float _maxProjectiles;
    [SerializeField] private float _projectileSpendPerShot;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _attackCooldown;

    private float _remainingProjectiles;
    private float _remainingAttackCooldown;
    
    private Vector3 _newPositionVector;


    void Awake()
    {
        _remainingAttackCooldown = _attackCooldown;
    }

    void Update()
    {
        if (_remainingAttackCooldown > 0f)
        {
            _remainingAttackCooldown -= Time.deltaTime;
        }

        _newPositionVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        _newPositionVector.z = this.transform.position.z;
        this.transform.right = _newPositionVector;

        if (_newPositionVector.x < 0f)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, -1, this.transform.localScale.z);
        }
        else if (_newPositionVector.x >= 0f)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, 1, this.transform.localScale.z);
        }


    }

    public void Shoot()
    {
        if (_remainingAttackCooldown > 0f)
        {
            _remainingAttackCooldown -= Time.deltaTime;
            return;
        }

        if (_remainingProjectiles >= _projectileSpendPerShot)
        {
            _remainingProjectiles -= _projectileSpendPerShot;

            Instantiate(_porjectilePrefab, _weaponProjectileSpawn.transform.position, _weaponProjectileSpawn.transform.rotation);
            
            _remainingAttackCooldown = _attackCooldown;

            if (_remainingProjectiles < _projectileSpendPerShot)
            {
                StartCoroutine(Reload());
            }
        }
        else
        {
            Debug.Log("EmptyChamber");
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);

        _remainingProjectiles = _maxProjectiles;
    }
}
