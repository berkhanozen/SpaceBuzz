using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using MusicFilesNM;

public class ScoreUTA : MonoBehaviour
{
    public static int utatasi;

    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI gameOverScoretext;

    private GameObject clonePickupEffect; // Clone Particle Destroy

    public GameObject pickupEffect; // Pacticle Efect

    private GameObject sound;
    private MusicFiles gemCollectingSound;  // Elmas toplama ses efekti
    [SerializeField] private int gemSoundIndex;

    private void Awake()
    {
        sound = GameObject.Find("AudioManager");
        gemCollectingSound = sound.GetComponent(typeof(MusicFiles)) as MusicFiles;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("utatasi"))
        {
            utatasi = PlayerPrefs.GetInt("utatasi");
            scoretext.text = utatasi.ToString();
        }
    }

    private void Update()
    {
        scoretext.text = utatasi.ToString();
        scoretext.text = utatasi.ToString();
        gameOverScoretext.text = "Toplanan Uta Tasi: " + utatasi.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PuanUTA"))
        {
            Destroy(other.gameObject);
            utatasi++;
            PlayerPrefs.SetInt("utatasi", utatasi);
            scoretext.text = utatasi.ToString();
            Pickup(); // Pacticle Efect

            AudioSource.PlayClipAtPoint(gemCollectingSound.audioClipList[gemSoundIndex], gameObject.transform.position);
        }
    }

    public void Pickup() // Pacticle Efect
    {
        clonePickupEffect = Instantiate(pickupEffect, transform.position, transform.rotation);
        Invoke("deleteParticle", 0.40f); // Clone Particle Destroy
    }

    void deleteParticle() // Clone Particle Destroy
    {
        Destroy(clonePickupEffect);
    }
}
