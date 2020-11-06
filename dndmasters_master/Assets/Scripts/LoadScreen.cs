using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LoadScreen : MonoBehaviour
{
    public void LoadScene( string sceneName ) 
    {
        if (sceneName == "InnScene" && PhotonNetwork.IsConnected) {
            PhotonNetwork.Disconnect();
            // Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        }
        SceneManager.LoadScene( sceneName );
    }
}
