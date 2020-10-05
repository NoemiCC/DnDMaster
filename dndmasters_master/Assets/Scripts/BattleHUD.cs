using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Muestra los botones y el nombre de la unidad (agregar también el turno de quien es)

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Button hability1;
    public Button hability2;
    public Button hability3;
    public Button hability4;

    public Text hability1text;
    public Text hability2text;
    public Text hability3text;
    public Text hability4text;

    void Start()
    {
        Debug.Log(hability1);
        Button btn1 = hability1.GetComponent<Button>();
        Button btn2 = hability2.GetComponent<Button>();
        Button btn3 = hability3.GetComponent<Button>();
        Button btn4 = hability4.GetComponent<Button>();


        Debug.Log(btn1);
        btn1.onClick.AddListener(TaskOnClick);
        btn2.onClick.AddListener(TaskOnClick);
        btn3.onClick.AddListener(TaskOnClick);
        btn4.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("hola");
    }

    public void SetHUD (Unit unit)
    {
        nameText.text = unit.unitName;
    }
}
