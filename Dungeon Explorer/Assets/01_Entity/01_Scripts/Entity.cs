using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float _maxHealth;
    protected float _currentHealth;
    protected bool _isAlive;

    protected void StartHealth(float health)
    {
        _maxHealth = health;
        _currentHealth = _maxHealth;
    }
}
