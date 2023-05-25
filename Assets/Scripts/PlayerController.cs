using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController characterController;
    private Camera playerCamera;

    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    private float gravity = 1000f;

    private float verticalRotation = 0f;
    private Vector3 moveDirection;

    private Ray ray;

    public ParticleSystem particle;

    public GameObject gunImage;    
    private Animator animGun;

    public GameObject flameImage;
    private Animator animFlame;

    private SoundManagerScript SoundManager;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        animGun = gunImage.GetComponent<Animator>();
        animFlame = flameImage.GetComponent<Animator>();

        SoundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();

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

        switch (GunsController.currentGun)
        {
            case GunsController.Guns.Pistol:
                if (Input.GetButtonDown("Fire1"))
                {

                    if (!animGun.GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
                    {
                        SoundManager.PlaySound(SoundManagerScript.Sounds.pistolSound);
                        Shoot();

                    }
                }
                break;
            case GunsController.Guns.PM:
                if (Input.GetButton("Fire1"))
                {

                    if (!animGun.GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
                    {
                        SoundManager.PlaySound(SoundManagerScript.Sounds.pmSound);

                        Shoot();

                    }
                }
                break;
            case GunsController.Guns.M4:
                if (Input.GetButton("Fire1"))
                {

                    if (!animGun.GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
                    {
                        SoundManager.PlaySound(SoundManagerScript.Sounds.m4Sound);

                        Shoot();

                    }
                }
                break;

        }

    }

    private void LateUpdate()
    {
        if(moveDirection.x != 0)
        {
            animGun.SetBool("Walking", true);
        }
        else
        {
            animGun.SetBool("Walking", false);
        }


    }

    void Shoot()
    {
        RaycastHit hit;

        animGun.SetTrigger("Shooting");
        animFlame.SetTrigger("Flame");

        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(particle, hit.point, Quaternion.identity);

        }

        switch (GunsController.currentGun)
        {
            case GunsController.Guns.Pistol:
                if (Physics.Raycast(ray, out hit) && (hit.collider.gameObject.tag == "soft"))
                {
                    OpponentController opponent = hit.collider.gameObject.GetComponent<OpponentController>();
                    if (opponent != null)
                    {
                        opponent.Hit();
                    }
                }
                break;
            case GunsController.Guns.PM:
                if (Physics.Raycast(ray, out hit) && ((hit.collider.gameObject.tag == "soft") || (hit.collider.gameObject.tag == "medium")))
                {
                    OpponentController opponent = hit.collider.gameObject.GetComponent<OpponentController>();
                    if (opponent != null)
                    {
                        opponent.Hit();
                    }
                }
                break;
            case GunsController.Guns.M4:
                if (Physics.Raycast(ray, out hit))
                {
                    OpponentController opponent = hit.collider.gameObject.GetComponent<OpponentController>();
                    if (opponent != null)
                    {
                        opponent.Hit();
                    }
                }
                break;


        }


    }
}
