using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
///  add the health to Health object with in the radius
/// </summary>
    public class HealthRadius:ITriggerable
    {
        public float healthAdded_value = -50f;
        /// <summary>
        /// damages in connact of the explosion
        /// or healing if true
        /// </summary>
        //public bool isDamaging=false;

        public float healthAdded
        {
            set
            {
                healthAdded_value = value;
                //isDamaging = (value < 0);
                
            }
            get
            {
                return healthAdded_value;
            }
        }
        public float radius;
        public Vector3 orginPosition;


        public HealthRadius(float healthAdded,float radius,Vector3 orginPosition)
        {
            this.healthAdded = healthAdded;
            this.radius = radius;
            this.orginPosition = orginPosition;
        }

        public virtual void OnCollision(Collider i)
        {
            if (i.TryGetComponent(out Health h))
            {
                Debug.Log("health effected to "+i.name+"with"+h.health);
               
                
                    h.Heal(healthAdded);
                
                
            }
        }


        public void Trigger()
        {
            foreach (Collider i in Physics.OverlapSphere(orginPosition, radius))
            {
               // Debug.Log("health effected to "+i.name);
                OnCollision(i);
                
            }        
        }

        public void Release()
        {
            throw new NotImplementedException();
        }
    }
