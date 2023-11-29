using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Audio; 
public class AudioSettingsManager : MonoBehaviour
{
    public AudioMixer GameAudioMixer; 
    public Slider volumeSlider;

    void Start()
    {
        float volume;
        GameAudioMixer.GetFloat("MasterVolume", out volume);
        volumeSlider.value = Mathf.Pow(10, volume / 20); 
    }

    public void SetVolume(float volume)
    {
        Debug.Log("Volume set to (linear): " + volume);
        float volumeInDecibels = Mathf.Log10(volume) * 20;
        Debug.Log("Volume set to (dB): " + volumeInDecibels);
        GameAudioMixer.SetFloat("MasterVolume", volumeInDecibels);
    }
}