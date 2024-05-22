using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Item : MonoBehaviour,IInteractable
{

    /// <summary>
    /// cost of the Item in Money
    /// </summary>
    public Money cost;
    
    /// <summary>
    /// DONOT USE WHEN PROGRAMING ONLY FOR INPECTOR ONLY
    /// </summary>
    public bool  isInteractable_vaule = true;


    
    /// <summary>
    /// weather the Item Interactable<br></br>
    /// true - yes it is Interactable<br></br>
    /// false - no it is not Interactable<br></br>
    /// </summary>
    public  bool isInteractable
    {
        get
        {
            return isInteractable_vaule;
        }
        set
        {
            isInteractable_vaule = value;
        }
    }


    public abstract void Interact();

}
