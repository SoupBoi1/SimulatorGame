using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// part of a gun that shoots the bullet
/// a GUN or any commponent can have mutiple of this <c>shooter</c>
/// </summary>
public class Shooter:MonoBehaviour,IDamager,IShootable
{
    int layerMask =0;



   
   /// <summary>
   /// Dirctionof where the raycast if faing localy
   /// </summary>
    public Vector3 local_Dir = Vector3.forward;

    private bool hithappend = false;
    /// <summary>
    /// true then raycast hits something
    /// </summary>
    public bool hitHappend
    {
        get
        {
            return hithappend;
        }
    }

  

    
    public RaycastHit hit;
 
    void Start()
    {
        layerMask = ~(1<<8);

    }
   

    public virtual void  Shoot(float damage)
    {            

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(local_Dir), out hit, Mathf.Infinity, layerMask))
        {
            hithappend = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(local_Dir) * hit.distance,
                Color.red);
            if (hit.transform.TryGetComponent(out IHealth h))
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

    public void Damage(IHealth  health,float damage)
    {
        health.Damage(damage);
    }


}
