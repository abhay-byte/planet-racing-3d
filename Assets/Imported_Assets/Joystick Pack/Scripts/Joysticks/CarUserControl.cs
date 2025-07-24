using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        public VariableJoystick variableJoystick;
        public bool Enable = true;

        public void VariableJoyStickEnable()
        {
            Enable = true;
        }
        public void VariableJoyStickDisable()
        {
            Enable = false;
        }


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
            
            
        }
        float h;
        float v;

        private void FixedUpdate()
        {
            // pass the input to the car!
            if (Enable)
            {
                 h = variableJoystick.Horizontal;
                 v = variableJoystick.Vertical;
            }
            else{
                 h = CrossPlatformInputManager.GetAxis("Horizontal");
                 v = CrossPlatformInputManager.GetAxis("Vertical");              
            }


#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
