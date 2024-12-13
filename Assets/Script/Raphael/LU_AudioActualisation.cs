using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class LU_AudioActualisation : MonoBehaviour
{
    [SerializeField]
    AudioSource channel;
    void Start()
    {
        transform.GetChild(0).GetComponent<Slider>().value=channel.volume;
    }
    public void ChangeVolume(float volume)
    {
        channel.volume = volume;
    }
}
