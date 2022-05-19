using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RocketInteract : MonoBehaviour
{
    [SerializeField] private GameObject RocketCanvas;
    [SerializeField] private TextMeshProUGUI AyTasiText;
    private void Start()
    {
        if (PlayerPrefs.HasKey("aytasi"))
        {
            Score.aytasi = PlayerPrefs.GetInt("aytasi");
        }
    }
    private void Update()
    {
        AyTasiText.text = "Toplanan Ay Taşı: " + Score.aytasi.ToString();
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
