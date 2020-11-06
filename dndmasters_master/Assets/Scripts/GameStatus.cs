using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public int level = 1;
    public int coins = 0;
    public bool beginner = true;

    Text moneyText;
    public GameObject money;

    // Start is called before the first frame update
    void Start()
    {
        //LoadPlayer();
    }

    void Update()
    {
        ChangeCoins();
    }

	public void SavePlayer ()
	{
		SaveSystem.SavePlayer(this);
	}

	// decidir cuando cargar partida.
    public void LoadPlayer ()
	{
		PlayerData data = SaveSystem.LoadPlayer();

		level = data.level;
    	coins = data.coins;
    	beginner = data.beginner;
	}

    public void ChangeCoins ()
    {
        moneyText = money.GetComponent<Text>();
        moneyText.text = "Dinero: $" + PlayerPrefs.GetInt("money", 0);
    }

}
