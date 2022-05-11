using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Duration : MonoBehaviour
{
    public int times = 3;
    private CharacterController _controller;
    private Animator _anim;

    [SerializeField] private LevelDistance distanceScript;

    [SerializeField] private GameObject distanceEnable;

    [SerializeField] private GameObject tempDistanceEnable;

    [SerializeField] private TextMeshProUGUI timeText;

    private void Start()
    {
        distanceEnable.SetActive(false);
        tempDistanceEnable.SetActive(true);
        distanceScript.Idistance = 0;
        InvokeRepeating("decreaseTime", 0.0f, 1.0f);
    }

    private void Awake()                                                   
    {
        _anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        timeText.text= times.ToString();

        timeText.text = "Baslamasina " + times.ToString() + " Saniye";
    }

    public void decreaseTime()
    {
        _controller.enabled = false;
        times--;
        timeText.text = times.ToString();

        if (times == 0)
        {
            _controller.enabled = true;
            _anim.SetBool("run", true);
            CancelInvoke("decreaseTime");
            timeText.enabled = false;

            distanceScript.Idistance = 0;

            tempDistanceEnable.SetActive(false);
            distanceEnable.SetActive(true);

        }
    }
}
