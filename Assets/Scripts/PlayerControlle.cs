using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    private int count;
 
    private void Start()
    {
     //   count = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame before phisics calculculaition
    void FixedUpdate()
    {
        //Random rnd = new Random();
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       
        rb.AddForce(movement*speed);
        if (Input.GetButtonDown("Jump"))
        {
    
                rb.AddForce(new Vector3(0, 10, 0), ForceMode.VelocityChange);
           
   
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
        }

    }
}

