using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    public InputActionAsset _inputActionAsset;
    public InputActionMap _inputActionMap_OnFoot;
    public InputAction input_move;
    public InputAction input_jump;

    public Vector2 inputMoveDir;


    public bool  inAir;


    public float speed = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputActionMap_OnFoot = _inputActionAsset.FindActionMap("onFoot");
        _inputActionMap_OnFoot.Enable();
        input_move = _inputActionMap_OnFoot.FindAction("move");
        input_jump = _inputActionMap_OnFoot.FindAction("jump");
        
        input_move.performed += context => OnInputMove(context);
        input_move.canceled += ctx => OnInputMove(ctx);
        input_jump.performed += context => OnInputJump(context);
        input_jump.canceled += ctx => OnInputJump(ctx);
        

    }


    public void OnInputMove(InputAction.CallbackContext context)
    {
        inputMoveDir = context.ReadValue<Vector2>();
           Debug.Log(inputMoveDir);
        
    }
    public void OnInputJump(InputAction.CallbackContext context)
    {
        Debug.Log("AHHHH");
    }
    

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(inputMoveDir * speed);
    }
}
