using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadScreen : MonoBehaviour
{
    public void LoadScene( string sceneName ) 
    {
        if (sceneName == "InnScene" && PhotonNetwork.IsConnected) {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.Disconnect();
            Debug.Log("Disconect: " + PhotonNetwork.CurrentRoom.PlayerCount);
            Globals.playerCount = 0;
        }
        SceneManager.LoadScene( sceneName );
    }
}
