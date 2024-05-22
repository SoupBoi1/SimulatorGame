
using System;
using System.Collections;
using System.Collections.Generic;
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
        transform.localPosition = Vector3.zero;
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

