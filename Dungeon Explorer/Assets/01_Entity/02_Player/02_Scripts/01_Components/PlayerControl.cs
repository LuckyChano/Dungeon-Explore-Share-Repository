using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl
{
    private Transform _playerTransform;
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;
    private Weapon _playerWeapon;

    private float _horizontalAxis;
    private float _verticalAxis;
    private string _horizontalAxisName = "Horizontal";
    private string _verticalAxisName = "Vertical";
    private Vector3 _mousePosition;

    public PlayerControl(Transform playerTransform, PlayerMovement playerMovement, PlayerAnimation playerAnimation, Weapon playerWeapon)
    {
        _playerTransform = playerTransform;
        _playerMovement = playerMovement;
        _playerAnimation = playerAnimation;
        _playerWeapon = playerWeapon;
    }

    public void ArtificialUpdate()
    {
        _horizontalAxis = Input.GetAxisRaw(_horizontalAxisName);
        _verticalAxis = Input.GetAxisRaw(_verticalAxisName);

        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _playerTransform.transform.position;
        _mousePosition.z = _playerTransform.transform.position.z;
        _mousePosition.Normalize();

        _playerMovement.SetPlayerMovementInput(_horizontalAxis, _verticalAxis);
        _playerAnimation.WalkAnimation(_horizontalAxis, _verticalAxis, _mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _playerWeapon.Shoot();
        }
    }

    public void ArtificialFixedUpdate()
    {
        _playerMovement.FixedMove();
    }
}
