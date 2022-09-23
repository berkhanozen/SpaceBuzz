using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private Animator anim;


    private void Start()
    {
        anim.SetBool("run", true);
        Application.targetFrameRate = 120;
    }

    
    public float moveSpeed;
    public float leftRightSpeed;

    private Vector3 _touchDown;
    private Vector3 _touchUp;


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
            if (touch.began)
            {
                _touchDown = touch.screenPosition;
                _touchUp = touch.startScreenPosition;
            }
            else if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
            {
                _touchDown = touch.screenPosition;

                if ((gameObject.transform.position.x > LevelBoundary.leftSide) && (gameObject.transform.position.x < LevelBoundary.rightSide))
                {
                    transform.Translate(CalculateDirection() * leftRightSpeed * Time.deltaTime, 0, 0);
                }
                else if (gameObject.transform.position.x < LevelBoundary.leftSide)
                {
                    if (CalculateDirection() > 0)
                    {
                        transform.Translate(CalculateDirection() * leftRightSpeed * Time.deltaTime, 0, 0);
                    }
                }
                else if (gameObject.transform.position.x > LevelBoundary.rightSide)
                {
                    if (CalculateDirection() < 0)
                    {
                        transform.Translate(CalculateDirection() * leftRightSpeed * Time.deltaTime, 0, 0);
                    }
                }
            }
            else if (touch.phase == UnityEngine.InputSystem.TouchPhase.Stationary)
            {
                _touchUp = touch.screenPosition;
            }
            else if (touch.ended)
            {
                _touchDown = Vector3.zero;
                _touchUp = Vector3.zero;
            }
        }
    }


    float CalculateDirection()
    {
        Vector3 temp = (_touchDown - _touchUp).normalized;
        float tempX = temp.x;
        return tempX;
    }

}
