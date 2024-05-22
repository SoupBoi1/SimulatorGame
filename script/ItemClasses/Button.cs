using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Button:GrabableItems 
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
            value_cost_in_money = 10;
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

        public override void Grab()
        {
            throw new NotImplementedException();
        }

        public override void Inpect()
        {
            throw new NotImplementedException();
        }
    }
