using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// a button that can be grabed
/// </summary>
    public class GrabableButton:Button,IGrabable
    {
        private bool buttonState_value=false;
        
        private bool ButtonState
        {
            get
            {
                return buttonState_value;
            }
            set
            {
                buttonState_value = value;
                UpdateButtonStats(); //PlaceholderName
            }
        }
        public void Awake()
        {
            cost = 10;
        }


        public override void Interact()
        {
            ButtonState = !ButtonState;
            Debug.Log("Button down: "+ ButtonState );

        }



        
        /// <summary>
        /// updtate the button acuding to it's state
        /// </summary>
        public void UpdateButtonStats()
        {
            Debug.Log("Button down: "+ ButtonState );
        }

        public  void Grab()
        {
            Debug.Log("button held" + ButtonState);
        }

        public  void Inpect()
        {
            throw new NotImplementedException();
        }
    }
