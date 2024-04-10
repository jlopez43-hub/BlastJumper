using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/*
 * Author[Judith Lopez]
 * Date[03/31/2024]
 * RigidbodyMovement attached to the player
 */

public class RigidbodyMovement : MonoBehaviour
{
    public float speed = 3f;
    private PlayerInputController playerActions;

    public float jumpHeight = 10f;

    //camera movement variables
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float sensitivity;
    public Transform PlayerCamera;
    public Rigidbody PlayerBody;
    bool isgrounded = false;
    float force = 28f;

   

    private void Awake()
    {
        playerActions = new PlayerInputController();
        playerActions.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Vector2 moveInput = playerActions.Move.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        // Convert the local movement direction to global space
        moveDirection = transform.TransformDirection(moveDirection);

        // Apply force to move the Rigidbody
        GetComponent<Rigidbody>().AddForce(moveDirection * speed, ForceMode.Force);

        //will be only to jump if the player is on the floor
        if (Input.GetKeyDown("space"))
        {
            if (isgrounded == true)
                PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, force);
            isgrounded = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        Debug.Log("Jump:" + context.phase);
        if (context.performed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        if (isgrounded == true)
        {
            PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, force);
        }
        isgrounded = false;
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

    private void OnTriggerEnter(Collider theCollision)
    {
       if (theCollision.gameObject.tag == "floor")
       {
            isgrounded = true;
       }
        else
        {
            isgrounded = false;
        }

    }
}
