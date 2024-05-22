
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class InteractableItem : Item,IInteractable
{

    /// <summary>
    /// DONOT USE WHEN PROGRAMING ONLY FOR
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


    /// <summary>
    /// usess the Item 
    /// </summary>
    public abstract void Interact();
   
    

    /*
    /// <summary>
    /// makes the Item <b>not</b> Interactable
    /// </summary>
    public void DisableInteract()
    {
        isInteractable_vaule = false;
    }
    /// <summary>
    /// makes the Item Interactable
    /// </summary>
    public void EnableInteract()
    {
        isInteractable_vaule = true;
    }

*/
 
    
    
    
  
}
