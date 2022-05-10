using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Oxygen : MonoBehaviour
{
    
    [SerializeField] private float oxygenCylinder = 103;

    [SerializeField] private TextMeshProUGUI ioxygen;

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
        }
    }
}
