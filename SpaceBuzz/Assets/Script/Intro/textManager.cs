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
        texts[0].SetActive(false);
        texts[1].SetActive(false);
        texts[2].SetActive(false);
        texts[3].SetActive(false);
        texts[4].SetActive(false);


        



    }
    private void Update()
    {
        
        if (PlayOnce)
        {

            playFirstText(); // Ekranda durma süresi: 16sn, 9sn
                             //Invoke("playSecondText", 16f); //12f   13f  16f 16f Ekranda durma süresi: 29sn, 20sn
                             //Invoke("playThirdText", 40f);//22sn 36f  37f 40f 45f Ekranda durma süresi: 18sn, 15sn
                             //Invoke("playFourthText", 60f);//17sn 53f  55f 58f 63f Ekranda durma süresi: 13sn, 10sn
                             //Invoke("playFinalText", 73f);// 65f  68f 71f 76f 

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
    void playSecondText()
    {
        texts[0].SetActive(false);
        //Destroy(texts[0]);
        texts[1].SetActive(true);
    }
    void playThirdText()
    {
        texts[1].SetActive(false);
        //Destroy(texts[1]);
        texts[2].SetActive(true);
    }
    void playFourthText()
    {
        texts[2].SetActive(false);
        //Destroy(texts[2]);
        texts[3].SetActive(true);
    }
    void playFinalText()
    {
        texts[3].SetActive(false);
        //Destroy(texts[3]);
        texts[4].SetActive(true);
    }

    IEnumerator playSecondTextF()
    {
        
        yield return new WaitForSecondsRealtime(15);
        texts[0].SetActive(false);
        //Destroy(texts[0]);
        texts[1].SetActive(true);

    }

    IEnumerator playThirdTextF()
    {

        yield return new WaitForSecondsRealtime(50);
        texts[1].SetActive(false);
        //Destroy(texts[1]);
        texts[2].SetActive(true);

    }
    IEnumerator playFourthTextF()
    {

        yield return new WaitForSecondsRealtime(78);
        texts[2].SetActive(false);
        //Destroy(texts[2]);
        texts[3].SetActive(true);

    }
    IEnumerator playFinalTextF()
    {

        yield return new WaitForSecondsRealtime(97);
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
