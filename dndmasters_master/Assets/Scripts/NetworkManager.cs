﻿using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    // Start is called before the first frame update
    void Start() {
        if (!PhotonNetwork.IsConnected) { Connect(); }
    }

    public void Connect() {
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "us";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Play();
    }

    public void Play() {
        Debug.Log("Join Room");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        // Debug.Log("Error: " + returnCode + "-" + message);
        Globals.myTurn = false;
        Debug.Log("Create Room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom() {
        PV.RPC("UpdatePlayerCount", RpcTarget.All);
    }

    public override void OnLeftRoom()   {
        PV.RPC("UpdatePlayerCount", RpcTarget.All);
        Debug.Log("Leave Room");
    }
}
