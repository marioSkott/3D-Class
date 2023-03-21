using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBAsedMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float topSpeed;
    [SerializeField] Rigidbody myBody;
    private void FixedUpdate()
    {

        if (myBody.velocity.magnitude > topSpeed)
        {
            return;
        }
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement  = new Vector3(horizontal, 0, vertical);
        
        myBody.AddForce(movement, ForceMode.Impulse);
      
    }
}
