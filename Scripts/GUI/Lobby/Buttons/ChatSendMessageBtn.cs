using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSendMessageBtn : MonoBehaviour
{
    private Image button;
    private Text _buttonText;
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Image>();
        _buttonText = button.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    void OnMouseEnter()
    {
        button.color = new Color32(255, 255, 225, 100);
    }

    void OnMouseExit()
    {
        button.color = new Color32(0, 255, 23, 255);
    }

    void OnMouseDown()
    {
        InputField _messageInput = GameObject.Find("InputField_LobbyXatMessage").GetComponentInChildren<InputField>();
        if(_messageInput.text.Length > 0)
        {
            ClientSend.SendLobbyMessage(_messageInput.text);
            _messageInput.text = "";
        }
    }
}
