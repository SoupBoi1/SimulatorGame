using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
    public class Movement:MonoBehaviour
    {
        private Transform _transform ;
        /*movementState:
         * 0 = idel - no changes to currentSpeed
         * 1= acclration - acclration the currentSpeed
         * 2= maxspeed - no changes to currentSpeed --will go to state 3 if stop
         * 3= deacclration - Deacclration the currentSpeed
         * 4 = turn acclration - if when going opposite of current dirton will apply the turn acclration on after <state 1>
         *
         *
         */
        private int movementState = 0;
        private bool jumpable = false;
        public bool isinAir = false;
        public float fallDelay = 5f;
        private float ungrounedTimer;
        public float jumpBuffer = 5f;
        
        public float currentSpeed = 0;// current movment speed of th player 
        public float AcclerationMovement = 3;
        public float DeacclerationMovement=1;
        public float TurnDeacclerationMovement=100;
        public float maxSpeed = 10;
        public Vector3 gobalGravity; // the gravity of the player's enviorment

    
        public Vector3 movement;// current movment of th vilocity of the player
        public Vector3 externalVilocityOfPlayer; // vilocity of player cause by gravity and other forces

        /// <summary>
        /// calulates the vilocity in dectition of this <c>Tranfrom</c> and accoudingly to inpout dirction
        /// </summary>
        /// <param name="inputMoveDir"> normalized direction</param>
        /// <returns>vilocity</returns>
        public Vector3 MoveInDir(Vector3 inputMoveDir)
        {
            
            _transform = transform; 
            if (movementState == 1)
            {
                currentSpeed += AcclerationMovement * Time.deltaTime;
                if (currentSpeed >= maxSpeed)
                {

                    currentSpeed = maxSpeed;
                    movementState = 2;
                }
            } else if (movementState == 3)
            {


                if (!isinAir)
                {
                    currentSpeed -= DeacclerationMovement * Time.deltaTime;

                }
            
                if (currentSpeed <=0f )
                {

                    currentSpeed = 0f;
                    movementState = 0;
                }
            }
            movement = ((_transform.forward *inputMoveDir.z)  + (_transform.right *inputMoveDir.x )) * currentSpeed +(externalVilocityOfPlayer) ;
            return movement;
           // _characterController.Move(movement*Time.deltaTime);

        
        }
        
    }
