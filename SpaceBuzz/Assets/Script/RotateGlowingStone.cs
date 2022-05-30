using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGlowingStone : MonoBehaviour
{
    [SerializeField] private float yRotateValue;
    private void Update()
    {
        transform.Rotate(new Vector3(0f,yRotateValue , 0) * Time.deltaTime);
    }
}
