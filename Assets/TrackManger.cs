using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackManger : MonoBehaviour
{

    public GameObject AiCars;
    public GameObject mycar;
    public Text car1;
    public Text car2;
    public Text car3;
    public Text car4;//user

    public Text name1;
    public Text name2;
    public Text name3;
    public Text name4;//user

    string Name1;
    string Name2;
    string Name3;
    string Name4;
    public GameObject UI;

    void Start()
    {
        Name1 = name1.text;
        Name2 = name2.text;
        Name3 = name3.text;
        Name4 = name4.text;
        StartCoroutine(StartR());  
    }
    IEnumerator StartR()
    {
        UI.SetActive(false);	
        yield return new WaitForSeconds(4f);
        UI.SetActive(true);	
        

    }
    public int user = 0;
    int user1 = 0;
    int user2 = 0;
    int user3 = 0;

    float distance1;
    float distance2;
    float distance3;

    void Update()
    {
        distance1 = Vector3.Distance(mycar.transform.position, AiCars.transform.GetChild(0).position);
        distance2 = Vector3.Distance(mycar.transform.position, AiCars.transform.GetChild(1).position);
        distance3 = Vector3.Distance(mycar.transform.position, AiCars.transform.GetChild(2).position);

        car1.text =  distance1+"m";
        car2.text =  distance2+"m";
        car3.text =  distance3+"m";


        //user = userPosition();
        userPosition();
        
        if (user==0)
        {
            car1.text = "";
            name1.text = Name4;
            if(distance1>distance2)
            {
                if(distance1>distance3)
                {
                    car2.text =distance1+"m";
                    car3.text =distance3+"m";
                    car4.text =distance2+"m";
                    name2.text = name1+"";
                    name3.text = name3+"";
                    name4.text = name2+"";
                }
                else{
                    car2.text =distance3+"m";
                    car3.text =distance1+"m";
                    car4.text =distance2+"m";
                    name2.text = name3+"";
                    name3.text = name1+"";
                    name4.text = name2+"";
                }
            }
            else
            {
                if(distance2>distance3)
                {
                    car2.text =distance2+"m";
                    car3.text =distance3+"m";
                    car4.text =distance1+"m";
                    name2.text = name2+"";
                    name3.text = name3+"";
                    name4.text = name1+"";
                }
                else
                {
                    car2.text =distance3+"m";
                    car3.text =distance2+"m";
                    car4.text =distance1+"m";
                    name2.text = name3+"";
                    name3.text = name2+"";
                    name4.text = name1+"";
                }
            }
        }
        if (user==3)
        {
            car4.text = "";
            name4.text = Name4;
            if(distance1>distance2)
            {
                if(distance1>distance3)
                {
                    car1.text = "-" +distance1+"m";
                    car2.text = "-" +distance3+"m";
                    car3.text = "-" +distance2+"m";
                    name1.text = name1+"";
                    name2.text = name3+"";
                    name3.text = name2+"";
                }
                else{
                    car1.text = "-" +distance3+"m";
                    car2.text = "-" +distance1+"m";
                    car3.text = "-" +distance2+"m";
                    name1.text = name3+"";
                    name2.text = name1+"";
                    name3.text = name2+"";
                }
            }
            else
            {
                if(distance2>distance3)
                {
                    car1.text = "-" +distance2+"m";
                    car2.text = "-" +distance3+"m";
                    car3.text = "-" +distance1+"m";
                    name1.text = name2+"";
                    name2.text = name3+"";
                    name3.text = name1+"";
                }
                else
                {
                    car1.text = "-" +distance3+"m";
                    car2.text = "-" +distance2+"m";
                    car3.text = "-" +distance1+"m";
                    name1.text = name3+"";
                    name2.text = name2+"";
                    name3.text = name1+"";
                }
            }
        }


    }

    public void userPosition()
    {

            Vector3 forward = mycar.transform.TransformDirection(Vector3.forward);
            Vector3 toOther = AiCars.transform.GetChild(0).position - mycar.transform.position;
            Vector3 toOther1 = AiCars.transform.GetChild(1).position - mycar.transform.position;
            Vector3 toOther2 = AiCars.transform.GetChild(2).position - mycar.transform.position;
            if (Vector3.Dot(forward, toOther) < 0)
            {
                user1 = 0;
            }
            else
            {
                user1 = 1;
            }
            if (Vector3.Dot(forward, toOther1) < 0)
            {
                user2 = 0;
            }
            else
            {
                user2 = 1;
            }
            if (Vector3.Dot(forward, toOther2) < 0)
            {
                user3 = 0;
            }
            else
            {
                user3 = 1;
            }
            user =  user1+user2+user3;     
    }
}
