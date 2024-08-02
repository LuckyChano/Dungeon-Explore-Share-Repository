using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb2D;

    private float _projectileSpeed;
    private float _projectileDamage;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb2D.MovePosition(transform.position + transform.up * _projectileSpeed * Time.fixedDeltaTime);
    }
}
