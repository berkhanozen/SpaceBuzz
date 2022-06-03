using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introManager : MonoBehaviour
{
    private void Start()
    {

        if (PlayerPrefs.HasKey("HasDoneIntro"))
        {
            //SceneManager.LoadScene("Game");
            Invoke("LoadBase", 4f);
        }
        else
        {
            //SceneManager.LoadScene("Tutorial");
            Invoke("LoadIntro", 4f);
        }






    }
    void LoadIntro()
    {
        SceneManager.LoadScene(1);
    }
    void LoadBase()
    {
        SceneManager.LoadScene(2);
    }
}


