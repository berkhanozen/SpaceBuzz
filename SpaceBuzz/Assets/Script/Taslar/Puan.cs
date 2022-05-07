using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Puan : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoretext;

    private void Update()
    {
        scoretext.text = score.totalscore.ToString();

        scoretext.text = "Toplanan Tas: " + score.totalscore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Puan"))
        {

            Destroy(other.gameObject);
            score.totalscore++;
            scoretext.text = score.totalscore.ToString();
        }
    }
}
