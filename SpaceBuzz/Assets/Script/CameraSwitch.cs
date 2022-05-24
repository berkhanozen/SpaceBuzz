using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    Animator camAnim;
    bool isMainCam = true;
    public GameObject TapToStartText;
    public GameObject gameLogo;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            CameraChange();
            TapToStartText.SetActive(false);
            gameLogo.SetActive(false);
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
