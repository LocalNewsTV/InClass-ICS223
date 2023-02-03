using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity = -9.81f;
    private float yVelocity = 0.0f;
    private float groundedYVelocity = -4.0f;
    private float jumpHeight = 3.0f;
    private float jumpTime = 0.5f;
    private float initialJumpVelocity;
    private int numJumps;
   

    [SerializeField] private float speed = 9.0f;
    [SerializeField] private float rotationSpeed = 720.0f;
    [SerializeField] private int jumpMax = 2;
    [SerializeField] private CharacterController cc;
    float horiz;
    float vert;

    public void Respawn(Vector3 spawnPoint)
    {
        //stop falling
        yVelocity = groundedYVelocity;
        //set to given position
        transform.position = spawnPoint;
        //apply transform changes  to the physics engine manually
        Physics.SyncTransforms();
    }

    // Start is called before the first frame update
    void Start()
    {
        numJumps = jumpMax;
        float timeToApex = jumpTime / 2.0f;
        gravity = (-2 * jumpHeight) / Mathf.Pow(timeToApex, 2);

        initialJumpVelocity = (2 * jumpHeight) / timeToApex;
    }

    // Update is called once per frame
    void Update()
    {
        vert = Input.GetAxis("Vertical");
        horiz = Input.GetAxis("Horizontal");


        Vector3 movement = new Vector3(horiz, 0, vert);
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movement = transform.TransformDirection(movement);

        yVelocity += gravity * Time.deltaTime;
        if(cc.isGrounded && yVelocity < 0f){
            numJumps = jumpMax;
            yVelocity = groundedYVelocity;
        }

        movement *= speed;
        if (Input.GetButtonDown("Jump") && numJumps > 0){
            yVelocity = initialJumpVelocity;
            numJumps -= 1;
        }
        movement.y = yVelocity;
        movement *= Time.deltaTime;

        cc.Move(movement);

        Vector3 rotation = Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X");
        transform.Rotate(rotation);
    }
}
