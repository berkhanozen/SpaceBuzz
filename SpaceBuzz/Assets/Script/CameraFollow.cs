using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _transform;
    
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _transform.position.z);
    }
}
