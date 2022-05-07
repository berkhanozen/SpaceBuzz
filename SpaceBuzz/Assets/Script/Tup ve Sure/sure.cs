using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Sure : MonoBehaviour
{
    public int times = 3;
    private KarakterKontrol _kontrol;
    private Animator _anim;

    [SerializeField] private TextMeshProUGUI timesure;

    private void Start()
    {
        InvokeRepeating("zamaniazalt", 0.0f, 1.0f);
    }

    private void Awake()                                                   
    {
        _anim = GetComponent<Animator>();
        _kontrol = GetComponent<KarakterKontrol>();
    }

    private void Update()
    {
        timesure.text= times.ToString(); 

        timesure.text = "Baslamasina " + times.ToString() + " Saniye";
    }

    public void zamaniazalt()
    {
        _kontrol.enabled = false;
        times--;
        timesure.text = times.ToString();

        if (times == 0)
        {
            _kontrol.enabled = true;
            _anim.SetBool("run", true);
            CancelInvoke("zamaniazalt");
            timesure.enabled = false;
        }
    }
}
