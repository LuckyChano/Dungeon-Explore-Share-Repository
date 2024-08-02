using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public interface IDamageable
{
    public void TakeDamage(float value);
}

public interface ICurable
{
    public void Heal(float value);
}

public interface IMortal
{
    public void Die();
}
