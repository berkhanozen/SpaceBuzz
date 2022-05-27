using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    

    public void StoreName()
    {
        theName = inputField.GetComponent<TextMeshProUGUI>().text;
        PlayerPrefs.SetString("playerName", theName);
        Debug.Log(PlayerPrefs.GetString("playerName"));
    }
}
