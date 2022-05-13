using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleGotoBaseFix : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
}
