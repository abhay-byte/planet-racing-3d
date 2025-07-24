using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class gameUser : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InternetConnection;
    void Start()
    {
        UnityWebRequest request = new UnityWebRequest("http://www.google.com/");
        request.SendWebRequest(); 
        if (request.error == null)
        {
            InternetConnection.SetActive(false);
        }
        else
        {
            InternetConnection.SetActive(true);
        }        
    }
    void Awake()
    {

    }

    void Update()
    {

    }
}
