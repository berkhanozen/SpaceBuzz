using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject UI;

    [SerializeField] private CharacterController _controller;


    [SerializeField] private LevelDistance _distance; // Ekosistem için eklendi
    [SerializeField] private Animator _anim; // Ekosistem için eklendi

    private void LateUpdate()
    {
        OxygenZero();
    }
    

    public void OxygenZero()
    {
        if (Oxygen.oxygenCylinder <= 0)
        {
            UI.SetActive(true);
            Time.timeScale = 1f;
            
            // Ekosistemi devam ettirmek için kullanýlanlar
            _controller.enabled = false;
            _distance.enabled = false;
            _anim.SetBool("run", false);
            _anim.SetBool("idle", true);
        }
    }
}
