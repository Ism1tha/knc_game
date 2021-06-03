using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlineUsersList : MonoBehaviour
{
    static Dictionary<int, OnlineUsers> onlineUsers = new Dictionary<int, OnlineUsers>();
    class OnlineUsers
    {
        public string country;
        public string username;
        public GameObject _textObj;
        //TODO: Añadir una variable que almacene el SQLID por si se quiere ver la información o añadir como amigo.
    }

    public static void InitializeOnlineUsers()
    {
        for(int i = 1; i < Globals.MAX_PLAYERS; i++)
        {
            onlineUsers.Add(i, new OnlineUsers());
        }
        Debug.Log("Online users list initialized.");
    }

    public static void ResetOnlineUsers()
    {
        for (int i = 1; i < Globals.MAX_PLAYERS; i++)
        {
            onlineUsers[i].country = "";
            onlineUsers[i].username = "";
            Destroy(onlineUsers[i]._textObj);
        }
    }

    public static void AddToList(string _username, string _country)
    {
        for (int i = 1; i < Globals.MAX_PLAYERS; i++)
        {
            if (onlineUsers[i].username == "")
            {
                onlineUsers[i].username = _username;
                onlineUsers[i].country = _country;
                Debug.Log($"Online user added to the list: {_username}");
                break;
            }
        }
    }

    public static void UpdateOnlineUsers()
    {
        for(int i = 1; i < Globals.MAX_PLAYERS; i++)
        {
            if (onlineUsers[i].username != "")
            {
                GameObject _onlineUsersParent = GameObject.Find("Section_OnlinePlayers");
                onlineUsers[i]._textObj = new GameObject($"Online_User{i}");
                GameObject _onlineUserText = onlineUsers[i]._textObj;
                _onlineUserText.transform.SetParent(_onlineUsersParent.transform);
                _onlineUserText.AddComponent<Text>();
                _onlineUserText.GetComponent<Text>().text = onlineUsers[i].username;
                _onlineUserText.GetComponent<Text>().fontSize = 24;
                _onlineUserText.GetComponent<Text>().fontStyle = FontStyle.Bold;
                float _posY = 355 - (i * 55);
                _onlineUserText.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                _onlineUserText.GetComponent<RectTransform>().localPosition = new Vector3(-79, _posY, 0);
                _onlineUserText.GetComponent<Text>().font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                GameObject _onlineUserCountry = new GameObject($"Online_User{i}_Country");
                //_onlineUserCountry.AddComponent<Image>();
            }
        }
        Debug.Log("Online users list updated.");
    }
}
