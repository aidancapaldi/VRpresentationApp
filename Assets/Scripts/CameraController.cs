using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1000f;
    public float xRotation = 0f;
    private Transform player;
    private Quaternion localRotate;

    void Start()
    {
        // Cursor should stay locked the the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MouseAiming();
    }
    void MouseAiming()
    {
        // Get the directional inputs, smooth to time
        float MX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float MY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= MY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the player's forward direction to be that of the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        localRotate = transform.localRotation;
        player.Rotate(Vector3.up * MX);
    }
}
