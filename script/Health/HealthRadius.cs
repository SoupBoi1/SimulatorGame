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
        public float healthAdded;
        public float radius;
        public Vector3 orginPosition;

      

        public virtual void OnCollision(Collider i)
        {
            if (i.TryGetComponent(out Health h))
            {
                h.Heal(healthAdded);
            }
        }


        public void Trigger()
        {
            foreach (Collider i in Physics.OverlapSphere(orginPosition, radius))
            {
                OnCollision(i);
                
            }        }

        public void Release()
        {
            throw new NotImplementedException();
        }
    }
