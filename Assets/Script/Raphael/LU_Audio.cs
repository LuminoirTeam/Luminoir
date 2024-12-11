using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

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

    static Dictionary<string, AudioSource> _audioChannels = new();
    static Dictionary<string, AudioClip> _sounds = new();

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
        _audioChannels.Add("musics",transform.GetChild(0).GetComponent<AudioSource>());
        _audioChannels.Add("characters", transform.GetChild(1).GetComponent<AudioSource>());
        _audioChannels.Add("environment", transform.GetChild(2).GetComponent<AudioSource>());
        _audioChannels.Add("fx", transform.GetChild(3).GetComponent<AudioSource>());
    }
    public static void PlaySound(string key)
    {
        AudioClip audioToPlay;
        if (_sounds.TryGetValue(key, out audioToPlay))
        {
            string channelKey = key;
            channelKey =channelKey.Remove( channelKey.IndexOf('_'));

            if (channelKey.Contains("noctis") || channelKey.Contains("lumis"))
            {
                channelKey = channelKey.Replace(channelKey, "characters");
            }

            if ( _audioChannels.TryGetValue(channelKey, out AudioSource channelToPlay))
            {
                channelToPlay.PlayOneShot( audioToPlay );
            }
            else
            {
                Debug.LogError($"channel non-existent : \n{channelKey}");
            }
        }
        else 
        {
            Debug.LogError($"Key incorrect or audio non-existent : \n{key}");
        }
    }

}
