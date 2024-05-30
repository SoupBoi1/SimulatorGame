using System;using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
    public class Movement:MonoBehaviour
    {
        public CharacterController characterController; // debug
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
        private MovmentState currentMovementState_value = MovmentState.Idel;

        public MovmentState currentMovementState
        {
            get
            {
                return currentMovementState_value;
            }
            private set
            {
                currentMovementState_value = value;
            }
        }
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

        
        public Vector3 debugInput;
        /// <summary>
        /// calulates the vilocity in dectition of this <c>Tranfrom</c> and accoudingly to inpout dirction
        /// </summary>
        /// <param name="inputMoveDir"> normalized direction</param>
        /// <returns>vilocity</returns>
        public Vector3 MoveInDir(Vector3 inputMoveDir, Transform _transform)
        {
            
            if (inputMoveDir.magnitude > 0)
            {
                currentMovementState = MovmentState.Acclerating;
            }else
            {
                if (DeacclerationMovement == 0f)
                {
                    currentMovementState = MovmentState.Idel;
                }
                else
                {
                    currentMovementState = MovmentState.Deacclerating;
                    //                Debug.Log("movemnt state:"+ movementState);
                }

            }
            if (currentMovementState == MovmentState.Acclerating ||currentMovementState == MovmentState.MaxSpeed ) // braking the movement here as long THE playe is in air speed will keep on increasing 
            {
                if (currentSpeed >= maxSpeed && !isinAir)// braking the movement here as long THE playe is in air speed will keep on increasing 
                {

                    currentSpeed = maxSpeed;
                    currentMovementState = MovmentState.MaxSpeed;
                }
                currentSpeed += AcclerationMovement * Time.deltaTime;
            
            } else if (currentMovementState == MovmentState.Deacclerating)
            {
            
            

                if (!isinAir )
                {
                    currentSpeed -= DeacclerationMovement * Time.deltaTime;

                }
            
                if (currentSpeed <=0f )
                {

                    currentSpeed = 0f;
                    currentMovementState = MovmentState.Idel;
                }
            }
            movement = ((_transform.forward *inputMoveDir.z)  + (_transform.right *inputMoveDir.x )) * currentSpeed +(externalVilocityOfPlayer) ;
            return movement;
            

        }

        public void Start()
        {
            gobalGravity = Physics.gravity;
        }

        public void Update()
        {
            
            if (!characterController.isGrounded && characterController.enabled) // TODO fixjump
            {
                if (ungrounedTimer <= 0)
                {
                    isinAir = true;
                   


                }
                ungrounedTimer -= Time.deltaTime;
            
            
            
            

            }
            else
            {
                if (isinAir)
                {
                  

                }
                ungrounedTimer = fallDelay;
                isinAir = false;
                externalVilocityOfPlayer.y = 0;
            }
            characterController.Move((this.MoveInDir(debugInput,transform)+gobalGravity)*Time.deltaTime);
        
        }

    }

    


/// <summary>
/// states of the movement 
/// </summary>
public enum MovmentState{
    /// <summary>
    /// when no input is apllied 
    /// </summary>
Idel,
    /// <summary>
    /// when Acclerating
    /// </summary>
Acclerating,
    /// <summary>
    /// when Deacclerating
    /// </summary>
Deacclerating,
    /// <summary>
    /// when it caps and reaches max speed
    /// Deacclration the currentSpeed
    /// </summary>
MaxSpeed
}
