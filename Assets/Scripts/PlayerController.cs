// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     // Player speed
//     public float moveSpeed = 2.0f;

//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         KeyboardMovement();
//     }

//     // Handle keyboard input from the player and move the player
//     void KeyboardMovement()
//     {
//         Vector3 dir = new Vector3(0, 0, 0);
//         dir.x = Input.GetAxis("Horizontal");
//         dir.z = -Input.GetAxis("Vertical");
//         transform.Translate(dir * moveSpeed * Time.deltaTime);
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}