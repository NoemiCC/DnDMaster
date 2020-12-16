using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCharacter : MonoBehaviour
{
    Vector3 newpos1 = new Vector2(1.28f, 2.45f);
    Vector3 newpos2 = new Vector2(0.17f, 0.18f);
    Vector3 newpos3 = new Vector2(3.51f, -1.68f);
    Vector3 newpos4 = new Vector2(-5.52f, -0.81f);
    Vector3 zeropos;
    private bool room1;
    private bool room2;
    private bool room3;
    private bool room4;
    
    // Start is called before the first frame update
    void Start()
    {
        zeropos = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "room_1")
        {
            room1 = true;
            // Debug.Log("Correct room" + collider.gameObject.name + "bool" + room2);
        }
        else if (collider.gameObject.name == "room_2")
        {
            room2 = true;
        }
        else if (collider.gameObject.name == "room_3")
        {
            room3 = true;
        }
        else if (collider.gameObject.name == "room_4")
        {
            room4 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "room_1")
        {
            room1 = false;
            // Debug.Log("Out" + other.gameObject.name + "bool" + room2);
        }
        else if (other.gameObject.name == "room_2")
        {
            room2 = false;
        }

        else if (other.gameObject.name == "room_3")
        {
            room3 = false;
        }

        else if (other.gameObject.name == "room_4")
        {
            room4 = false;
        }
    }

	void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }

    void OnMouseUp()
    {
        if (room1 == true)
        {
            transform.position = newpos1;
        }
        else if (room2 == true)
        {
            transform.position = newpos2;
        }
        else if (room3 == true)
        {
            transform.position = newpos3;
        }
        else if (room4 == true)
        {
            transform.position = newpos4;
        }
        else
        {
            transform.position = zeropos;
        }
    }

}
