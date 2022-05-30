using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour {
    [Range(1.0f, 10.0f)]
    public float multiplierMax = 3f;
    Vector3 initialScale;

    void Start () {
        //Initial scale
        initialScale = transform.localScale;
        Generate();
    }

    public void Generate()
    {
        //Choose a random multiplied scale from the initial scale and the multiplierMax variable
        transform.localScale = initialScale * Random.Range(1f, multiplierMax);
    }
    
    void Update () {
		
	}
}
