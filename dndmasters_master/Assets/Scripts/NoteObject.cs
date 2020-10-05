using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Enter trigger");
        if(other.name == "Player")
        {
            gameObject.SetActive(false);
            GameManager.instance.NoteHit();
        }else
        {
            GameManager.instance.NoteMissed();
        }

    }
}
