using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Oxygen OxygenScriptEnable;
    public AdsManager ads;

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Oxygen.isDamaged = false;
        OxygenScriptEnable.enabled = false;
        Score.aytasi = 0;
        Oxygen.oxygenCylinder = 500;
        ads.OnDestroy();
    }

    public void GoToBase()
    {
        ads.OnDestroy();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
}
