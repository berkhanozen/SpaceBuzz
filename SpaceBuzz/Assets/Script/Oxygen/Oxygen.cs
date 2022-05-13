using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Oxygen : MonoBehaviour
{

    public static float oxygenCylinder = 500;

    [SerializeField] private TextMeshProUGUI ioxygen;
    [SerializeField] private GameObject ioxygenEnable;

    [SerializeField] private Oxygen oxygenScript;

    private void Awake()
    {
        oxygenScript.enabled = false;
    }

    private void Start()
    {
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
            Pickup();

        }

        if (other.gameObject.CompareTag("Engel"))
        {
            ioxygenEnable.SetActive(true);
            oxygenScript.enabled = true;
            oxygenCylinder -= 10;
            Destroy(other.gameObject);
        }
    }

    //Oksijen Toplama Efekti
    private GameObject oxClonePickupEffect;
    public GameObject oxPickupEffect;

    public void Pickup() // Pacticle Efect
    {
        oxClonePickupEffect = Instantiate(oxPickupEffect, transform.position, transform.rotation);
        Invoke("deleteParticle", 0.40f); // Clone Particle Destroy

    }

    void deleteParticle() // Clone Particle Destroy
    {
        Destroy(oxClonePickupEffect);
    }
}
