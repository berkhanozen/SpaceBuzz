using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDistance : MonoBehaviour
{

    public int Idistance = 1;

    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI gameOverDistance;
    [SerializeField] private CharacterController _controller;

    [SerializeField] private QuestCheck _questcheck;

    private void Start()
    {
        InvokeRepeating("calculateDistance", 0.0f, 0.4f);
        distance.text = "0";
    }

    private void FixedUpdate()
    {
        gameOverDistance.text = "Gidilen Mesafe: " + Idistance.ToString();
    }

    public void calculateDistance()
    {
        Idistance++;
        distance.text = Idistance.ToString();

        if (Idistance == 30)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 80)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 120)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 180)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 240)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 350)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 450)
        {
            _controller.moveSpeed += 2;
            _controller.leftRightSpeed += 1;
        }

        if (Idistance == 500)
        {
            _controller.moveSpeed += 2;
            _questcheck.quest1 = true;
            PlayerPrefs.SetInt("quest1", (_questcheck.quest1 ? 1 : 0));

        }

        if (Idistance == 550)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 600)
        {
            _controller.moveSpeed += 2;
        }

        if (Idistance == 700)
        {
            _controller.moveSpeed += 1;
            _controller.leftRightSpeed += 1;
        }

        if (Idistance == 1000)
        {
            _questcheck.quest2 = true;
            PlayerPrefs.SetInt("quest2", (_questcheck.quest2 ? 1 : 0));
        }

        if (Idistance == 2000)
        {
            _questcheck.quest3 = true;
            PlayerPrefs.SetInt("quest3", (_questcheck.quest3 ? 1 : 0));
        }
    }
}
