using System.Collections.Generic;
using UnityEngine;

public class LU_PlayAudioInQueue : MonoBehaviour
{
    internal Queue<AudioClip> _audioToClipInSequence = new();
    AudioSource _audioSource;
    internal Dictionary<AudioClip, bool> loopOption;
    void Start()
    {
        _audioSource=GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!_audioSource.isPlaying && _audioToClipInSequence.Count > 0)
        {
            _audioSource.clip = _audioToClipInSequence.Dequeue();
            if (loopOption.TryGetValue(_audioSource.clip, out bool loopsettings))
            {
                if(loopsettings)
                {
                    SetToLoop();
                }
                else
                {
                    StopLoop();
                }
            }
                _audioSource.Play();
        }
    }
    public void SetToLoop()
    {
        _audioSource.loop = true;

    }
    public void StopLoop()
    {
        _audioSource.loop = false;
    }

}
