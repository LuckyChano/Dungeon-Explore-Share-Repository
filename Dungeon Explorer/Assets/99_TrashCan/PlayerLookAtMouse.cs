using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour
{
    private Vector3 _mousePosition;

    private Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        _mousePosition.z = this.transform.position.z;
        _mousePosition.Normalize();

        _playerAnimator.SetFloat("MouseHorizontalPosition", _mousePosition.x);
        _playerAnimator.SetFloat("MouseVerticalPosition", _mousePosition.y);
    }
}
