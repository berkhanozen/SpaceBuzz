using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Oxygen : MonoBehaviour
{
    
    public static float oxygenCylinder = 103;

    [SerializeField] private TextMeshProUGUI ioxygen;
    [SerializeField] private GameObject ioxygenEnable;

    private void Start()
    {
        //ioxygen.enabled = false;
        //ioxygenEnable.SetActive(false);
        InvokeRepeating("oxygenSystem", 0.0f, 4f);
    }

    private void Update()
    {
        oxygenCylinder = Mathf.Clamp(oxygenCylinder, 0, 100);
        ioxygen.text = oxygenCylinder.ToString();
    }

    public void oxygenSystem()
    {
        oxygenCylinder -= 3;
        ioxygen.text = oxygenCylinder.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Oxygen1"))
        {
            oxygenCylinder += 5;
            Destroy(other.gameObject);
        }

        //if (other.gameObject.CompareTag("Engel"))
        //{
        //    StartCoroutine(denemee());
        //    deneme();
        //}
    }

    //void deneme()
    //{
    //    if (ioxygen.enabled = true)
    //    {
    //        ioxygen.enabled = true;
    //        ioxygenEnable.SetActive(true);
    //        InvokeRepeating("oxygenSystem", 0.0f, 4f);
    //    }
    //}

    //IEnumerator denemee()
    //{
    //    yield return new WaitForSeconds(4f);
    //    ioxygen.enabled = true;
    //    ioxygenEnable.SetActive(true);
    //    InvokeRepeating("oxygenSystem", 0.0f, 4f);
    //}
}
