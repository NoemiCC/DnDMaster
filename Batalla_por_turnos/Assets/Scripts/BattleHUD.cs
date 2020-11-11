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
    public void SetHUD (Unit unit)
    {
        nameText.text = unit.unitName;
    }
}
