using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    public InputActionAsset _inputActionAsset;
    private InputActionMap _inputActionMap_OnFoot;
    private InputActionMap _inputActionMap_Camera;
    private InputActionMap _inputActionMap_Interactable;


    
    private InputAction input_move;
    private InputAction input_jump;
    private InputAction input_ragdoll;
    private InputAction input_kick;
    private InputAction input_melee;

    private InputAction input_interact;
    private InputAction input_fire;
    private InputAction input_grable;



    
    private InputAction input_look;
    
    private Vector3 inputMoveDir;
    private float inputMoveDirx;
    private float inputMoveDiry;
    private Vector3 inputCameraVector;

    public CameraScript _cameraScript;
    public Raycaster _Raycaster;
     

    private Transform _transform;
    public Transform cameraPosition;
    public Animator animator;
    public GameObject animationOBJ;

    // tem TODO find a better way to ragdoll or even active ragdoll
    public GameObject ragdollOBJ;
    public Animator ragdollAnimator;
    public ragdolltest Ragdolltest;
    /// <summary>
    /// 0 = idel - no changes to currentSpeed
    /// 1= acclration - acclration the currentSpeed
    /// 2= maxspeed - no changes to currentSpeed --will go to state 3 if stop
    /// 3= deacclration - Deacclration the currentSpeed
    ///4 = turn acclration - if when going opposite of current dirton will apply the turn acclration on after <state 1>
    /// </summary>
    private int movementState = 0;

    /// <summary>
    /// 0 idel
    /// 1 = hold kick
    /// 2 =kick
    /// 
    /// </summary>
    private int kickState = 0;

    private float kickChargeMutiplyerValue = 1;

    private int kickForce = 500;
    private float kickForceChageMutiplier = 2;
    /// <summary>
    /// kick Force Chage to reach wait time in a secounds
    /// </summary>
    private float kickForceChagewait = 1f;


    /// <summary>
    /// 0 - no melee
    /// 1- nomal melee-it goes from <c>0</c> to <c>1</c>
    /// 2- chargeing -the charge active after waiting 
    /// 3- hardmelee -it goes from <c>0</c> then <c>2</c> then <c>3</c>
    /// 
    /// </summary>
    private int meleeState = 0;
    private int meleeForceChageMutiplier = 2;
    /// <summary>
    /// kick Force Chage to reach wait time in a secounds
    /// </summary>
    private float meleeForceChagewait = 1f;
    
    private bool jumpable = false;
    public bool isinAir = false;
    public float fallDelay = 5f;
    private float ungrounedTimer;
    public float jumpBuffer = 5f;
    
    
        


    public float currentSpeed = 0;// current movment speed of th player 
    public float AcclerationMovement = 3;
    public float DeacclerationMovement=0;
    public float TurnDeacclerationMovement=100;
    public float maxSpeed = 10;

    
    public Vector3 gobalGravity; // the gravity of the player's enviorment

    
    public Vector3 movement;// current movment of th vilocity of the player
    public Vector3 externalVilocityOfPlayer; // vilocity of player cause by gravity and other forces
    public Vector3 rotateBody; // current vilosity  of  player's rotation


    public Movement _movement;

    public HoldRB _HoldRb;
    public Transform leftHandTransform;
    public Transform rightHandTransform;

    //todo have hotbar instad 
    public ITriggerable itemSlot1; //tem in dev
    
    // Start is called before the first frame update
    void Start()
    {
        //ragdollOBJ.SetActive(false);
        inputMoveDir = Vector3.zero;
        inputCameraVector = Vector3.zero;
        rotateBody = Vector3.zero;
        
        gobalGravity = Physics.gravity;
        externalVilocityOfPlayer = gobalGravity;
        
        
        _transform = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        
        _movement = GetComponent<Movement>();

        _cameraScript.rotateTHE = this.transform;
        
        _inputActionMap_OnFoot = _inputActionAsset.FindActionMap("onFoot");
        _inputActionMap_OnFoot.Enable();
        _inputActionMap_Camera = _inputActionAsset.FindActionMap("Camera");
        _inputActionMap_Camera.Enable();
        _inputActionMap_Interactable = _inputActionAsset.FindActionMap("Interact");
        _inputActionMap_Interactable.Enable();
        
        input_move = _inputActionMap_OnFoot.FindAction("move");
        input_jump = _inputActionMap_OnFoot.FindAction("jump");
        input_ragdoll =_inputActionMap_OnFoot.FindAction("ragdoll");
        input_kick =_inputActionMap_OnFoot.FindAction("kick");
        
        input_interact = _inputActionMap_Interactable.FindAction("Interact");
        input_fire = _inputActionMap_Interactable.FindAction("Fire");
        input_grable = _inputActionMap_Interactable.FindAction("Grab");
        input_melee = _inputActionMap_Interactable.FindAction("Melee");


        
        input_move.performed += context => OnInputMove(context);
        input_move.canceled += ctx => OnInputMove(ctx);
        input_jump.performed += context => OnInputJump(context);
        input_jump.canceled += ctx => OnInputJump(ctx);
        
        input_move = _inputActionMap_Camera.FindAction("look");
        input_move.performed += context => OnInputLook(context);
        input_move.canceled += ctx => OnInputLook(ctx);

        input_ragdoll.performed += ct => ToggleRagdoll();

        input_interact.performed += context => OnInteract(context);

        
        input_fire.performed += context => OnFire(context);
        input_fire.canceled += context => OnFire(context);
        
        input_kick.performed += context => OnKick(context);
        input_kick.canceled += context => OnKick(context);


        input_melee.performed += context => OnMelee(context);
        input_melee.canceled += context => OnMelee(context);

        



        _HoldRb = GetComponent<HoldRB>();
        animator.SetBool("land",true);

    }


    public void OnInputMove(InputAction.CallbackContext context)
    {
       
        
        if (context.performed)
        {
            movementState = 1;
            inputMoveDir.x = context.ReadValue<Vector2>().x;
            inputMoveDir.z = context.ReadValue<Vector2>().y;
            Debug.Log("movemnt state:"+ movementState);

        }
        if (context.canceled)
        {
            if (DeacclerationMovement == 0f)
            {
                movementState = 0;
            }
            else
            {
                movementState = 3;
//                Debug.Log("movemnt state:"+ movementState);
            }
            

        }
           //Debug.Log(inputMoveDir);
        
    }

    
    
    public void OnInputJump(InputAction.CallbackContext context)
    {
        // TODO fixjump
        
        Debug.Log("AHHHH");
        if (!isinAir)
        {
            animator.SetBool("jump",true);

            isinAir = true;
            externalVilocityOfPlayer = -gobalGravity;
            animator.SetBool("jump",false);

        }
        
        

    }
    
    public void OnInputLook(InputAction.CallbackContext context)
    {
        // TODO mpove to camera
        inputCameraVector.x = context.ReadValue<Vector2>().x;
        inputCameraVector.y = context.ReadValue<Vector2>().y;
        

    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("E");
        if (_Raycaster.hitHappend )
        {

          
            if(_Raycaster.hit.transform.TryGetComponent(out  GrabaleItem item))
            {
                //item.Grab(transform);
                //_HoldRb.rigidBody = _Raycaster.hit.rigidbody;
                
                item.Grab(leftHandTransform);
           
                
                itemSlot1 = (ITriggerable)item;
                //_HoldRb.setRB(_Raycaster.hit.rigidbody);
                //_HoldRb.Grab(transform.position);


            }
           
        }
    }
    
    /// <summary>
    /// make th eplayer kick 
    /// </summary>
    /// <param name="context"> the input of new input system</param>
    public void OnKick(InputAction.CallbackContext context)
    {
        if( context.performed)
        {
            if (kickState == 0)
            {
                kickChargeMutiplyerValue = 1;
                StartCoroutine((IEnumerator)OnKickCharge(1f));

            }
            kickState = 1;
            Debug.Log("kickStateL: "+ kickState);

        }
        else if (context.canceled)
        {
            kickState = 2;
          //  kickForce =
            Debug.Log("kickStateL: "+ kickState);

            if (_Raycaster.hit.rigidbody != null)
            {
                _Raycaster.hit.rigidbody.AddForce(_Raycaster.getDirction()*kickChargeMutiplyerValue*500f,ForceMode.Impulse );
                Debug.Log("KICKED !!!!!: "+ kickState+" "+_Raycaster.getDirction());

            }

            
            kickState = 0;
        }
    }

    public IEnumerable OnKickCharge(float intreval)
    {
        
        while (kickChargeMutiplyerValue <= kickForceChageMutiplier)
        {
            kickChargeMutiplyerValue += intreval;
            //Debug.Log(" charge mutipler"+kickChargeMutiplyerValue);
            yield return new WaitForSeconds(intreval);
        }
    }
    
    /// <summary>
    /// make th player melees 
    /// </summary>
    /// <param name="context"> the input of new input system</param>
    public void OnMelee(InputAction.CallbackContext context)
    {
        if( context.performed)
        {
            
            meleeState = 1;
            Debug.Log("meleeState: "+ kickState);

        }
        else if (context.canceled)
        {
            meleeState = 2;
            Debug.Log("meleeState: "+ kickState);

            if (_Raycaster.hit.rigidbody != null)
            {
                _Raycaster.hit.rigidbody.AddForce(transform.forward*500f,ForceMode.Impulse );
                Debug.Log("KICKED !!!!!: "+ kickState+" "+_Raycaster.getDirction());

            }

            
            kickState = 0;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!_characterController.isGrounded && _characterController.enabled) // TODO fixjump
        {
            if (ungrounedTimer <= 0)
            {
                isinAir = true;
                animator.SetBool("fall",true);
                animator.SetBool("land",false);



            }
            ungrounedTimer -= Time.deltaTime;
            
            
            
            

        }
        else
        {
            if (isinAir)
            {
                animator.SetBool("land",true);
                animator.SetBool("fall",false);


            }
            ungrounedTimer = fallDelay;
            isinAir = false;
            externalVilocityOfPlayer.y = 0;
        }

        if (isinAir) // TODO fixjump
        {
            animator.SetBool("fall",true);

            externalVilocityOfPlayer += gobalGravity*Time.deltaTime;
        }

       Movement(Time.deltaTime);
       //Movement m = new Movement();
       
       //_characterController.Move(_movement.MoveInDir(inputMoveDir)*Time.deltaTime);
       _cameraScript.LOOK(inputCameraVector.x, inputCameraVector.y);
       animator.SetFloat("runspeedx",inputCameraVector.x);
       animator.SetFloat("runspeedy",inputCameraVector.y);

       
        
        animator.SetInteger("MovementState", movementState);

    }

    public void Movement(float dealtaTime)
    {
        if (movementState == 1 ||movementState == 2 ) // braking the movement here as long THE playe is in air speed will keep on increasing 
        {
            if (currentSpeed >= maxSpeed && !isinAir)// braking the movement here as long THE playe is in air speed will keep on increasing 
            {

                currentSpeed = maxSpeed;
                movementState = 2;
            }
            currentSpeed += AcclerationMovement * Time.deltaTime;
            
        } else if (movementState == 3)
        {
            
            

            if (!isinAir )
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

        _characterController.Move(movement*Time.deltaTime);

        
    }

    /// <summary>
    /// disables the player movmeent 
    /// </summary>
    public void DisableControlls()
    {
        //todo
        _characterController.enabled = false;

    }

    /// <summary>
    /// enable the player movment
    /// </summary>
    public void EnableControlls()
    {
        //todo
        Vector3 temcurrentPosition = ragdollOBJ.transform.GetChild(0).position;
        _characterController.enabled = true;
            
        transform.position = temcurrentPosition;// corrects the chacter controller postio to the current postiion of the player after ragedoll 


    }
    /// <summary>
    /// toggles player movment
    /// </summary>
    public void ToggleControlls()
    {
        //todo
        if (_characterController.enabled)
        {
            DisableControlls();
        }
        else
        {
            EnableControlls();
        }


    }

    /// <summary>
    /// enables the ragdoll
    /// </summary>
    public void DoRagdoll() // todo need better way to mamge Ragdoll
    {
        DisableControlls();
        Ragdolltest.makeAllEBFREE();
    }
    /// <summary>
    /// disables the ragdoll
    /// </summary>
    public void UnRagdoll() // todo need better way to mamge Ragdoll
    {
        EnableControlls();
        Ragdolltest.makeAllEBStatic();
    }
    /// <summary>
    /// toggols  ragdoll
    /// </summary>
    public void ToggleRagdoll() // todo need better way to mamge Ragdoll
    {
        ToggleControlls();
        Ragdolltest.TogglRagdoll();
    }


    /// <summary>
    /// death of the player
    /// so does ragdoll
    /// ... 
    /// </summary>
    public void OnDeath()
    {
        this.DoRagdoll();
    }
    /// <summary>
    /// called after death when the player id Revived
    /// </summary>
    public void OnRevive()
    {
        this.DoRagdoll();
    }


    

}
