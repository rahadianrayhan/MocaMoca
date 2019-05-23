using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Lobby : MonoBehaviourPunCallbacks {

    public GameObject startButton;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
        startButton.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server");
    }

    public void OnClickStart()
    {
        PhotonNetwork.JoinRandomRoom();
        StartCoroutine(Timeout());
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(3f);
        RoomOptions room = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 3 };
        int roomId = Random.Range(0, 1000);
        PhotonNetwork.CreateRoom("Room " + roomId.ToString(), room);
    }

    public override void OnJoinedRoom()
    {
        StopAllCoroutines();
        Debug.Log("On Room : " + PhotonNetwork.CurrentRoom);
        PhotonNetwork.LoadLevel("Room");
    }

}
