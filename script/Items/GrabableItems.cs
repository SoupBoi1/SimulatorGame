using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrabableItems:Item
{
        //one of the grab position on the objthis componet is acttact to
        public Transform GrabPosition;
       /// <summary>
       /// weather the item is Grabable<br></br>
       /// if yes: true<br></br>
       /// if no: false
       /// </summary>
        public bool isGrabable = true;
        
       // public Transform Holder;
        
  

        /// <summary>
        /// Grabs the Item
        /// </summary>
        public virtual void Grab()
        {
            if (isGrabable)
            {
                
                //you function here
            }
        }

        
        /// <summary>
        /// call to trigger a inpect animation whent held
        /// </summary>
        public virtual  void Inpect()
        {
            
        }
        
        /// <summary>
        /// call to trigger a inpect animation whent held
        /// </summary>
        public virtual  void SetGrabable(bool value)
        {
            
        }
        
}
