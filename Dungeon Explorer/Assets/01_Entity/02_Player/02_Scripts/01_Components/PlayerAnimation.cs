using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation
{
    private Animator _playerAnimator;

    private bool _isWeaponEquiped;

    public bool IsWeaponEquiped
    {
        get
        {
            return _isWeaponEquiped;
        }

        set
        {
            _isWeaponEquiped = value;
        }
    }

    public PlayerAnimation(Animator playerAnimator)
    {
        _playerAnimator = playerAnimator;
    }

    public void WalkAnimation(float horizontalAxis, float verticalAxis, Vector3 mousePosition)
    {
        if (_isWeaponEquiped)
        {
            _playerAnimator.SetBool("WeaponEquiped", _isWeaponEquiped);
        }
        else
        {
            _playerAnimator.SetBool("WeaponEquiped", _isWeaponEquiped);
        }

        _playerAnimator.SetFloat("Horizontal", horizontalAxis);
        _playerAnimator.SetFloat("Vertical", verticalAxis);

        if (horizontalAxis != 0 || verticalAxis != 0)
        {
            _playerAnimator.SetBool("IsWalking", true);

            if (horizontalAxis > 0)
            {
                _playerAnimator.SetFloat("LastHorizontalMove", 1f);
            }
            else if (horizontalAxis < 0)
            {
                _playerAnimator.SetFloat("LastHorizontalMove", -1f);
            }
            else
            {
                _playerAnimator.SetFloat("LastHorizontalMove", 0f);
            }

            if (verticalAxis > 0)
            {
                _playerAnimator.SetFloat("LastVerticalMove", 1f);
            }
            else if (verticalAxis < 0)
            {
                _playerAnimator.SetFloat("LastVerticalMove", -1f);
            }
            else
            {
                _playerAnimator.SetFloat("LastVerticalMove", 0f);
            }
        }
        else
        {
            _playerAnimator.SetBool("IsWalking", false);
        }

        //Animation Look at mouse
        _playerAnimator.SetFloat("MouseHorizontalPosition", mousePosition.x);
        _playerAnimator.SetFloat("MouseVerticalPosition", mousePosition.y);
    }
}

