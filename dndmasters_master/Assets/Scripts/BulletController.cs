using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private BulletController controller;
    public float Tempo;

    public bool hasStarted;
    void Start()
    {
        Tempo = Tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            /*if(Input.anyKeyDown)
            {
                hasStarted = true;
            }*/

        } else 
        {
            transform.position -= new Vector3(0f, Tempo * Time.deltaTime, 0f);
        }
    }


}
