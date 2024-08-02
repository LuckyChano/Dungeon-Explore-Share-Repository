using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtMouse : MonoBehaviour
{
    private Vector3 _newPositionVector;

    void Update()
    {
        _newPositionVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        _newPositionVector.z = this.transform.position.z;
        this.transform.right = _newPositionVector;
    }
}
