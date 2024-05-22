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
        public Rigidbody RB;
        public bool justcopy;


        public void Start()
        {
            
            
           // int count = transform.childCount;
            //configurableJoints = new ConfigurableJoint [count];
           // Transform _t;
            //Debug.Log(count);

            
            if (TryGetComponent(out Rigidbody r))
            {
                RB = r;
                
            }
            
            

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
                    configurableJoint.angularXMotion = ConfigurableJointMotion.Free;
                    configurableJoint.angularYMotion = ConfigurableJointMotion.Free;
                    configurableJoint.angularZMotion = ConfigurableJointMotion.Free;


                    var drive = configurableJoint.angularXDrive;
                    drive.positionSpring = 1;
                    configurableJoint.angularXDrive = drive;
                    configurableJoint.angularYZDrive = drive;

                     Destroy(c);
                    //   configurableJoints[i] = configurableJoint;

                }
                else
                {
                    RB.isKinematic = true;
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
            if (justcopy==true)
            {
                transform.position = copy.position;
                transform.rotation = copy.rotation;
            }
            else
            {
                configurableJoint.targetPosition = copy.position; 
                configurableJoint.targetVelocity = new Vector3(5, 5, 5);
                configurableJoint.targetRotation = copy.rotation;
                configurableJoint.targetAngularVelocity = new Vector3(5, 5, 5);
            }
            


        }
    }
