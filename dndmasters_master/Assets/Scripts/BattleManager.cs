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
        if(what == "Réquiem") { SceneManager.LoadScene( "MusicGame" ); }

        if (what == "Bloqueo de Chi") { SceneManager.LoadScene("MonkGame"); }

        if (what == "Invocación") { SceneManager.LoadScene("CrackTheCode"); }
    }

    [PunRPC]
    void UpdatePoints(float points) {
        PlayerPrefs.SetFloat( "enemyScore", points );
    }
}