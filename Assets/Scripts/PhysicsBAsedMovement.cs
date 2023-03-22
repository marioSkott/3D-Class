using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBAsedMovement : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    [SerializeField] float moveSpeed;
    [SerializeField] float JumpSpeed;
    [SerializeField] float topSpeed;
    [SerializeField] Rigidbody myBody;
    [SerializeField] float roationSpeed;
    [SerializeField] bool isGrouneded;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float rayCastLenght;
    private void FixedUpdate()
    {
        float Mouse = Input.GetAxis(MouseX);
        transform.Rotate(Mouse * Time.deltaTime * Vector3.up * roationSpeed, Space.World);

        if (myBody.velocity.magnitude > topSpeed)
        {
            return;
        }
        isGrouneded = Physics.Raycast(transform.position, Vector3.down, rayCastLenght, groundMask);


        if (Input.GetKey(KeyCode.Space))
        {
            myBody.AddForce(new Vector2(myBody.velocity.x, JumpSpeed), ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            myBody.AddForce(-transform.right * Time.deltaTime * moveSpeed, ForceMode.Impulse);
        }

            if (Input.GetKey(KeyCode.D))
            {
                myBody.AddForce(transform.right * Time.deltaTime * moveSpeed, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.W))
            {
                myBody.AddForce(transform.forward * Time.deltaTime * moveSpeed, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.S))
            {
                myBody.AddForce(-transform.forward * Time.deltaTime * moveSpeed, ForceMode.Impulse);
            }


        
        //  myBody.AddForce(movement, ForceMode.Impulse);

    }
}
