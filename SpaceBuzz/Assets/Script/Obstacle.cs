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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Engel")
        {
            // Oxygen.oxygenCylinder -= 10;
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
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
