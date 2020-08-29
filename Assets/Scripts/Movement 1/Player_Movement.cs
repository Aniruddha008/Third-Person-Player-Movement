using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float rotationSpeed = 2f;
    [SerializeField] float maxHeadRotation = 80.0f;
    [SerializeField] float minHeadRotation = -80.0f;

    [SerializeField] float currentHeadRotation = 0;
    [SerializeField] float yVelocity = 0;
    [SerializeField] float jumpSpeed = 15.0f;
    [SerializeField] float gravity = 30.0f;

    [SerializeField] Transform head;

    CharacterController controller;
    Rigidbody rigidBody;
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);

        currentHeadRotation = Mathf.Clamp(currentHeadRotation + mouseInput.y * rotationSpeed, minHeadRotation, maxHeadRotation);
 
        head.localRotation = Quaternion.identity;
        head.Rotate(Vector3.left, currentHeadRotation);	
        
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //controller.Move(input * speed * Time.deltaTime);
        if (controller.isGrounded)
            {
                yVelocity = 0;
                print(controller.isGrounded);
                if (Input.GetButtonDown("Jump"))
                {
                    print("jump" + yVelocity);
                    yVelocity = jumpSpeed;
                    print("jump" + yVelocity);
                }
            }
        yVelocity -= gravity * Time.deltaTime;
        controller.Move(transform.TransformDirection(input * speed * Time.deltaTime + yVelocity * Vector3.up * Time.deltaTime));

        
        

        
    }
}
