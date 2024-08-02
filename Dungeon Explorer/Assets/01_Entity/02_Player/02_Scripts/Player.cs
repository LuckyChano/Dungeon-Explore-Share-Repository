using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IDamageable, ICurable, IMortal
{
    //Variables Estaticas

    //Campos o variables de instacias
    //-Campo privado
    //--Variables Privadas por Referencia
    private Animator _playerAnimator;
    private PlayerMovement _playerMovement;
    private PlayerControl _playerControl;
    private PlayerAnimation _playerAnimation;
    
    [SerializeField] private Weapon _playerWeapon;

    //--Variables Privadas
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private float _playerMovementSpeed = 4f;
    [SerializeField] private bool _isWeaponEquiped = false;

    //-Campo publico solo si es necesario
    //--Variables Publicas por Referencia

    //--Variables Publicas

    //Propiedades

    //Delegados

    /*  Metodos de Unity en este orden
            - Awake
            - Start
            - Late Update
            - Updates
            - Fixed Update
            - Collisions
            - Gizmos
    */
    void Awake()
    {
        //Iniciacion de mi clase
        StartHealth(_playerHealth);

        //GetComponents
        _playerAnimator = GetComponent<Animator>();

        //_playerWeapon = GetComponentInChildren<Weapon>();

        //Instanciacion de las clases por Composicion
        _playerAnimation = new PlayerAnimation(_playerAnimator);
        _playerMovement = new PlayerMovement(this.transform, _playerMovementSpeed);
        _playerControl = new PlayerControl(this.transform, _playerMovement, _playerAnimation, _playerWeapon);
    }

    void Update()
    {
        _playerControl.ArtificialUpdate();

        _playerAnimation.IsWeaponEquiped = _isWeaponEquiped;
    }

    void FixedUpdate()
    {
        _playerControl.ArtificialFixedUpdate();
    }

    //Nuestros Metodos Publicos

    //Metodos de Interfaces
    public void TakeDamage(float value)
    {
        throw new System.NotImplementedException();
    }

    public void Heal(float value)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    //Operadores

    //Nuestros Metodos Privados

    //Metodos Herdados override

    //Metodos virtual

    //Cosas raras que no sabemos usar XD..
}
