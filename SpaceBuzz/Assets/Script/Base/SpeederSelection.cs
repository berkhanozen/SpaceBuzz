using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederSelection : MonoBehaviour
{
    public GameObject speeder1;
    public GameObject speeder2;

    private bool speeder1Selected;
    private bool speeder2Selected;

    private void Update()
    {
        
    }
    public void selectSpeeder1()
    {
        speeder1.SetActive(true);
        speeder2.SetActive(false);
        speeder1Selected = true;
        speeder2Selected = false;
        PlayerPrefs.SetInt("speeder1Selected", (speeder1Selected ? 1 : 0));
        PlayerPrefs.SetInt("speeder2Selected", (speeder2Selected ? 1 : 0));
    }
    public void selectSpeeder2()
    {
        speeder1.SetActive(false);
        speeder2.SetActive(true);
        speeder2Selected = true;
        speeder1Selected = false;
        PlayerPrefs.SetInt("speeder2Selected", (speeder2Selected ? 1 : 0));
        PlayerPrefs.SetInt("speeder1Selected", (speeder1Selected ? 1 : 0));
    }
}
