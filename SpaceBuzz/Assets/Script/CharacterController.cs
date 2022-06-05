using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed;
    public float leftRightSpeed;

    [SerializeField] private Animator anim;


    private void Start()
    {
        anim.SetBool("run", true);
        Application.targetFrameRate = 120;
    }


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || MobileControl.leftMobileInput)
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                
            }
            
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || MobileControl.rightMobileInput)
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
            }
        }


    }
}
