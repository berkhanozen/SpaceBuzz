using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLeaderboard : MonoBehaviour
{
    public GameObject leaderboardUI;
    private bool CallMeOnce=true;

    private void OnTriggerStay(Collider other)
    {
        if (CallMeOnce == true)
        {
            leaderboardUI.SetActive(true);
            CallMeOnce = false;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        leaderboardUI.SetActive(false);
        CallMeOnce = true;
    }

    public void closeLeaderboardUI()
    {
        leaderboardUI.SetActive(false);
    }
}
