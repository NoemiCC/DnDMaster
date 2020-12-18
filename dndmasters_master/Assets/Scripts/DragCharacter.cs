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
    private GameObject room;
    
    // Start is called before the first frame update
    void Start()
    {
        zeropos = transform.position;
        
        // reset all
        // PlayerPrefs.DeleteKey(this.name);

        if (PlayerPrefs.GetString(this.name) == "room1")
        {
            transform.position = newpos1;
            this.GetComponent<Collider2D>().enabled = false;
        }
        if (PlayerPrefs.GetString(this.name) == "room2")
        {
            transform.position = newpos2;
            this.GetComponent<Collider2D>().enabled = false;
        }
        if (PlayerPrefs.GetString(this.name) == "room3")
        {
            transform.position = newpos3;
            this.GetComponent<Collider2D>().enabled = false;
        }
        if (PlayerPrefs.GetString(this.name) == "room4")
        {
            transform.position = newpos4;
            this.GetComponent<Collider2D>().enabled = false;
        }
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
            room = GameObject.Find("Inn/room1/halo_room1");
            room.SetActive(true);
            // Debug.Log("Correct room " + collider.gameObject.name + " bool " + room1);
        }
        else if (collider.gameObject.name == "room_2")
        {
            room2 = true;
            room = GameObject.Find("Inn/room2/halo_room2");
            room.SetActive(true);
        }
        else if (collider.gameObject.name == "room_3")
        {
            room3 = true;
            room = GameObject.Find("Inn/room3/halo_room3");
            room.SetActive(true);
        }
        else if (collider.gameObject.name == "room_4")
        {
            room4 = true;
            room = GameObject.Find("Inn/room4/halo_room4");
            room.SetActive(true);
        }
        else
        {
            room1 = false;
            room2 = false;
            room3 = false;
            room4 = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "room_1" || other.gameObject.name == "room_1_taken")
        {
            room1 = false;
            room = GameObject.Find("Inn/room1/halo_room1");
            room.SetActive(false);
            // Debug.Log("Out " + other.gameObject.name + " bool " + room1);
        }
        else if (other.gameObject.name == "room_2" || other.gameObject.name == "room_2_taken")
        {
            room2 = false;
            room = GameObject.Find("Inn/room2/halo_room2");
            room.SetActive(false);
        }

        else if (other.gameObject.name == "room_3" || other.gameObject.name == "room_3_taken")
        {
            room3 = false;
            room = GameObject.Find("Inn/room3/halo_room3");
            room.SetActive(false);
        }

        else if (other.gameObject.name == "room_4" || other.gameObject.name == "room_4_taken")
        {
            room4 = false;
            room = GameObject.Find("Inn/room4/halo_room4");
            room.SetActive(false);
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
            // Cambiar de nombre -  habitacion tomada
            room = GameObject.Find("Inn/room1/room_1");
            room.name = "room_1_taken";

            // Desactivar halo por overrite de OnTriggerExit2D
            var room_t = GameObject.Find("Inn/room1/halo_room1");
            room_t.SetActive(false);

            this.GetComponent<Collider2D>().enabled = false;
            transform.position = newpos1;

            PlayerPrefs.SetString(this.name, "room1");
            Globals.taken_room1 = true;
        }
        else if (room2 == true)
        {
            // Cambiar de nombre -  habitacion tomada
            room = GameObject.Find("Inn/room2/room_2");
            room.name = "room_2_taken";

            // Desactivar halo por overrite de OnTriggerExit2D
            var room_t = GameObject.Find("Inn/room2/halo_room2");
            room_t.SetActive(false);

            transform.position = newpos2;
            this.GetComponent<Collider2D>().enabled = false;
            PlayerPrefs.SetString(this.name, "room2");
            Globals.taken_room2 = true;
        }
        else if (room3 == true)
        {
            // Cambiar de nombre -  habitacion tomada
            room = GameObject.Find("Inn/room3/room_3");
            room.name = "room_3_taken";

            // Desactivar halo por overrite de OnTriggerExit2D
            var room_t = GameObject.Find("Inn/room3/halo_room3");
            room_t.SetActive(false);

            transform.position = newpos3;
            this.GetComponent<Collider2D>().enabled = false;
            PlayerPrefs.SetString(this.name, "room3");
            Globals.taken_room3 = true;
        }
        else if (room4 == true)
        {
            // Cambiar de nombre -  habitacion tomada
            room = GameObject.Find("Inn/room4/room_4");
            room.name = "room_4_taken";

            // Desactivar halo por overrite de OnTriggerExit2D
            var room_t = GameObject.Find("Inn/room4/halo_room4");
            room_t.SetActive(false);

            transform.position = newpos4;
            this.GetComponent<Collider2D>().enabled = false;
            PlayerPrefs.SetString(this.name, "room4");
            Globals.taken_room4 = true;
        }
        else
        {
            transform.position = zeropos;
        }
    }

}
