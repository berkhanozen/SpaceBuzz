using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject UI;
 
    private void LateUpdate()
    {
        OxygenZero();
    }
    

    public void OxygenZero()
    {
        if (Oxygen.oxygenCylinder <= 0)
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
