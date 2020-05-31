using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] sfx;   //sound effects
    public AudioSource[] bgm;   //big game hunter :P  back-ground music

    public static AudioManager instance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this; //this script
        }
        else
        {
            Destroy(gameObject);
        }

        //instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Play();
        }
    }

    public void PlayBGM(int playingMusic)
    {
        if (!bgm[playingMusic].isPlaying)
        {
            StopMusic();

            if (playingMusic < bgm.Length)
            {
                bgm[playingMusic].Play();
            }
        }
    }

    public void StopMusic()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }

}
