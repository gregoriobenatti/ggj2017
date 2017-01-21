using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    //public AudioClip click;
    public AudioClip bgmusic;
    public AudioSource audio = new AudioSource ();

    private GameObject[] buttons;

    private void Awake ()
    {
//        Initialize<States> ();

        buttons = GameObject.FindGameObjectsWithTag ("UIButton");        
        Play_Sound ();       
    }

    private void Play_Sound ()
    {
        AudioSource audio = GetComponent<AudioSource> ();

        //Verifica se o mudo esta ativo ou nao.
        audio.mute = game_manager.Instance.isMuted;

        //Toca a musica de fundo.
        AudioSource audiobg = GetComponent<AudioSource> ();
        audiobg.clip = bgmusic;
        audiobg.loop = true;
        audiobg.Play ();
        
    }

    private void Update ()
    {
    }

    public void Play ()
    {
        game_manager.Instance.LoadLevel ("Level1");
    }

    public void Pause ()
    {
        game_manager.Instance.LoadLevel ("Level1");
        game_manager.Instance.isPausePressed = true;
    }

    public void Unpause ()
    {
        Application.UnloadLevel ("ScreenPause");
        game_manager.Instance.isPausePressed = false;
    }

    public void SelectLevel ()
    {
    }

    public void Options ()
    {
    }

    public void Cast ()
    {
        game_manager.Instance.LoadLevel ("Credits");
    }

    public void LoadHome ()
    {
        game_manager.Instance.LoadLevel ("Menu");
    }

    public void Quit ()
    {
        Application.Quit ();
    }

    public void ToggleButtons (bool Show)
    {
//        buttons.ToList ().ForEach (g => g.gameObject.SetActive (Show));
    }
}
