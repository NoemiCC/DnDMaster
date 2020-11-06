using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Photon.Pun;

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

    Boolean toggle;
    
    public PhotonView PV;

    void Start()
    {
        toggle = !toggle;

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
        PV.RPC("ReconMinigame", RpcTarget.All, text.text, nameText.text);
    }

    void TaskOnClick2()
    {
        Text text = hability2.GetComponent<Button>().GetComponentInChildren<Text>();
        PV.RPC("ReconMinigame", RpcTarget.All, text.text, nameText.text);
    }
    void TaskOnClick3()
    {
        Text text = hability3.GetComponent<Button>().GetComponentInChildren<Text>();
        PV.RPC("ReconMinigame", RpcTarget.All, text.text, nameText.text);
    }
    void TaskOnClick4()
    {
        Text text = hability4.GetComponent<Button>().GetComponentInChildren<Text>();
        PV.RPC("ReconMinigame", RpcTarget.All, text.text, nameText.text);
    }

    public void SetHUD (Unit unit) {
        nameText.text = unit.unitName;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            toggle = !toggle;

            if (toggle) {
                hability1.GetComponent<Button>().interactable = true;
                hability2.GetComponent<Button>().interactable = true;
                hability3.GetComponent<Button>().interactable = true;
                hability4.GetComponent<Button>().interactable = true;
            } else {
                hability1.GetComponent<Button>().interactable = false;
                hability2.GetComponent<Button>().interactable = false;
                hability3.GetComponent<Button>().interactable = false;
                hability4.GetComponent<Button>().interactable = false;
            }
                
        }
    }
}
