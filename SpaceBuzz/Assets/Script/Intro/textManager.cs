using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textManager : MonoBehaviour
{
    public GameObject[] texts;
  
    private bool PlayOnce=true;

    private void Start()
    {
        Application.targetFrameRate = 30;

        texts[0].SetActive(false);
        texts[1].SetActive(false);
        texts[2].SetActive(false);
        texts[3].SetActive(false);
        texts[4].SetActive(false);


    }
    private void FixedUpdate()
    {
        
        if (PlayOnce)
        {

            playFirstText(); 

            StartCoroutine(playSecondTextF());
            StartCoroutine(playThirdTextF());
            StartCoroutine(playFourthTextF());
            StartCoroutine(playFinalTextF());

            PlayOnce = false;
            
        }


    }

    void playFirstText()
    {

        texts[0].SetActive(true);
    }
    

    IEnumerator playSecondTextF()
    {
        
        yield return new WaitForSeconds(7.5f);
        texts[0].SetActive(false);
        //Destroy(texts[0]);
        texts[1].SetActive(true);

    }

    IEnumerator playThirdTextF()
    {

        yield return new WaitForSeconds(23);
        texts[1].SetActive(false);
        //Destroy(texts[1]);
        texts[2].SetActive(true);

    }
    IEnumerator playFourthTextF()
    {

        yield return new WaitForSeconds(34);
        texts[2].SetActive(false);
        //Destroy(texts[2]);
        texts[3].SetActive(true);

    }
    IEnumerator playFinalTextF()
    {

        yield return new WaitForSeconds(41.5f);
        texts[3].SetActive(false);
        //Destroy(texts[3]);
        texts[4].SetActive(true);

    }


    public void loadBase()
    {
        PlayerPrefs.SetString("HasDoneIntro", "yes");
        SceneManager.LoadScene(2);
    }
    

}
