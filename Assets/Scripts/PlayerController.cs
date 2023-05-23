using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    private float gravity = 1000f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float verticalRotation = 0f;
    private Vector3 moveDirection;
    private Ray ray;
    public ParticleController particleController;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        particleController = GetComponent<ParticleController>();


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
        Quaternion rotation = Quaternion.Euler(-mouseY, mouseX, 0f);
        ray.direction = rotation * playerCamera.transform.forward;


        // Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        

    }

    void Shoot()
    {
        RaycastHit hit;





        switch (GunsController.currentGun)
        {
            case GunsController.Guns.Pistol:
                if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "soft"))
                {
                    OpponentController opponent = hit.collider.gameObject.GetComponent<OpponentController>();
                    if (opponent != null)
                    {
                        opponent.Hit();
                        //particleController.StartParticleSystem(hit.point);

                    }
                }
                break;
            case GunsController.Guns.PM:
                if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "medium"))
                {
                    OpponentController opponent = hit.collider.gameObject.GetComponent<OpponentController>();
                    if (opponent != null)
                    {
                        opponent.Hit();
                    }
                }
                break;
            case GunsController.Guns.M4:
                if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "hard"))
                {
                    OpponentController opponent = hit.collider.gameObject.GetComponent<OpponentController>();
                    if (opponent != null)
                    {
                        opponent.Hit();
                    }
                }
                break;


        }


        Debug.Log("Shoot!");
    }
}
