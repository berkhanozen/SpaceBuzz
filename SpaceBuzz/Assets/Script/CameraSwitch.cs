using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    Animator camAnim;
    bool isMainCam = true;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraChange();
        }
    }

    void CameraChange()
    {
        if (isMainCam)
        {
            camAnim.Play("ThirdPerson");
        }
        else
        {
            camAnim.Play("DollyTrack");
        }
        //isMainCam = !isMainCam;
    }
}
