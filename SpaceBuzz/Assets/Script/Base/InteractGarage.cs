using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGarage : MonoBehaviour
{
    public GameObject garageUI;
    public SpeederSelection _speederSelection;
    
    public bool speeder2ButtonActive;

    public GameObject speeder2Button;

    public QuestCheck _questCheck;

    private bool CallMeOnce = true;

    private void Start()
    {
        // Reset Garage
        //speeder2ButtonActive = false;
        //PlayerPrefs.SetInt("speeder2ButtonActive", (speeder2ButtonActive ? 1 : 0));
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("speeder1Selected") != 0)
        {
            _speederSelection.speeder1.SetActive(true);
            _speederSelection.speeder2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("speeder2Selected") != 0)
        {
            _speederSelection.speeder1.SetActive(false);
            _speederSelection.speeder2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("speeder2ButtonActive") != 0)
        {
            speeder2Button.SetActive(true);
        }

        if (PlayerPrefs.GetInt("isUnlockSecondPlanet") != 0)
        {
            _questCheck.unlockPlanetQuest1.SetActive(false);
            _questCheck.Speeder2Reward.SetActive(true);
            speeder2ButtonActive = true;
            PlayerPrefs.SetInt("speeder2ButtonActive", (speeder2ButtonActive ? 1 : 0));





        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (CallMeOnce == true)
        {
            garageUI.SetActive(true);
            CallMeOnce = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        garageUI.SetActive(false);
        CallMeOnce = true;
    }

    public void closeGarageUI()
    {
        garageUI.SetActive(false);
    }

    

    

    
}
