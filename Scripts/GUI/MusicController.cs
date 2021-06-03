using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private bool PlayingSong;
    private int PlayingSongID;
    public static void PlayClientSong(int _songid)
    {
        AudioClip _audio;
        if (GameObject.Find("MusicPlayer") != null) Destroy(GameObject.Find("MusicPlayer"));
        GameObject MusicPlayer = new GameObject("MusicPlayer");
        _audio = null;
        if (_songid == 1) //Login Song.
        {
            _audio = (AudioClip)Resources.Load("Music/Login/Music_Login", typeof(AudioClip));
        }
        if (_songid == 2)
        {
            _audio = (AudioClip)Resources.Load("Music/Lobby/Music_Lobby", typeof(AudioClip));
        }
        MusicPlayer.AddComponent<AudioSource>();
        MusicPlayer.GetComponent<AudioSource>().clip = _audio;
        MusicPlayer.GetComponent<AudioSource>().Play();
    }
}
