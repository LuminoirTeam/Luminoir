using System.Collections.Generic;
using UnityEngine;

public class LU_PlayAudioInQueue : MonoBehaviour
{
    internal Queue<AudioClip> _audioToClipInSequence = new();
    AudioSource _audioSource;
    internal Dictionary<AudioClip, bool> loopOption = new();
    void Start()
    {
        _audioSource=GetComponent<AudioSource>();
    }
    void Update()
    {
        Debug.Log(_audioSource.isPlaying);
        if (!_audioSource.isPlaying && _audioToClipInSequence.Count > 0)
        {
            _audioSource.clip = _audioToClipInSequence.Dequeue();
            _audioSource.Play();
            if (loopOption.TryGetValue(_audioSource.clip, out bool loopsettings))
            {
                loopOption.Remove(_audioSource.clip);
                if(loopsettings)
                {
                    SetToLoop();
                }
                else
                {
                    StopLoop();
                }
            }
                
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
