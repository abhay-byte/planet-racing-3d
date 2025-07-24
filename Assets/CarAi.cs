using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAi : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject pointer;
    Transform orginalTarget;
    Transform currentTarget;
    public int checkpoints;
    public int currentChechpoint;
    public float Acceleration;
    public Transform dummy;
    float Torque;
    public float turnTorque;
    public float y=0;
    public float ylimit=0;
    public bool turnP = false;
    public bool turnN = false;
    public bool repeat;

    public float aboveGround;
    bool move;
    void Start()
    {
        move = false;
        checkpoints = pointer.transform.childCount;
        orginalTarget = pointer.transform.GetChild(0);

        currentTarget = Instantiate(orginalTarget);
        currentTarget.transform.SetParent(pointer.transform);
        currentTarget.transform.position = orginalTarget.transform.position + new Vector3(Random.value * 30 - 15, 0, Random.value * 30 - 15);

        transform.LookAt(currentTarget);
        dummy.transform.LookAt(currentTarget);
        currentChechpoint = 0;
        StartCoroutine(StartRace());  
    }


    IEnumerator StartRace()
    {
        yield return new WaitForSeconds(5f);
        move = true;

    }
    void FixedUpdate()
    {
        if (turnP)
        {
            if (y>ylimit)
            {
                turnP = false;     
            }
            y += Time.deltaTime * 75.0f; 
            transform.localRotation = Quaternion.Euler(transform.rotation.x, WrapAngle(y), transform.rotation.z);          
        }
        else if (turnN)
        {
            y -= Time.deltaTime * 75.0f; 
            transform.localRotation = Quaternion.Euler(transform.rotation.x, WrapAngle(y), transform.rotation.z);   
            if (y<ylimit)
            {
                turnN = false;
                transform.localRotation = Quaternion.Euler(transform.rotation.x, WrapAngle(ylimit), transform.rotation.z);  
            }           
        }
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget.position)>25f)
        {
            if(speed>Torque)
            {
                Torque = Torque+Acceleration;
            }
            
        }
        else
        {
            if(Torque>turnTorque)
            {
                Torque = Torque-Acceleration;
            }
        }
            
        // Move our position a step closer to the target.
        float step =  Torque * Time.deltaTime; // calculate distance to move
        
        if(move)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);
        }
        //transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);
        

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, currentTarget.position) < 2f && currentChechpoint<checkpoints)
        {
            // Swap the position of the cylinder
            currentChechpoint++;
            orginalTarget = pointer.transform.GetChild(currentChechpoint);
            currentTarget = Instantiate(orginalTarget);

            
            currentTarget.transform.SetParent(pointer.transform);
            currentTarget.transform.position = orginalTarget.transform.position + new Vector3(Random.value * 30 - 15, 0, Random.value * 30 - 15);
            dummy.transform.LookAt(currentTarget);
            ylimit = WrapAngle((dummy.rotation.eulerAngles.y));
            turnP = true;
            turnN = true;
            

        }
        else if (repeat && currentChechpoint == checkpoints)
        {
            currentChechpoint = 0;
        }
    }
        private static float WrapAngle(float angle)
        {
            angle%=360;
            if(angle >180)
                return angle - 360;
 
            return angle;
        }

    void OnCollisionStay(Collision collisionInfo)
    {
        move = false;
            if(Torque>5f)
            {
                Torque = Torque-Acceleration;
            }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        move = true;
    }
        
    Quaternion lookAtSlowly(Transform t , Vector3 target , float speed){
    
    //(t) is the gameobject transform
    //(target) is the location that (t) is going to look at
    //speed is the quickness of the rotation
    
    Vector3 relativePos = target - t.position;
    Quaternion toRotation = Quaternion.LookRotation(relativePos);
    return Quaternion.Lerp(t.rotation, toRotation, speed * Time.deltaTime);
    }

}
