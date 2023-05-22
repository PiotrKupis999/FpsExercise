using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float gravity;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private Vector3 moveDirection;
    private Ray ray;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ray = new Ray(transform.position, Vector3.forward);
    }

    void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = transform.TransformDirection(new Vector3(moveHorizontal, 0, moveVertical));
        moveDirection *= movementSpeed;

        moveDirection.y -= gravity * Time.deltaTime;

        // Apply movement
        characterController.Move(moveDirection * Time.deltaTime);

        // Player rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(0f, mouseX, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Move the ray
        ray.origin = transform.position;
        // Rotate the ray
        Quaternion rotation = Quaternion.Euler(-mouseY, mouseX, 0f);
        ray.direction = rotation * playerCamera.transform.forward;

        /*

        // Perform raycast
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            Debug.Log("Hit point: " + hit.point);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            Debug.Log("nth");

        }
        */



        // Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "soft"))
        {
            OpponentController opponent = hit.collider.gameObject.GetComponent<OpponentController>();
            if (opponent != null)
            {
                opponent.Hit();
            }
        }
        Debug.Log("Shoot!");
    }
}
