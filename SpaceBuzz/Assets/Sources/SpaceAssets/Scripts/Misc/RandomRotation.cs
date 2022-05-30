using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {
    //The rotation speed of the object
    public float rotationSpeedMax = 35f;
    float rotationSpeed;
    //Set whether the rotation speed should be randomized or not
    public bool randomize = true;

	void Start () {
        Generate();
    }

    //Assign a new speed for the rotation
    public void Generate()
    {
        if (randomize)
        {
            //Select randomly if the rotation is clockwise or counterclockwise and assign a random speed
            rotationSpeed = (Random.Range(0, 100) < 50 ? -1f : 1f) * Random.Range(0f, rotationSpeedMax);
        }
        else
        {
            rotationSpeed = rotationSpeedMax;
        }
    }
	
	void Update () {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
