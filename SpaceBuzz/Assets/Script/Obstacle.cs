using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject UI;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Engel")
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
