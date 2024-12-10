using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LU_Audio : MonoBehaviour
{
    [Header("The Key of a sound follow the syntax : \n\nnameofthelist_indexofthesound")]

    [Header("\nMusics")]
    [Header("musics_index")]
    [SerializeField] List<AudioClip> _musics = new();

    [Header("Characters sounds")]
    [Header("characters_index")]
    [SerializeField] List<AudioClip> _charactersSounds = new();

    [Header("Noctis only sounds")]
    [Header("noctis_index")]
    [SerializeField] List<AudioClip> _noctisSounds = new();

    [Header("Lumis only sounds")]
    [Header("lumis_index")]
    [SerializeField] List<AudioClip> _lumisSounds = new();

    [Header("Environmentals sounds")]
    [Header("environment_index")]
    [SerializeField] List<AudioClip> _EnvironmentalsSounds = new();

    [Header("FX sounds")]
    [Header("fx_index")]
    [SerializeField] List<AudioClip> _FXSounds = new();

    static Dictionary<string, AudioClip> _sounds = new();

    static AudioSource _audioSource;
    private void Awake()
    {
        for (int i = 0; i < _musics.Count; i++)
        {
            string nameOfIndex = $"musics_{i}";
            _sounds.Add(nameOfIndex, _musics[i]);
        }
        for (int i = 0; i < _charactersSounds.Count; i++)
        {
            string nameOfIndex = $"characters_{i}";
            _sounds.Add(nameOfIndex, _charactersSounds[i]);
        }
        for (int i = 0; i < _noctisSounds.Count; i++)
        {
            string nameOfIndex = $"noctis_{i}";
            _sounds.Add(nameOfIndex, _noctisSounds[i]);
        }
        for (int i = 0; i < _lumisSounds.Count; i++)
        {
            string nameOfIndex = $"lumis_{i}";
            _sounds.Add(nameOfIndex, _lumisSounds[i]);
        }
        for (int i = 0; i < _EnvironmentalsSounds.Count; i++)
        {
            string nameOfIndex = $"environment_{i}";
            _sounds.Add(nameOfIndex, _EnvironmentalsSounds[i]);
        }
        for (int i = 0; i < _FXSounds.Count; i++)
        {
            string nameOfIndex = $"fx_{i}";
            _sounds.Add(nameOfIndex, _FXSounds[i]);
        }
        
    }

    private void Start()
    {
        _audioSource.GetComponent<AudioSource>();
    }
    public static void PlaySound(string key)
    {
        AudioClip audioToPlay;
        if (_sounds.TryGetValue(key, out audioToPlay))
        {
            _audioSource.PlayOneShot(audioToPlay);
        }
        else 
        {
            Debug.LogError($"Key incorrect or audio non-existent : \n{key}");
        }
    }

}
