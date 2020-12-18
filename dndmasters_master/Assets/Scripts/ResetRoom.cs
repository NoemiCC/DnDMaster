using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRoom : MonoBehaviour
{
	public GameObject button;
	public int roomInt;

	public GameObject o_b1;
	public GameObject o_b2;
	public GameObject o_b3;

    Vector3 resetposB = new Vector2(-1.58f, -3.09f);
    Vector3 resetposW = new Vector2(-2.5f, -2.46f);
    Vector3 resetposM = new Vector2(-0.61f, -3.41f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (this.name.Contains("taken") == true)
        {
        	button.SetActive(true);
        }
        else
        {
        	o_b1.SetActive(false);
        	o_b2.SetActive(false);
        	o_b3.SetActive(false);
        }
    }

    public void Reset()
    {
        if (PlayerPrefs.GetString("Bard") == $"room{roomInt}")
        {
        	Globals.taken_room1 = false;
        	var heroe = GameObject.Find("Bard");
            heroe.GetComponent<Collider2D>().enabled = true;
        	heroe.transform.position = resetposB;
        	PlayerPrefs.DeleteKey("Bard");
        }

        if (PlayerPrefs.GetString("Witch") == $"room{roomInt}")
        {
        	Globals.taken_room1 = false;
        	var heroe = GameObject.Find("Witch");
            heroe.GetComponent<Collider2D>().enabled = true;
        	heroe.transform.position = resetposB;
        	PlayerPrefs.DeleteKey("Witch");
        }

        if (PlayerPrefs.GetString("Monk") == $"room{roomInt}")
        {
        	Globals.taken_room1 = false;
        	var heroe = GameObject.Find("Monk");
            heroe.GetComponent<Collider2D>().enabled = true;
        	heroe.transform.position = resetposB;
        	PlayerPrefs.DeleteKey("Monk");
        }
    }

    public void ResetGlobal(int numero)
    {
    	this.name = $"room_{numero}";

    	if (numero == 1)
    	{
	    	Globals.taken_room1 = false;
    	}
    	if (numero == 2)
    	{
	    	Globals.taken_room2 = false;
    	}
    	if (numero == 3)
    	{
	    	Globals.taken_room3 = false;
    	}
    	if (numero == 4)
    	{
	    	Globals.taken_room4 = false;
    	}
    }
}
