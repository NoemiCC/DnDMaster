using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 direction;
    private int desiredLane = 1;
    public float laneDistance = 1;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.gameOver)
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                if(desiredLane == 3)
                {
                    desiredLane = 2;
                }
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                if(desiredLane == -1)
                {
                    desiredLane = 0;
                }
            }

            Vector2 targetPosition = transform.position.y * transform.up;

            if(desiredLane == 0)
            {
                targetPosition += Vector2.left * laneDistance;
            }else if(desiredLane == 2)
            {
                targetPosition += Vector2.right * laneDistance;
            }
            
            //transform.position = targetPosition;
            transform.position = Vector2.Lerp(transform.position, targetPosition, 1);
        }
    }   
    private void FixedUpdate() 
    {
        //controller.Move(direction * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Player detects trigger");
        
    }
}
