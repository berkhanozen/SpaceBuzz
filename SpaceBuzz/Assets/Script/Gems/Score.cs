using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    
    public static int totalscore;
    [SerializeField] private TextMeshProUGUI scoretext;
    [SerializeField] private TextMeshProUGUI gameOverScoretext;

    private GameObject clonePickupEffect; // Clone Particle Destroy

    public GameObject pickupEffect; // Pacticle Efect

    private void Update()
    {
        scoretext.text = totalscore.ToString();
        

        scoretext.text = "Toplanan Tas: " + totalscore.ToString();
        gameOverScoretext.text = "Toplanan Tas: " + totalscore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Puan"))
        {
            Destroy(other.gameObject);
            totalscore++;
            scoretext.text = totalscore.ToString();

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
