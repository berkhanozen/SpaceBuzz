using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class InteractRocket : MonoBehaviour
{
    [SerializeField] private GameObject RocketCanvas;
    [SerializeField] private TextMeshProUGUI aytasitext;
    [SerializeField] private GameObject SecondPlanetButton;
    [SerializeField] private GameObject SecondPlanetUnlockButton;
    [SerializeField] private GameObject Uyari1;

    [SerializeField] Oxygen OxygenScriptEnable;

    private bool isUnlockSecondPlanet;
    private void Start()
    {
        // Seviye kilit sıfırlama 
        //isUnlockSecondPlanet = false;
        //PlayerPrefs.SetInt("isUnlockSecondPlanet", (isUnlockSecondPlanet ? 1 : 0));

        isUnlockSecondPlanet = (PlayerPrefs.GetInt("isUnlockSecondPlanet") != 0);
        Debug.Log("İkinci seviye açık" + isUnlockSecondPlanet);
    }
    private void Update()
    {
        Score.aytasi = PlayerPrefs.GetInt("aytasi");
        aytasitext.text = "Toplanan Luna Tasi: " + Score.aytasi.ToString();

        if(isUnlockSecondPlanet == true)
        {
            SecondPlanetUnlockButton.SetActive(false);
            SecondPlanetButton.SetActive(true);
        }
        
    }

    public void playMoon()
    {
        
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Oxygen.isDamaged = false;
        OxygenScriptEnable.enabled = false;
        Oxygen.oxygenCylinder = 500;
    }

    public void playSecondPlanet()
    {
        SceneManager.LoadScene(2);
    }

    public void unlockSecondPlanet()
    {
        if (Score.aytasi >= 20 && isUnlockSecondPlanet==false)
        {
            Score.aytasi = Score.aytasi - 20;
            PlayerPrefs.SetInt("aytasi", Score.aytasi);
            isUnlockSecondPlanet = true;
            PlayerPrefs.SetInt("isUnlockSecondPlanet", (isUnlockSecondPlanet ? 1 : 0));

            SecondPlanetUnlockButton.SetActive(false);
            SecondPlanetButton.SetActive(true);
            Debug.Log("2. gezegenin kilidini açtın");
            Debug.Log(isUnlockSecondPlanet);
        }
        else if(Score.aytasi<20)
        {
            Uyari1.SetActive(true);
            Invoke("Uyari1MessageDelete", 2f);
 
        }

    }

    public void Uyari1MessageDelete()
    {
        
        Uyari1.SetActive(false);
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
