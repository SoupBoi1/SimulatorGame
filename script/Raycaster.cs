using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    
    int layerMask =0;
    public bool hithappend = false;

    public bool hitHappend
    {
        get
        {
            return hithappend;
        }
    }

    
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = ~(1<<8);

    }

    // Update is called once per frame
    void Update()
    {
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,
                layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.yellow);
            hithappend = true;
        }
        else
        {
            hithappend = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
 
        
       
    }
    
    /**
     * @pram transform - the object to will set to when raycast hit somthing hits somthing
     * @return true if hit soming for raycast false if it hit nothing at the movement
     */
    public  bool  setPointHit(Transform T)
    {
        if (hithappend)
        {
            T.position = hit.point;
            return true;
        }
        else
        {
            return false;
        }
    }
    /**
     * @distanceThrushold - distance of the hit thats appectable
     * @pram transform - the object to will set to when raycast hit somthing hits somthing
     * @return true if hit soming for raycast within distance of distanceThrushold else it returns false and retruns faslse if it hit nothing
     */
    public bool  setPointHit(Transform T, float distanceThrushold)
    {
        
        if (hit.distance <= distanceThrushold)
        {
            return setPointHit(T);
             
        }

        return false;

    }
    
}
