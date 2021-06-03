using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _id = _packet.ReadInt();
        Login_UIHandler.Login_Mensaje(_msg);
        Client.instance.myId = _id;
        ClientSend.WelcomeReceived();
    }

    public static void ServerStatus(Packet _packet)
    {
        int _serverStatus = _packet.ReadInt();
        Globals.ServerStatus = _serverStatus;
        Login_UIHandler.Login_ActualizarEstado();
        /*
        if (_serverStatus == 1) Debug.Log("Información del servidor: En linea.");
        if (_serverStatus == 2) Debug.Log("Información del servidor: Mantenimiento.");
        if (_serverStatus == 3) Debug.Log("Información del servidor: Apagado.");
        */
    }

    public static void LoginSuccess(Packet _packet)
    {
        Client.instance.loggedin = true;
        Login_UIHandler.instance.StartCoroutine("LogIn");
    }

    public static void LobbyMessageReceived(Packet _packet)
    {
        Debug.Log("Mensaje para el lobby del juego recibido.");
        string _username = _packet.ReadString();
        string _message = _packet.ReadString();
        Xat.AddLobbyXatMessage(_username, _message);
    }

    public static void OnlineUsersAddHandle(Packet _packet)
    {
        string _username = _packet.ReadString();
        string _country = _packet.ReadString();
        OnlineUsersList.AddToList(_username, _country);
    }

    public static void OnlineUsersUpdateHandle(Packet _packet)
    {
        OnlineUsersList.UpdateOnlineUsers();
    }

    public static void OnlineUsersUpdateForceHandle(Packet packet)
    {
        OnlineUsersList.ResetOnlineUsers();
        ClientSend.OnlineUsersRequest();
        Debug.Log("Force update received");
    }
}
