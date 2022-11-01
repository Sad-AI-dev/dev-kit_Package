using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    [Header("Settings")]
    public AudioMixerGroup output;
    [Range(0f, 1f)] public float volume = 0.3f;
    [Range(0.1f, 3f)] public float pitch = 1f;

    [HideInInspector] public AudioSource source;

    public void SetupSource(AudioSource source = null)
    {
        if (!source) { source = this.source; } //use stored source by default
        source.clip = clip;
        //settings
        source.outputAudioMixerGroup = output;
        source.volume = volume;
        source.pitch = pitch;
    }
}
