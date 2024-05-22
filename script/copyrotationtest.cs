using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;



    public class copyrotationtest:MonoBehaviour
    {

        public ConfigurableJoint configurableJoint;
        public Transform copy;
        public Rigidbody copyRB;


        public void Start()
        {
            
            
           // int count = transform.childCount;
            //configurableJoints = new ConfigurableJoint [count];
           // Transform _t;
            //Debug.Log(count);


                if (TryGetComponent(out CharacterJoint c))
                {
                    print(transform.name);
                    configurableJoint = transform.AddComponent<ConfigurableJoint>();
                    configurableJoint.connectedBody = c.connectedBody;
                    configurableJoint.anchor = c.anchor;
                    configurableJoint.axis = c.axis;
                    configurableJoint.connectedAnchor = c.connectedAnchor;
                   // configurableJoint.secondaryAxis = c.swingAxis;
                    configurableJoint.xMotion = ConfigurableJointMotion.Limited;
                    configurableJoint.yMotion = ConfigurableJointMotion.Limited;
                    configurableJoint.zMotion = ConfigurableJointMotion.Limited;


                     Destroy(c);
                    //   configurableJoints[i] = configurableJoint;

                }
               /* if (transform.gameObject.GetComponents<ConfigurableJoint>().Length>=count)
                {
                    configurableJoint = configurableJoint_t;
                    configurableJoints[i] = configurableJoint_t;
                }
                else
                {

                    configurableJoint = transform.AddComponent<ConfigurableJoint>();
                    configurableJoints[i] = configurableJoint;

               // }

                configurableJoint.connectedBody = _t.gameObject.GetComponent<Rigidbody>();

*/

            
            

            
        
        }

        public void Update()
        {
        }
    }
