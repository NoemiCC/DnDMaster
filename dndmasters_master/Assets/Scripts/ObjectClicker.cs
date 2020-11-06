using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Apoya a BattleSystem entregando información de las unidades que se están seleccionando
public class ObjectClicker : MonoBehaviour
{

    public Text unitName;
    public Text hability1;
    public Text hability2;
    public Text hability3;
    public Text hability4;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            unitName.text = this.gameObject.GetComponent<Unit>().unitName;
            hability1.text = this.gameObject.GetComponent<Unit>().hability1;
            hability2.text = this.gameObject.GetComponent<Unit>().hability2;
            hability3.text = this.gameObject.GetComponent<Unit>().hability3;
            hability4.text = this.gameObject.GetComponent<Unit>().hability4;
            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1.02f, 0);
        }
    }
    private void OnMouseUp()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1.02f, 0);
        
    }
}
