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

    public Rigidbody gunsRigidbody;

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

    public float recoilforce;

    public ForceMode forceMode = ForceMode.Force;
 
    void Start()
    {
        layerMask = ~(1<<8);

    }
   

    public virtual void  Shoot(float damage)
    {            
        applyRecoil();
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, getDirction(), out hit, Mathf.Infinity, layerMask))
        {
            hithappend = true;
            Debug.DrawRay(transform.position, getDirction() * hit.distance,
                Color.red);
            if (hit.transform.TryGetComponent(out IHealth h))
            {
                Damage(h,damage);
                

            }
        }
        else
        {
            hithappend = false;
           
            Debug.DrawRay(transform.position, getDirction()* 1000, Color.white);
        }
 
        
       
    }

    public Vector3 getDirction()
    {
        return transform.TransformDirection(local_Dir);
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

    
    /// <summary>
    /// recolis the guns rigid body with force of one 
    /// </summary>
    /// 
    public virtual void applyRecoil()
    {
        applyRecoiltoRB(recoilforce);
    }
    /// <summary>
    /// recolis the guns rigid body
    /// </summary>
    /// <param name="RecoleForce">force of recoile</param>
    public void applyRecoiltoRB(float RecoleForce)
    {
        if (gunsRigidbody != null)
        {
            gunsRigidbody.AddForce(-getDirction()*RecoleForce,forceMode);
        }
    }


}
