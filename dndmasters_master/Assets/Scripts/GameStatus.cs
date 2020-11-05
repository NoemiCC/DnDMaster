using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public int level = 1;
    public int coins = 0;
    public bool beginner = true;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
    }

	public void SavePlayer ()
	{
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer ()
	{
		PlayerData data = SaveSystem.LoadPlayer();

		level = data.level;
    	coins = data.coins;
    	beginner = data.beginner;
	}

}
