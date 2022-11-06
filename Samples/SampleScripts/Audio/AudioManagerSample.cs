using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevKit;

public class AudioManagerSample : MonoBehaviour
{
    [SerializeField] private string soundToPlay;

    public void PlaySound()
    {
        AudioManager.instance.Play(soundToPlay);
    }
}
