using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float mouseSensitivity = 80.0f;
    public float clampAngle = 360.0f;
    private float rotX = 0.0f;
    private float rotY = 0.0f;
    private Rigidbody rb;
    public bool GameOn = false;
    public AudioSource audioSource;





    void Start()
    {

        GameOn = true;
        rb = GetComponent<Rigidbody>();
  
    }


    void Update()
    {
        // mouse move diatance
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Adjust player view according to mouse sensitivity
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
        rotY += mouseX * mouseSensitivity * Time.deltaTime;

        // limit player's view
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        // Separate the player's perspective from the model's orientation
        // 分离玩家和转向视角
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        // plaeyr' move direction
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(verticalInput) > 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = transform.TransformDirection(movement);

        // move speed
        movement *= moveSpeed;

        // 将移动向量应用到玩家模型的Rigidbody组件上
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

}