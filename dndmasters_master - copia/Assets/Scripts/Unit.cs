using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define los atributos de las unidades en batalla
// Hability se va a quedar mal escrito
public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int damage;

    public int maxHP;
    public int currentHP;

    public int currentPosition;
    public string facing;

    public string hability1;
    public string hability2;
    public string hability3;
    public string hability4;
}
