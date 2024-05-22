using System;
using UnityEngine;
using UnityEngine.UI;

public class HoldRB: MonoBehaviour
    {
        private Rigidbody rb_value;

        private Transform rb_trasform;
        public Rigidbody rigidBody
        {
            set
            {
                rb_value = value;
                istheranythingtograb = true;
                rb_trasform = value.transform;

            }
            get
            {
                return rb_value;
            }
        }
        
        public bool istheranythingtograb;
        
        public float Force = 10;


        public void setRB(Rigidbody rnb)
        {
            rigidBody = rnb;
            Debug.Log(rnb.name);
            istheranythingtograb = true;
            rb_trasform = rnb.transform;

        }
        
        private void Update()
        {
      
        }

        /// <summary>
        /// gets grabs obj to the desrese location
        /// </summary>
        /// <param name="t">location</param>
        public void Grab(Transform t)
        {
            // we will apply the same ammount of force
            Grab(t.position);

        }
        
        /// <summary>
        /// gets grabs obj to the desrese location
        /// </summary>
        /// <param name="t">location</param>
        public void Grab(Vector3  t)
        {
            // we will apply the same ammount of force
            rigidBody.gameObject.layer = 0b001; 

            rigidBody.AddForce(new Vector3((t.x - rb_trasform.position.x),(t.y - rb_trasform.position.y),(t.z - rb_trasform.position.z )).normalized*Force,ForceMode.Force);
        }

        public void Drop()
        {
            
            istheranythingtograb = false;
        }
        
        
    }
