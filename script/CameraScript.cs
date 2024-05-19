using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    
    /**camera moving to the deried rotation the Subject
     * 
     */
    public Transform Subject;
    public float speed = 1;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    
    /**
     * set speed of the camera moving to the deried rotation the Subject 
     */
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
