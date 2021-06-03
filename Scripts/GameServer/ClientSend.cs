using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(1);
            SendTCPData(_packet);
        }
    }

    public static void LoginAttempt()
    {
        using (Packet _packet = new Packet((int)ClientPackets.loginAttempt))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(Login_UIHandler.LoginUsername);
            SendTCPData(_packet);
        }
    }

    public static void SendLobbyMessage(string _message)
    {
        using (Packet _packet = new Packet((int)ClientPackets.sendLobbyMessage))
        {
            _packet.Write(_message);
            SendTCPData(_packet);
            Debug.Log("Paquete enviado: Mensaje de Xat en lobby.");
        }
    }

    public static void OnlineUsersRequest()
    {
        using (Packet _packet = new Packet((int)ClientPackets.onlineUsersRequest))
        {
            SendTCPData(_packet);
        }
    }

    public static void ClientStatus(int _status)
    {
        using (Packet _packet = new Packet((int)ClientPackets.clientStatus))
        {
            _packet.Write(_status);
            SendTCPData(_packet);
        }
    }
}
