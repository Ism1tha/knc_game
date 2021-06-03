using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xat : MonoBehaviour
{
    static Dictionary<int, Messages> XatMessages = new Dictionary<int, Messages>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class Messages
    {
        public int messageid;
        public string time;
        public string username;
        public string message;
        public int position;
        public GameObject TextObject;
        public Messages(int _messageid)
        {
            messageid = _messageid;
            username = "";
            message = "";
            position = -1;
        }
    }

    public static void InitializeLobbyChat()
    {
        for(int i = 0; i < Globals.MAX_CHAT_MESSAGES; i++)
        {
            XatMessages.Add(i, new Messages(i));
        }
    }

    public static void AddLobbyXatMessage(string _username, string _message)
    {
        for(int i = 0; i < Globals.MAX_CHAT_MESSAGES; i++)
        {
            if(XatMessages[i].position == -1) //No existe ningún mensaje en este slot.
            {
                XatMessages[i].messageid = i;
                XatMessages[i].username = _username;
                XatMessages[i].message = _message;
                XatMessages[i].time = DateTime.Now.ToString();
                GameObject _XatObject = GameObject.Find("Section_Messages");
                XatMessages[i].TextObject = new GameObject($"Xat_Message{i}");
                XatMessages[i].TextObject.AddComponent<RectTransform>();
                RectTransform TextTransform = XatMessages[i].TextObject.GetComponent<RectTransform>();
                TextTransform.SetParent(_XatObject.transform);
                TextTransform.sizeDelta = new Vector2(875.6f, 27.13f);
                float XatPosition = 64 - (i * 24);
                TextTransform.localPosition = new Vector3(0, XatPosition, 0);
                TextTransform.localScale = new Vector3(1, 1, 1);
                XatMessages[i].TextObject.AddComponent<Text>();
                XatMessages[i].TextObject.GetComponent<Text>().text = $"({XatMessages[i].time}){XatMessages[i].username}: {XatMessages[i].message}";
                XatMessages[i].TextObject.GetComponent<Text>().font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                XatMessages[i].position = i;
                break;
            }
        }
    }
}
