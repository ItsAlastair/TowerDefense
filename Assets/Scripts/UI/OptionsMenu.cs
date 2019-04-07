using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    
    public AudioMixer mainMixer;
    public Slider mainSlider;
    public Slider effectSlider;
    public Slider BGMSlider;

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

    public void SetSlider()
    {
        mainSlider.value = mainMixer.GetFloat("volume", out float volume) ? volume : 0;
        effectSlider.value = mainMixer.GetFloat("effectVolume", out float effectVolume) ? effectVolume : 0;
        BGMSlider.value = mainMixer.GetFloat("BGMVolume", out float BGMVolume) ? BGMVolume : 0;
    }
}
