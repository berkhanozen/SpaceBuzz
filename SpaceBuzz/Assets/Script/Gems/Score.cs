using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    
    public static int aytasi;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI gameOverScoretext;

    private GameObject clonePickupEffect; // Clone Particle Destroy

    public GameObject pickupEffect; // Pacticle Efect
    private void Start()
    {
        
        if (PlayerPrefs.HasKey("aytasi"))
        {
            aytasi = PlayerPrefs.GetInt("aytasi");
            scoretext.text = aytasi.ToString();
        }
    }
    private void Update()
    {
        scoretext.text = aytasi.ToString();
        

        scoretext.text = "Toplanan Ay Taþý: " + aytasi.ToString();
        gameOverScoretext.text = "Toplanan Ay Taþý: " + aytasi.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Puan"))
        {
            Destroy(other.gameObject);
            aytasi++;
            PlayerPrefs.SetInt("aytasi", aytasi);
            scoretext.text = aytasi.ToString();

            Pickup(); // Pacticle Efect
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
