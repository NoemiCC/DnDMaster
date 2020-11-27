using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class BattleManager : MonoBehaviourPunCallbacks
{
    [PunRPC]
    void UpdatePlayerCount() {
        Globals.playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log("Update player count " + Globals.playerCount);
        if (Globals.playerCount == 1) { Globals.myTurn = true; }
    }

    [PunRPC]
    void ReconMinigame(string what, string how) {
        if (what == "Réquiem") { 
            PlayerPrefs.SetInt("game", 0);
            SceneManager.LoadScene( "MusicGame" ); 
        } else if (what == "Adaggio") { 
            PlayerPrefs.SetInt("game", 1);
            SceneManager.LoadScene( "MusicGame" ); 
        }
        // else if (what == "Giocoso") { 
        //     PlayerPrefs.SetInt("game", 2);
        //     SceneManager.LoadScene( "MusicGame" ); 
        // }
        // else if (what == "Allegro") { 
        //     PlayerPrefs.SetInt("game", 3);
        //     SceneManager.LoadScene( "MusicGame" ); 
        // }

        if (what == "Bloqueo de Chi") {
            PlayerPrefs.SetInt("game", 0);
            SceneManager.LoadScene("MonkGame");
        } else if (what == "Meditar") {
            PlayerPrefs.SetInt("game", 1);
            SceneManager.LoadScene("MonkGame");
        } else if (what == "Patada alta") {
            PlayerPrefs.SetInt("game", 2);
            SceneManager.LoadScene("MonkGame");
        } else if (what == "Velocidad extrema") {
            PlayerPrefs.SetInt("game", 3);
            SceneManager.LoadScene("MonkGame");
        }

        if (what == "Invocación") {
            PlayerPrefs.SetInt("game", 0);
            SceneManager.LoadScene("CrackTheCode");
        }
        else if (what == "Raíces atrapadoras") {
            PlayerPrefs.SetInt("game", 1);
            SceneManager.LoadScene("CrackTheCode");
        } 
        // else if (what == "Semilla de curación") {
        //     PlayerPrefs.SetInt("game", 2);
        //     SceneManager.LoadScene("CrackTheCode");
        // } 
        // else if (what == "Nube tóxica") {
        //     PlayerPrefs.SetInt("game", 3);
        //     SceneManager.LoadScene("CrackTheCode");
        // }
    }

    [PunRPC]
    void UpdatePoints(float points) {
        PlayerPrefs.SetFloat( "enemyScore", points );
    }
}