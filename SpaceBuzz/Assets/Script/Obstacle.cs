using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject UI;

    [SerializeField] private CharacterController _controller;


    [SerializeField] private LevelDistance _distance; // Ekosistem i�in eklendi
    [SerializeField] private Animator _anim; // Ekosistem i�in eklendi
    [SerializeField] private GameObject _UIDistance; // Ekosistem i�in eklendi

    [SerializeField] private GameObject _UIScore;
    [SerializeField] private GameObject _UIOxygen;

    [SerializeField] private SkinnedMeshRenderer _skinned;

    private void LateUpdate()
    {
        OxygenZero();

        if (Input.GetKeyDown(KeyCode.H))
        {
            Oxygen.oxygenCylinder = 1;
        }
    }
    

    public void OxygenZero()
    {
        if (Oxygen.oxygenCylinder <= 0)
        {
            UI.SetActive(true);
            Time.timeScale = 1f;
            
            // Ekosistemi devam ettirmek i�in kullan�lanlar
            _controller.enabled = false;
            _distance.enabled = false;
            _anim.SetBool("run", false);
            _anim.SetBool("flip", true);
            _UIDistance.SetActive(false);
            _UIScore.SetActive(false);
            _UIOxygen.SetActive(false);

            StartCoroutine(skinmeshFalse());

        }
    }

    //Died Efekti
    private GameObject diedClonePickupEffect;
    public GameObject diedPickupEffect;
    private bool isDied = true;

    public void Pickup() // Pacticle Efect
    {
        diedClonePickupEffect = Instantiate(diedPickupEffect, transform.position, transform.rotation);
        Invoke("deleteParticle", 0.80f); // Clone Particle Destroy

    }

    void deleteParticle() // Clone Particle Destroy
    {
        Destroy(diedClonePickupEffect);
    }

    IEnumerator skinmeshFalse()
    {
        if (isDied)
        {
            isDied = false;
            yield return new WaitForSeconds(1f);
            Pickup();
            _skinned.enabled = false;
        }
    }
}
