using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDistance : MonoBehaviour
{

    public int Idistance = 1;

    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private CharacterController _controller;

    private void Start()
    {
        InvokeRepeating("calculateDistance", 0.0f, 0.4f);
    }

    private void FixedUpdate()
    {
        distance.text = Idistance.ToString();
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
    }
}
