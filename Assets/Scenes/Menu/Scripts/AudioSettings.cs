using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] public AudioMixer menuAudioMixer;
    [SerializeField] public Slider audioSlider;

    public void SetMusicVolume()
    {
        float volume = audioSlider.value;
        menuAudioMixer.SetFloat("music", volume);
    }


}
