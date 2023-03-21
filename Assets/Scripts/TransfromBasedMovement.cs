using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransfromBasedMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > -15)
        {
            transform.position += Vector3.left * Time.deltaTime*moveSpeed;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 15)
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W) && transform.position.z < 15)
        {
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S)&&transform.position.z > -15)
        {
            transform.position += Vector3.back * Time.deltaTime * moveSpeed;
        }
    }
}
