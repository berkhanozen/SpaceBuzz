using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileControl : MonoBehaviour
{
    public static bool leftMobileInput;
    public static bool rightMobileInput;

    public void OnLeftPointerDown()
    {
        leftMobileInput = true;
    }

    public void OnLeftPointerUp()
    {
        leftMobileInput = false;
    }

    public void OnRightPointerDown()
    {
        rightMobileInput = true;
    }

    public void OnRightPointerUp()
    {
        rightMobileInput = false;
    }
}
