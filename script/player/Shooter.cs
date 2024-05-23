using System;
using UnityEngine;
using UnityEngine.UI;


public class Shooter:MonoBehaviour,IDamager
{
    int layerMask =0;
    private bool hithappend = false;

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
    public virtual void  Fire(float damage)
    {            

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            hithappend = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.red);
            if (hit.transform.TryGetComponent(out Health h))
            {
                Damage(h,damage);
            }
        }
        else
        {
            hithappend = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
 
        
       
    }
    
    /// <summary>
    ///  
    /// </summary>
    /// <param name="T">the object to will set to when raycast hit somthing hits somthing</param>
    /// <returns>true if hit soming for raycast within distance of distanceThrushold else it returns false and retruns faslse if it hit nothing </returns>
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
    /// <summary>
    ///  
    /// </summary>
    /// <param name="T">the object to will set to when raycast hit somthing hits somthing</param>
    /// <param name="distanceThrushold"> distance of the hit thats appectable</param>
    /// <returns>true if hit soming for raycast within distance of distanceThrushold else it returns false and retruns faslse if it hit nothing </returns>
   
    public bool  setPointHit(Transform T, float distanceThrushold)
    {
        
        if (hit.distance <= distanceThrushold)
        {
            return setPointHit(T);
             
        }

        return false;

    }

    public void Damage(Health  health,float damage)
    {
        health.Damage(damage);
    }
}
