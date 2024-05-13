using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;

    private bool _masterEnabled;

    public void ToggleSound()
    {
        _mixerGroup.audioMixer.SetFloat(MixerParams.MasterVolume.ToString(), _masterEnabled ? 0 : -80);

        _masterEnabled = !_masterEnabled;
    }

    public void ChangeMasterVolume(float volume)
    {
        ChangeVolume(volume, MixerParams.MasterVolume.ToString());
    }

    public void ChangeBackgroundVolume(float volume)
    {
        ChangeVolume(volume, MixerParams.BackgroundVolume.ToString());
    }
    
    public void ChangeButtonsVolume(float volume)
    {
        ChangeVolume(volume, MixerParams.ButtonsVolume.ToString());
    }

    private void ChangeVolume(float volume, string param)
    {
        _mixerGroup.audioMixer.SetFloat(param, Mathf.Log10(volume) * 20);
    }
}