using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
    public class InteractableAndGrabable:IGrabable,IInteractable
    {
        private GrabableItems d = new GrabableItems();
        public void Grab()
        {
            throw new System.NotImplementedException();
        }

        public void Interact()
        {
            throw new System.NotImplementedException();
        }
    }
