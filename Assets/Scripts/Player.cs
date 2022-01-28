using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private Rigidbody rigidbodyComponent;
    public bool isSprinting = false;
    public int SpeedValue = 100;
    bool isGrounded = true;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += moveDirection / (SpeedValue - 250);  
        }
        else
        {
            transform.position += moveDirection / SpeedValue;
        }
    }

    void FixedUpdate()
    { 
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        
	//skok z monetami
        if (jumpKeyWasPressed == true)
        {
            rigidbodyComponent.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        //Niszczenie monet
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            Debug.Log("Sleep() -_-");
            rigidbodyComponent.Sleep();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            isGrounded = true;
            
        }
    }
 
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            isGrounded = false;
        }

    }
    
}
