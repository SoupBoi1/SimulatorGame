using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform Subject;
    public float speed = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Subject.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Subject.rotation, speed*Time.deltaTime);
            
        
    }
}
