using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private Transform _playerTransform;
    private float _playerMovementSpeed;

    private Vector2 _playerMovementInput;

    public PlayerMovement(Transform playerTransform, float playerMovementSpeed)
    {
        _playerTransform = playerTransform;
        _playerMovementSpeed = playerMovementSpeed;
    }

    public void SetPlayerMovementInput(float horizontalAxis, float verticalAxis)
    {
        _playerMovementInput = new Vector2(horizontalAxis, verticalAxis).normalized;
    }

    public void FixedMove()
    {
        _playerTransform.position += (_playerTransform.right * _playerMovementInput.x + _playerTransform.up * _playerMovementInput.y) * _playerMovementSpeed * Time.fixedDeltaTime;
    }
}
