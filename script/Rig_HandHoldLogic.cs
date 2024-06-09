using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Rig_HandHoldLogic : MonoBehaviour
{

    public Raycaster raycaster;
    public Rig LeftHandRig;// the rigs
    public Rig RightHandRig;

    public Transform ikRightHandHandle;
    public Transform ikLeftHandHandle;

    public float heldoutDistace = 1;
    public bool justPutUourHandsOut =false;

    //TODO find a better way to learp vlues form 0 to 1 in real time hint: may be muti threading 
    private float _initWeightR = 0;
    private float initWeightL = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _initWeightR = RightHandRig.weight;
        initWeightL = LeftHandRig.weight;
    }

    // Update is called once per frame
    void Update()
    {
        //if a hit collision then rig is active else no 
        if (raycaster.setPointHit(ikRightHandHandle,heldoutDistace)||justPutUourHandsOut)
        {
            RightHandRig.weight = 1;
        }
        else
        {

            RightHandRig.weight = 0;
        }
        // samething for lefthand
        if (raycaster.setPointHit(ikLeftHandHandle,heldoutDistace))
        {
            //lerpWeight(LeftHandRig,initWeightL, .7f,0.5f);
            LeftHandRig.weight = 1;
        }
        else
        {
            //lerpWeight(LeftHandRig,initWeightL, .1f,0.5f);

            LeftHandRig.weight = 0;
        }
    }

    
    /**
     * trasitons the weight of the rig the disiered value over time
     */
    void lerpWeight(Rig w,float initW,float end,float duration )
    {
        
        if (initW < end )
        {
            w.weight += ((-initW +end)/ duration)*Time.deltaTime;
            Debug.Log(initW+" "+ -initW +end);
        }
        else if ( initW>end)
        {
            w.weight -= ((initW -end)/ duration)*Time.deltaTime;
            Debug.Log(initW+" "+ (initW -end));

        }
        else
        {
            initW = end;
            
            w.weight= end;
        }
        
        


    }
}
