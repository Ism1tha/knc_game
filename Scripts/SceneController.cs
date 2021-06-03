using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if(sceneName == "Login")
        {
            MusicController.PlayClientSong(1);
        }
        if(sceneName == "Home")
        {
            //Load the lobby song
            MusicController.PlayClientSong(2);
            //Initialize de chat.
            Xat.InitializeLobbyChat();
            //Set the user information
            Text _UsernamemeText = GameObject.Find("Text_Username").GetComponent<Text>();
            _UsernamemeText.text = Client.instance.username;
            //Send a packet to the server to update the online users list.
            OnlineUsersList.InitializeOnlineUsers();
            OnlineUsersList.ResetOnlineUsers();
            ClientSend.OnlineUsersRequest();
            ClientSend.ClientStatus(Constants.PLAYER_STATUS_LOBBY);
        }
        else if (sceneName == "Example 2")
        {
        }
    }
}