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

    public Transform rotateTHE;
    private Vector3 pos_offset_value;

    public Vector3 pos_offset
    {
        get
        {
            return pos_offset_value;
            
        }
        set
        {
            pos_offset_value = value;

            UpdateCameraPosition();
        }
    }

    //TODO make Movement fun
    public float appliedVilocity;
    public float speed = 1;
    private Vector3 rotateBody;
   
    
    // Start is called before the first frame update
    void Start()
    {
        if (rotateTHE == null)
        {
            rotateTHE = Subject;
        }
        pos_offset = Vector3.zero;
        rotateBody = Vector3.zero;
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

        UpdateCameraPosition();
        transform.rotation = Quaternion.Slerp(transform.rotation, Subject.rotation, speed*Time.deltaTime);
        
    }

    
    /// <summary>
    /// takes the  input of a x and y and traslastes it to the ratoation of the camera
    /// </summary>
    /// <param name="_inputCameraVector"> put your x and y motion of the mouse, controler , etc </param>
    public void LOOK(float x, float y)
    {
        
        rotateBody += new Vector3(x, y,0);

        rotateTHE.localRotation =  Quaternion.Euler(0,rotateBody.x,0);
        
        Subject.localRotation =  Quaternion.Euler(-rotateBody.y,0,0);
    }


    void Move(Vector3 Dirction)
    {
        

    }

    /// <summary>
    /// Update camera position
    /// </summary>
    void UpdateCameraPosition()
    {
        transform.position = Subject.position +pos_offset;
        
    }


}
