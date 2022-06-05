using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtText : MonoBehaviour
{
    public Transform[] texts;

   
    void Update()
    {
        //text.transform.LookAt(text.position - transform.position);

        texts[0].transform.rotation = Quaternion.LookRotation((texts[0].position - transform.position).normalized);
        texts[1].transform.rotation = Quaternion.LookRotation((texts[1].position - transform.position).normalized);
        texts[2].transform.rotation = Quaternion.LookRotation((texts[2].position - transform.position).normalized);
        texts[3].transform.rotation = Quaternion.LookRotation((texts[3].position - transform.position).normalized);



    }
}
