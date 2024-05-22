using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
    public abstract class InteractableAndGrabable:Item, IGrabable,IInteractable
    {
        
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
        
        // public Transform Holder;



        /// <summary>
        /// Grabs the Item
        /// </summary>
        public abstract void Grab();



        /// <summary>
        /// call to trigger a inpect animation whent held
        /// </summary>
        public abstract void Inpect();
        
        /// <summary>
        /// usess the Item 
        /// </summary>
        public abstract void Interact();


    }
