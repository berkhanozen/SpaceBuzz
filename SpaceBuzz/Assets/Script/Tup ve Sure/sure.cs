using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sure : MonoBehaviour
{

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
        timesure.text= time.times.ToString();

        timesure.text = "Baslamasina " + time.times.ToString() + " Saniye";
    }

    public void zamaniazalt()
    {
        _kontrol.enabled = false;
        time.times--;
        timesure.text = time.times.ToString();

        if (time.times == 0)
        {
            _kontrol.enabled = true;
            _anim.SetBool("run", true);
            CancelInvoke("zamaniazalt");
            timesure.enabled = false;
        }
    }
}
