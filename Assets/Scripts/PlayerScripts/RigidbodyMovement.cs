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
    private float sensitivity = 2f;
    public Transform PlayerCamera;
    public Rigidbody PlayerBody;

    bool isgrounded = false;
    float force = 8f;
    private int jumpCounter = 1;

    public float groundCheckDistance;
    public float bufferCheckDistance = 0.1f;

    private void Awake()
    {
        playerActions = new PlayerInputController();
        playerActions.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Vector2 moveVec = playerActions.Move.Move.ReadValue<Vector2>();

        // Calculate movement direction based on the player's forward direction
        Vector3 moveDirection = PlayerCamera.forward * moveVec.y + PlayerCamera.right * moveVec.x;
        moveDirection.y = 0f; // Keep the movement only in the horizontal plane
        moveDirection.Normalize();

        // Apply movement force
        PlayerBody.AddForce(moveDirection * speed, ForceMode.Force);


        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + bufferCheckDistance;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (isgrounded == true)
        {

            jumpCounter--;

            Debug.Log("Jump:" + context.phase);
            if (context.performed)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }
            

                //if (jumpCounter == 0)
                   // return;

                Debug.Log("Jump");
                //PlayerBody.velocity = Vector2.up * jumpHeight;
                

                PlayerBody.velocity = new Vector3(PlayerBody.velocity.x, force);
               

                isgrounded = false;


        }

    }

        public void MovePlayerCamera(InputAction.CallbackContext context)
    {

        // Adjust the rotation of the player's body around the y-axis
        float yRot = transform.eulerAngles.y + context.ReadValue<Vector2>().x * sensitivity;
        transform.rotation = Quaternion.Euler(0f, yRot, 0f);

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveVec = context.ReadValue<Vector2>();
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }


}
