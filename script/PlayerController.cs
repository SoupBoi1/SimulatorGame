using System.Collections;
using System.Collections.Generic;
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

    

    public bool  inAir;


    public float speed = 10;// movment speed of th player in any dectertions
    
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
        
        

    }


    public void OnInputMove(InputAction.CallbackContext context)
    {
      
        inputMoveDir.x = context.ReadValue<Vector2>().x;
        inputMoveDir.z = context.ReadValue<Vector2>().y;
        
           //Debug.Log(inputMoveDir);
        
    }
    public void OnInputJump(InputAction.CallbackContext context)
    {
        Debug.Log("AHHHH");
        externalVilocityOfPlayer = -gobalGravity;

    }
    
    public void OnInputLook(InputAction.CallbackContext context)
    {
        inputCameraVector.x = context.ReadValue<Vector2>().x;
        inputCameraVector.y = context.ReadValue<Vector2>().y;
        

    }
    

    // Update is called once per frame
    void Update()
    {
        if (!_characterController.isGrounded)
        {
            externalVilocityOfPlayer += gobalGravity*Time.deltaTime;
            inAir = true;
            

        }
        else
        {
            inAir = false;
            externalVilocityOfPlayer.y = 0;
        }
        
        movement = ((_transform.forward *inputMoveDir.z)  + (_transform.right *inputMoveDir.y )) * speed +(externalVilocityOfPlayer) ;

        rotateBody += new Vector3(inputCameraVector.x, inputCameraVector.y);
        transform.localRotation =  Quaternion.Euler(0,-rotateBody.x,0);
        
        cameraPosition.localRotation =  Quaternion.Euler(rotateBody.y,0,0);

        _characterController.Move(movement*Time.deltaTime);
    }
    
    
    
}
