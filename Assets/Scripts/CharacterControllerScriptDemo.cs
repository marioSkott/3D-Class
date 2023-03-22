using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScriptDemo : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed;
    [SerializeField] float JumpSpeed;
  
    [SerializeField] float gravity;
    [SerializeField] Vector3 moveBody;
    [SerializeField] bool isGrouneded;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float rayCastLenght;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
      
        isGrouneded = Physics.Raycast(transform.position,Vector3.down, rayCastLenght, groundMask);

        moveBody = new Vector3(movement.x, moveBody.y, movement.z);
        if (isGrouneded)
        {
            moveBody.y = 0;
        }
        if (!isGrouneded)
        {
            moveBody.y -= gravity*Time.deltaTime;
        }
        if (isGrouneded && Input.GetKeyDown(KeyCode.Space))
        {
            moveBody.y = JumpSpeed;
        }
       
        
        controller.Move(moveBody * Time.deltaTime * moveSpeed);
    }



}
