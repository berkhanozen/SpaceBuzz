using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed;
    public float leftRightSpeed;

    [SerializeField] private Animator anim;
    [SerializeField] private Vector2 verticalLimit = new Vector2(-2, 2);

    private Vector2 direction;
    
    private void Start()
    {
        anim.SetBool("run", true);
        Application.targetFrameRate = 120;
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
        TouchSimulation.Disable();
    }

    private void Update()
    {
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);

        var activeTouches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;

        foreach (var touch in activeTouches)
        {
            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            {
                direction = touch.delta;
                Move();
            }
        }
    }

    void Move()
    {
        var newXPos = transform.position.x + leftRightSpeed * direction.x * Time.deltaTime;
        newXPos = Mathf.Clamp(newXPos, verticalLimit.x, verticalLimit.y);
        transform.position = new Vector3(newXPos, transform.position.y, transform.position.z);
    }

}
