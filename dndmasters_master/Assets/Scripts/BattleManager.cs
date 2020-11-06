using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class BattleManager : MonoBehaviourPunCallbacks
{
    [PunRPC]
    void UpdatePlayerCount() {
        Globals.playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
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

        if (what == "Bloqueo de Chi") { SceneManager.LoadScene("MonkGame"); }

        if (what == "Invocación") { SceneManager.LoadScene("CrackTheCode"); }
    }

    [PunRPC]
    void UpdatePoints(float points) {
        PlayerPrefs.SetFloat( "enemyScore", points );
    }
}