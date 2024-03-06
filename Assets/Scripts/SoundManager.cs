using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }

    public AudioSource sfx1;
    public AudioSource sfx2;
    public AudioSource sfx3;

    private void Awake()
    {
        Instance = this;
    }

    public AudioSource PlaySfx(AudioClip clip, float pitch = 1f, bool loop = false, float volume = 1)
    {
        if (!GlobalController.IsSoundOn) return null;
        if (sfx1.isPlaying)
        {
            return PlaySfx2(clip, pitch, loop, volume);
        }
        else
        {
            sfx1.clip = clip;
            sfx2.pitch = pitch;
            sfx1.volume = volume;
            sfx1.loop = loop;
            sfx1.Play();            return sfx1;
        }
    }

    private AudioSource PlaySfx2(AudioClip clip, float pitch = 1f, bool loop = false, float volume = 1)
    {
        if (!GlobalController.IsSoundOn) return null;
        if (sfx2.isPlaying)
        {
            return PlaySfx3(clip,pitch,loop,volume);
        }
        else
        {
            sfx2.clip = clip;
            sfx2.pitch = pitch;
            sfx2.loop = loop;
            sfx2.volume = volume;
            sfx2.Play();
            return sfx2;
        }
    }

    private AudioSource PlaySfx3(AudioClip clip, float pitch = 1f, bool loop = false, float volume = 1)
    {
        if (!GlobalController.IsSoundOn) return null;
        sfx3.clip = clip;
        sfx3.pitch = pitch;
        sfx3.loop = loop;
        sfx3.volume = volume;
        sfx3.Play();
        return sfx3;
    }
}
