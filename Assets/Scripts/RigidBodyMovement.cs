using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Judith Lopez
 * 03/26/2024
 * propelling the player when in contact with explosion
 */
public class RigidBodyMovement : MonoBehaviour
{
    public float speed = 3f;
    private PlayerInputController playerActions;
    private PlayerInputController.MoveActions move;

    public float jumpHeight = 10f;

    //camera variables
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float sensitivity;
    public Transform PlayerCamera;
    public Rigidbody PlayerBody;

    private void Awake()
    {
        playerActions = new PlayerInputController();
        move = playerActions.Move;

        playerActions.Enable();
        playerActions.Disable();
        Cursor.lockState = CursorLockMode.Locked;
    }


    //update called once per frame
    private void FixedUpdate()
    {
        Vector2 moveVec = playerActions.Move.Move.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump:" + context.phase);
        if (context.performed)
        {
            Debug.Log("Real Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }



    public void MovePlayerCamera(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());

        xRot -= context.ReadValue<Vector2>().y * sensitivity;

        PlayerCamera.transform.localRotation = Quaternion.Euler(0, xRot, 0f);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }
}
