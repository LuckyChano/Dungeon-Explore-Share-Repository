using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed;

    //private Rigidbody2D _playerRb;
    private Animator _playerAnimator;
    private Vector2 _playerMoveInput;

    void Start()
    {
        //_playerRb = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
        _playerMoveInput = new Vector2(horizontalAxis, verticalAxis).normalized;

        _playerAnimator.SetFloat("Horizontal", horizontalAxis);
        _playerAnimator.SetFloat("Vertical", verticalAxis);
        _playerAnimator.SetFloat("Speed", _playerMoveInput.sqrMagnitude);

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


    }

    void FixedUpdate()
    {
        //_playerRb.MovePosition(_playerRb.position + _playerMoveInput * _playerSpeed * Time.fixedDeltaTime);

        transform.position += (transform.right * _playerMoveInput.x + transform.up * _playerMoveInput.y) * _playerSpeed * Time.fixedDeltaTime;
    }
}
