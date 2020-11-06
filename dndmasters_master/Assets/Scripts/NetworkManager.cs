using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public PhotonView PV;

    // Start is called before the first frame update
    void Start() {
        if (!PhotonNetwork.IsConnected) { Connect(); }
    }

    // void OnDestroy() {
    //     PhotonNetwork.Disconnect();
    // }

    public void Connect() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Play();
    }

    public void Play() {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Globals.myTurn = false;
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom() {
        PV.RPC("UpdatePlayerCount", RpcTarget.All);
    }

    public override void OnLeftRoom()   {
        PV.RPC("UpdatePlayerCount", RpcTarget.All);
    }
}
