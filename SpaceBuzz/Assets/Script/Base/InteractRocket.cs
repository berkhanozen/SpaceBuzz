using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class InteractRocket : MonoBehaviour
{
    [SerializeField] private GameObject RocketCanvas;
    [SerializeField] private TextMeshProUGUI aytasitext;

    private void Update()
    {
        Score.aytasi = PlayerPrefs.GetInt("aytasi");
        aytasitext.text = "Toplanan Ay Taþý: " + Score.aytasi.ToString();
    }

    public void playMoon()
    {
        SceneManager.LoadScene(1);

    }


    private void OnTriggerStay(Collider other)
    {
        RocketCanvas.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        RocketCanvas.SetActive(false);
    }
}
