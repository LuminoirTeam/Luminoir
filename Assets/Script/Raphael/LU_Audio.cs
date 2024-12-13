using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LU_Audio : MonoBehaviour
{
    
    [Header("The Key of a sound follow the syntax : \n\nnameofthelist_indexofthesound")]

    [Header("Corresponding channel will be automatically \nchosen when giving the key")]

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

    static Dictionary<SoundType, AudioSource> _audioChannels = new();
    static Dictionary<string, AudioClip> _sounds = new();


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _audioChannels.Clear();
        _sounds.Clear();
        for (int i = 0; i < _musics.Count; i++)
        {
            string nameOfIndex = $"{SoundType.musics}_{i}";
            _sounds.Add(nameOfIndex, _musics[i]);
        }
        for (int i = 0; i < _charactersSounds.Count; i++)
        {
            string nameOfIndex = $"{SoundType.characters}_{i}";
            _sounds.Add(nameOfIndex, _charactersSounds[i]);
        }
        for (int i = 0; i < _noctisSounds.Count; i++)
        {
            string nameOfIndex = $"{SoundType.noctis}_{i}";
            _sounds.Add(nameOfIndex, _noctisSounds[i]);
        }
        for (int i = 0; i < _lumisSounds.Count; i++)
        {
            string nameOfIndex = $"{SoundType.lumis}_{i}";
            _sounds.Add(nameOfIndex, _lumisSounds[i]);
        }
        for (int i = 0; i < _EnvironmentalsSounds.Count; i++)
        {
            string nameOfIndex = $"{SoundType.environment}_{i}";
            _sounds.Add(nameOfIndex, _EnvironmentalsSounds[i]);
        }
        for (int i = 0; i < _FXSounds.Count; i++)
        {
            string nameOfIndex = $"{SoundType.fx}_{i}";
            _sounds.Add(nameOfIndex, _FXSounds[i]);
        }
        _audioChannels.Add(SoundType.musics, transform.GetChild(0).GetComponent<AudioSource>());
        _audioChannels.Add(SoundType.characters, transform.GetChild(1).GetComponent<AudioSource>());
        _audioChannels.Add(SoundType.environment, transform.GetChild(2).GetComponent<AudioSource>());
        _audioChannels.Add(SoundType.fx, transform.GetChild(3).GetComponent<AudioSource>());

    }
    public static void PlaySound(SoundType soundCategory, int index)
    {
        AudioClip audioToPlay;
        string key = $"{soundCategory}_{index}";
        if (_sounds.TryGetValue(key, out audioToPlay))
        {
            string channelKey = key;
            channelKey = channelKey.Remove(channelKey.IndexOf('_'));

            if (channelKey.Contains(SoundType.noctis.ToString()) || channelKey.Contains(SoundType.noctis.ToString()))
            {
                channelKey = channelKey.Replace(channelKey, "characters");
            }
            _audioChannels[soundCategory].PlayOneShot(audioToPlay);
        }
        else
        {
            Debug.LogError($"Key incorrect or audio non-existent : \n{key}");
        }
    }
}

public enum SoundType
{
    musics,
    characters,
    noctis,
    lumis,
    environment,
    fx
}
