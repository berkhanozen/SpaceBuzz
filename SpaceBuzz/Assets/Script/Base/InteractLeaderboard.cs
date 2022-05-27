using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLeaderboard : MonoBehaviour
{
    public GameObject leaderboardUI;

    private void OnTriggerStay(Collider other)
    {
        leaderboardUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        leaderboardUI.SetActive(false);
    }
}
