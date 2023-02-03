using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Raise : MonoBehaviour
{
    private bool goUp = true;
    private float maxY = 51;
    private float minY = 30.3f;
    private float speed = 9.0f;
    Rigidbody rb;
    private bool initialContact = false;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (initialContact) {
            Vector3 movement = new Vector3(0, goUp ? .5f : -.5f, 0) * speed * Time.deltaTime;
            transform.Translate(movement);
            if (transform.position.y <= minY)
            {
                initialContact = false;
            }
            if (transform.position.y >= maxY || transform.position.y <= minY)
            {
                goUp = goUp ? false : true;
            }
            movement = transform.TransformDirection(movement);
            rb.MovePosition(movement); //= movement;  
        }
    }
    private void OnTriggerEnter(Collider other){

        if (other.tag == "Player")
        {
            initialContact = true;
        }
    }
}
