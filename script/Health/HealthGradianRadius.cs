using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
    /// <summary>
    /// add the health to Health object with in the radius depenging to there distance
    /// </summary>
    public class HealthGradianRadius:HealthRadius
    {
        /// <summary>
        /// the gradiate function 
        /// </summary>
        //TODO make the gradiant function work 
        private Func<float, float> gradiateFuntion;
        public HealthGradianRadius(float healthAdded,float radius,Vector3 orginPosition, Func<float,float> fun):base(healthAdded,radius,orginPosition)
        {
            gradiateFuntion = fun;
        }
        public override void OnCollision(Collider i)
        {
            if (i.TryGetComponent(out Health h))
            {
                h.Heal(healthAdded);
            }
        } 
    }
