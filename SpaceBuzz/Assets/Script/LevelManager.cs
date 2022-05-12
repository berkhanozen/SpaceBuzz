using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Score.totalscore = 0;
        Oxygen.oxygenCylinder = 100;
    }

    public void GoToBase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0");
    }
}
