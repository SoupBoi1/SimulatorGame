using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    public InputActionAsset _inputActionAsset;
    private InputActionMap _inputActionMap_OnFoot;
    private InputActionMap _inputActionMap_Camera;

    
    private InputAction input_move;
    private InputAction input_jump;
    
    private InputAction input_look;
    
    private Vector3 inputMoveDir;
    private float inputMoveDirx;
    private float inputMoveDiry;
    private Vector3 inputCameraVector;
    
     

    private Transform _transform;
    public Transform cameraPosition;
    public Animator animator;

    

    
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
    public float DeacclerationMovement=0;
    public float TurnDeacclerationMovement=100;
    public float maxSpeed = 10;

    
    public Vector3 gobalGravity; // the gravity of the player's enviorment

    
    public Vector3 movement;// current movment of th vilocity of the player
    public Vector3 externalVilocityOfPlayer; // vilocity of player cause by gravity and other forces
    public Vector3 rotateBody; // current vilosity  of  player's rotation
    
    // Start is called before the first frame update
    void Start()
    {
        inputMoveDir = Vector3.zero;
        inputCameraVector = Vector3.zero;
        rotateBody = Vector3.zero;
        
        gobalGravity = Physics.gravity;
        externalVilocityOfPlayer = gobalGravity;
        _transform = GetComponent<Transform>();
        
        _characterController = GetComponent<CharacterController>();
        _inputActionMap_OnFoot = _inputActionAsset.FindActionMap("onFoot");
        _inputActionMap_OnFoot.Enable();
        _inputActionMap_Camera = _inputActionAsset.FindActionMap("Camera");
        _inputActionMap_Camera.Enable();
        
        input_move = _inputActionMap_OnFoot.FindAction("move");
        input_jump = _inputActionMap_OnFoot.FindAction("jump");
        
        
        input_move.performed += context => OnInputMove(context);
        input_move.canceled += ctx => OnInputMove(ctx);
        input_jump.performed += context => OnInputJump(context);
        input_jump.canceled += ctx => OnInputJump(ctx);
        
        input_move = _inputActionMap_Camera.FindAction("look");
        input_move.performed += context => OnInputLook(context);
        input_move.canceled += ctx => OnInputLook(ctx);
        

        
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
                Debug.Log("movemnt state:"+ movementState);
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
    

    // Update is called once per frame
    void Update()
    {
        if (!_characterController.isGrounded) // TODO fixjump
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

  
        rotateBody += new Vector3(inputCameraVector.x, inputCameraVector.y);
        transform.localRotation =  Quaternion.Euler(0,rotateBody.x,0);
        
        cameraPosition.localRotation =  Quaternion.Euler(-rotateBody.y,0,0);

        
        animator.SetInteger("MovementState", movementState);

    }

    public void Movement(float dealtaTime)
    {
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
            
            

            currentSpeed -= DeacclerationMovement * Time.deltaTime;
            
            if (currentSpeed <=0f )
            {

                currentSpeed = 0f;
                movementState = 0;
            }
        }
        movement = ((_transform.forward *inputMoveDir.z)  + (_transform.right *inputMoveDir.x )) * currentSpeed +(externalVilocityOfPlayer) ; 

        _characterController.Move(movement*Time.deltaTime);

        
    }
    
    
    
}
