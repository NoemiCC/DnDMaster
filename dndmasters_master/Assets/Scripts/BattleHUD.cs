using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        Button btn1 = hability1.GetComponent<Button>();
        Button btn2 = hability2.GetComponent<Button>();
        Button btn3 = hability3.GetComponent<Button>();
        Button btn4 = hability4.GetComponent<Button>();



        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
        btn3.onClick.AddListener(TaskOnClick3);
        btn4.onClick.AddListener(TaskOnClick4);
    }
    void TaskOnClick1()
    {
        Text text = hability1.GetComponent<Button>().GetComponentInChildren<Text>();
        ReconMinigame(text);
    }

    void TaskOnClick2()
    {
        Text text = hability2.GetComponent<Button>().GetComponentInChildren<Text>();
        ReconMinigame(text);
    }
    void TaskOnClick3()
    {
        Text text = hability3.GetComponent<Button>().GetComponentInChildren<Text>();
        ReconMinigame(text);
    }
    void TaskOnClick4()
    {
        Text text = hability4.GetComponent<Button>().GetComponentInChildren<Text>();
        ReconMinigame(text);
    }


    // Agregar aquí el nombre de todos los minijuegos para ir a su escena
    void ReconMinigame(Text text)
    {
        if(text.text == "Réquiem")
        {
            SceneManager.LoadScene( "MusicGame" );
        }

        if (text.text == "Bloqueo de Chi")
        {
            SceneManager.LoadScene("MonkGame");
        }

        if (text.text == "Invocación")
        {
            SceneManager.LoadScene("CrackTheCode");
        }
    }

    public void SetHUD (Unit unit)
    {
        nameText.text = unit.unitName;
    }
}
