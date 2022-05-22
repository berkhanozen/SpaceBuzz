using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    private Animator anim;
    private UnityEngine.CharacterController controller;


    public float speed = 600.0f;
    public float turnSpeed = 400.0f;
    public float xRange1 = 105.0f;
    public float xRange2 = 170.0f;
    public float zRange1 = 150.0f;
    public float zRange2 = 95.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    public FloatingJoystick floatingJoystick;
    private bool playMoveAnim;

    void Start()
    {
        controller = GetComponent<UnityEngine.CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(floatingJoystick.Vertical != 0 || floatingJoystick.Horizontal != 0)
        {
            playMoveAnim = true;
        }
        else
        {
            playMoveAnim = false;
        }
        
        if (playMoveAnim)
        {
            anim.SetInteger("AnimationPar", 1);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }

        if (controller.isGrounded)
        {
            //moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            moveDirection = transform.forward * floatingJoystick.Vertical * speed;
        }

        //float turn = Input.GetAxis("Horizontal");
        float turn = floatingJoystick.Horizontal;
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

        // Karakter sýnýrlarý
        if (transform.position.x < xRange1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zRange1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (transform.position.z < zRange2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
