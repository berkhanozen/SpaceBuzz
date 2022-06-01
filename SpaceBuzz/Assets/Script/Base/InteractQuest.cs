using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractQuest : MonoBehaviour
{
    public GameObject questUI;
    private bool CallMeOnce = true;

    private void OnTriggerStay(Collider other)
    {
        if (CallMeOnce == true)
        {
            questUI.SetActive(true);
            CallMeOnce = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        questUI.SetActive(false);
        CallMeOnce = true;
    }

    public void closeQuestUI()
    {
        questUI.SetActive(false);
    }
}
