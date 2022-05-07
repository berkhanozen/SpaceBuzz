using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Puan : MonoBehaviour
{

    public static int totalscore;
    [SerializeField] private TextMeshProUGUI scoretext;

    private void Update()
    {
        scoretext.text = totalscore.ToString();

        scoretext.text = "Toplanan Tas: " + totalscore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Puan"))
        {

            Destroy(other.gameObject);
            totalscore++;
            scoretext.text = totalscore.ToString();
        }
    }
}
