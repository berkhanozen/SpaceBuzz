using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCameraFollow : MonoBehaviour
{

    public Transform basePlayerTransform;
    
    
    private void LateUpdate()
    {
        transform.position = new Vector3(basePlayerTransform.position.x, transform.position.y, basePlayerTransform.position.z - 10f);
    }
}
