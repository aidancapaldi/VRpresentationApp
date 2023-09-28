using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player speed
    public float moveSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();
    }

    // Handle keyboard input from the player and move the player
    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
