using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Oxygen OxygenScriptEnable;

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OxygenScriptEnable.enabled = false;
        Score.totalscore = 0;
        Oxygen.oxygenCylinder = 500;
    }

    public void GoToBase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0");
    }
}
