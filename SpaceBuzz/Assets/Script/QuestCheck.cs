using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCheck : MonoBehaviour
{

    public GameObject distancequest1;
    public GameObject distancequest2;
    public GameObject distancequest3;
    public GameObject collectquest1;
    public GameObject collectquest2;
    public GameObject unlockPlanetQuest1;

    public bool quest1 = false;
    public bool quest2 = false;
    public bool quest3 = false;

    private bool isDone1 = false;
    private bool isDone2 = false;

    public GameObject Speeder2Reward;
    public InteractGarage _interactGarage;
    private void Start()
    {
        //GÖREV SIFIRLAMA
        //quest1 = false;
        //PlayerPrefs.SetInt("quest1", (quest1 ? 1 : 0));

        //quest2 = false;
        //PlayerPrefs.SetInt("quest1", (quest2 ? 1 : 0));

        //quest3 = false;
        //PlayerPrefs.SetInt("quest1", (quest3 ? 1 : 0));

        //TAŞ SIFIRLAMA
        //PlayerPrefs.SetInt("aytasi", 0);

    }
    private void Update()
    {
        
        if(PlayerPrefs.GetInt("quest1") != 0)
        {
            
            distancequest1.SetActive(false);
        }
        if (PlayerPrefs.GetInt("quest2") != 0)
        {

            distancequest2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("quest3") != 0)
        {

            distancequest3.SetActive(false);
        }

        if (PlayerPrefs.GetInt("aytasi") >= 100 && isDone1==false)
        {
           
            collectquest1.SetActive(false);
            isDone1 = true;
        }
        if (PlayerPrefs.GetInt("aytasi") >= 200 && isDone2==false)
        {
            
            collectquest2.SetActive(false);
            isDone2 = true;
        }

        if (PlayerPrefs.GetInt("isUnlockSecondPlanet") != 0)
        {
            unlockPlanetQuest1.SetActive(false);
            Speeder2Reward.SetActive(true);
            if (_interactGarage != null)
            {
                _interactGarage.speeder2ButtonActive = true;
                PlayerPrefs.SetInt("speeder2ButtonActive", (_interactGarage.speeder2ButtonActive ? 1 : 0));
            }
            
        }

        
    }

}
