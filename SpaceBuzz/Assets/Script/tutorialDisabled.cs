using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialDisabled : MonoBehaviour
{

    private void Start()
    {
        // RESET
        //PlayerPrefs.DeleteKey("HasDoneMovementTutorial");

        if (PlayerPrefs.HasKey("HasDoneMovementTutorial"))
        {
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(disableTutorial());
            PlayerPrefs.SetString("HasDoneMovementTutorial", "done");
        }
    }

    IEnumerator disableTutorial()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);

    }
}
