using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    
    public AudioMixer mainMixer;

    public void MainVolume(float value)
    {
        mainMixer.SetFloat("volume", value);
    }

    public void EffectVolume(float value)
    {
        mainMixer.SetFloat("effectVolume", value);
    }

    public void BGMVolume(float value)
    {
        mainMixer.SetFloat("BGMVolume", value);
    }
}
