using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MusicFilesNM;

public class Obstacle : MonoBehaviour
{
    private GameObject sound;
    private MusicFiles deathSound; // Ölüm ses efekti
    [SerializeField] private int deathSoundIndex;

    [SerializeField] GameObject UI;

    [SerializeField] private CharacterController _controller;

    [SerializeField] private LevelDistance _distance; // Ekosistem için eklendi
    [SerializeField] private Animator _anim; // Ekosistem için eklendi
    [SerializeField] private GameObject _UIDistance; // Ekosistem için eklendi

    [SerializeField] private GameObject _UIScore;
    [SerializeField] private GameObject _UIOxygen;
    [SerializeField] private GameObject _UIleftbutton;
    [SerializeField] private GameObject _UIrightbutton;
    [SerializeField] private GameObject _UIpausebutton;

    [SerializeField] private SkinnedMeshRenderer _skinned;

    private void Awake()
    {
        sound = GameObject.Find("AudioManager");
        deathSound = sound.GetComponent(typeof(MusicFiles)) as MusicFiles;
    }
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
            
            // Ekosistemi devam ettirmek için kullanýlanlar
            _controller.enabled = false;
            _distance.enabled = false;
            _anim.SetBool("run", false);
            _anim.SetBool("flip", true);
            _UIDistance.SetActive(false);
            _UIScore.SetActive(false);
            _UIOxygen.SetActive(false);
            _UIleftbutton.SetActive(false);
            _UIrightbutton.SetActive(false);
            _UIpausebutton.SetActive(false);

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
            AudioSource.PlayClipAtPoint(deathSound.audioClipList[deathSoundIndex], gameObject.transform.position);
        }
    }
}
