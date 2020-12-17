using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    
    public int level;
    public int coins;
    public bool beginner;

    public PlayerData (GameStatus status)
    {
    	level = status.level;
    	coins = status.coins;
    	beginner = status.beginner;
    }

}
