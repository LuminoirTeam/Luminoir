using UnityEngine;

public class LU_CollectibleDiscover : MonoBehaviour
{
    LU_PlayAudioInQueue _audio;
    private void Start()
    {
        _audio = transform.parent.GetChild(4).GetComponent<LU_PlayAudioInQueue>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LU_CharacterController>(out LU_CharacterController chacharacter))
        {
            _audio._audioToClipInSequence.Enqueue(LU_Audio._sounds["fx_0"]);
            _audio.loopOption.Add(LU_Audio._sounds["fx_1"], true);
            _audio._audioToClipInSequence.Enqueue(LU_Audio._sounds["fx_1"]);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
