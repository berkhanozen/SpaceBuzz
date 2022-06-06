using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MusicFilesNM;

public class Oxygen : MonoBehaviour
{

    public static float oxygenCylinder = 500;

    private GameObject sound;
    private MusicFiles oxygenCollectingSound;   
    private MusicFiles crashingSound;       // Oksijen toplama ve çarpma ses efektleri
    [SerializeField] private int oxygenSoundIndex;
    [SerializeField] private int obstacleSoundIndex;

    [SerializeField] private TextMeshProUGUI ioxygen;
    [SerializeField] private GameObject ioxygenEnable;

    [SerializeField] private Oxygen oxygenScript;

    [SerializeField] private CameraShake mainCamera;

    public static bool isDamaged=false;

    

    private void Awake()
    {
        oxygenScript.enabled = false;

        sound = GameObject.Find("AudioManager");
        oxygenCollectingSound = sound.GetComponent(typeof(MusicFiles)) as MusicFiles;
        crashingSound = sound.GetComponent(typeof(MusicFiles)) as MusicFiles;
    }

    private void Start()
    {
        InvokeRepeating("oxygenSystem", 0.0f, 4f);
        mainCamera = FindObjectOfType<CameraShake>();
    }

    private void Update()
    {
        oxygenCylinder = Mathf.Clamp(oxygenCylinder, 0, 100);
        ioxygen.text = oxygenCylinder.ToString();
    }

    public void oxygenSystem()
    {
        oxygenCylinder -= 3;
        ioxygen.text = oxygenCylinder.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Oxygen1"))
        {
            oxygenCylinder += 5;
            Destroy(other.gameObject);
            Pickup();
            AudioSource.PlayClipAtPoint(oxygenCollectingSound.audioClipList[oxygenSoundIndex], gameObject.transform.position);
        }

        if (other.gameObject.CompareTag("Engel"))
        {

            ioxygenEnable.SetActive(true);
            oxygenScript.enabled = true;
            oxygenCylinder -= 10;
            Destroy(other.gameObject);
            obstacleEffect();
            AudioSource.PlayClipAtPoint(crashingSound.audioClipList[obstacleSoundIndex], gameObject.transform.position);
            isDamaged = true;
        }
    }

    //Oksijen Toplama Efekti
    private GameObject oxClonePickupEffect;
    public GameObject oxPickupEffect;

    public void Pickup() // Pacticle Efect
    {
        oxClonePickupEffect = Instantiate(oxPickupEffect, transform.position, transform.rotation);
        Invoke("deleteParticle", 0.40f); // Clone Particle Destroy

    }

    void deleteParticle() // Clone Particle Destroy
    {
        Destroy(oxClonePickupEffect);
    }

    // Engele Çarpma Efekti
    private GameObject obstacleClonePickupEffect;
    public GameObject obstaclePickupEffect;

    public void obstacleEffect() // Pacticle Efect
    {
        obstacleClonePickupEffect = Instantiate(obstaclePickupEffect, transform.position, transform.rotation);
        StartCoroutine(mainCamera.Shaking());
        Invoke("deleteObstacleParticle", 0.80f); // Clone Particle Destroy
    }

    void deleteObstacleParticle() // Clone Particle Destroy
    {
        Destroy(obstacleClonePickupEffect);
    }  
}
