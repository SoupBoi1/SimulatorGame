
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/// <summary>
/// base of grable item only
///
/// 
/// </summary>
public class GrabaleItem : Item,IGrabable
{

    
    //one of the grab position on the objthis componet is acttact to
    public Transform GrabPosition;
    public Transform currentGrabberTransform;
    public Rigidbody _rigidbody;
    /// <summary>
    /// weather the item is Grabable<br></br>
    /// if yes: true<br></br>
    /// if no: false
    /// </summary>
    public virtual bool isGrabable
    {
        
        get
        {
            return isGrabable_value;
        }
        set
        {
            isGrabable_value = value;
        }
    }
    private  bool isGrabable_value = true;
    

    public virtual void Grab(Transform t)
    {
        
        transform.parent = t;
        currentGrabberTransform = t;
        
        transform.localPosition = Vector3.zero;
        transform.localPosition = GrabPosition.position-transform.position;
        
        if (TryGetComponent(out Rigidbody rb))
        {

            ConfigurableJoint cojoint = t.AddComponent<ConfigurableJoint>();
            //cojoint.autoConfigureConnectedAnchor = false;

            cojoint.connectedBody = rb;
            //todo use the charcter joimnt setting on the ragdoll brach
            
            cojoint.xMotion = ConfigurableJointMotion.Locked;
            cojoint.yMotion = ConfigurableJointMotion.Locked;
            cojoint.zMotion = ConfigurableJointMotion.Locked;
            

            // k.connectedBody(_rigidbody);
            //.connectedBody(_rigidbody);
            //  joint;
        }
        
    
        
        
        
        //throw new NotImplementedException();
    }
    
    public virtual void Grab(Transform[] t)
    {
        for (int i = 0; i < t.Length; i++)
        {
            


        }





        //throw new NotImplementedException();
    }

    public virtual void Inpect()
    {
        //throw new NotImplementedException();
    }


    public override void Interact()
    {
       // throw new NotImplementedException();
    }
}

