using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerBegin : MonoBehaviour
{
    public TextMeshProUGUI textmeshPro ;
    public string num;
    void Start()
    {
        textmeshPro.text = num+"";
    }
    
}
