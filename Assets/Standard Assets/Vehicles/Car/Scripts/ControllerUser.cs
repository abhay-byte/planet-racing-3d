using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerUser : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontal;
    public bool enabled;
    public float vertical;
    public float sensitivity = 0.25f;

    public Slider hSlider;
    public Slider vSlider;

    // Update is called once per frame



    public void right()
    {
        if(horizontal<=1f)
        {
            horizontal+=sensitivity;
            hSlider.value = horizontal;
        }
    }

    public void left()
    {
        if(horizontal>=-1f)
        {

            horizontal-=sensitivity;
            hSlider.value = horizontal;
        }
    }

    public void up()
    {
        if(vertical<=1f)
        {
            vertical+=0.25f;
            vSlider.value = vertical;
        }
    }
    public void down()
    {
        if(vertical>=-1f)
        {
            vertical-=0.25f;
            vSlider.value = vertical;
        }
    }

    public void enable()
    {
        enabled = true;
    }
    public void disable()
    {
        enabled = false;
    }
}
