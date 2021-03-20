using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameConnect : MonoBehaviourPunCallbacks
{
    public Button playButton;

    public void OnClick_playButton()
    {
        PhotonNetwork.NickName = "Player";
        SceneManager.LoadScene("Game2");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var position = new Vector3(0f, 5f, 0f);
        PhotonNetwork.Instantiate("Player", position, Quaternion.identity);
    }
}
