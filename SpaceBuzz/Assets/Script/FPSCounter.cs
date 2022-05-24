using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpstext;

    private void Update()
    {
        
        fpstext.text = (1f / Time.deltaTime).ToString();
    }
}
