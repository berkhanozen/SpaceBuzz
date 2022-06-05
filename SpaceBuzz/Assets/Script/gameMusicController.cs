using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMusicController : MonoBehaviour
{
    [SerializeField] GameObject disabledGameSoundIcon;
    [SerializeField] GameObject enabledGameSoundIcon;
    [SerializeField] AudioSource _audioSource;

    private bool isMusicOpen;
    private void Start()
    {
        if (PlayerPrefs.HasKey("isMusicOpen"))
        {
            if (PlayerPrefs.GetInt("isMusicOpen") != 0) //True
            {
                enabledGameSoundIcon.SetActive(true);
                disabledGameSoundIcon.SetActive(false);
                _audioSource.Play();
            }
            if (PlayerPrefs.GetInt("isMusicOpen") != 1) //False
            {
                enabledGameSoundIcon.SetActive(false);
                disabledGameSoundIcon.SetActive(true);
                _audioSource.Stop();
            }
        }
        else
        {
            _audioSource.Play();
        }
        

    }

    public void enableGameSound()
    {
        enabledGameSoundIcon.SetActive(false);
        disabledGameSoundIcon.SetActive(true);
        //_audioSource.Stop();
        isMusicOpen = false;
        PlayerPrefs.SetInt("isMusicOpen", (isMusicOpen ? 1 : 0));
    }

    public void disableGameSound()
    {
        enabledGameSoundIcon.SetActive(true);
        disabledGameSoundIcon.SetActive(false);
        //_audioSource.Play();
        isMusicOpen = true;
        PlayerPrefs.SetInt("isMusicOpen", (isMusicOpen ? 1 : 0));
    }
}
