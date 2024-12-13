using UnityEngine;

public class LU_CollectibleDiscover : MonoBehaviour
{
    LU_PlayAudioInQueue audio;
    private void Start()
    {
        audio = transform.parent.GetChild(4).GetComponent<LU_PlayAudioInQueue>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LU_CharacterController>(out LU_CharacterController chacharacter))
        {
            audio._audioToClipInSequence.Enqueue(LU_Audio._sounds["fx_0"]);
            audio._audioToClipInSequence.Enqueue(LU_Audio._sounds["fx_1"]);
            audio._audioToClipInSequence.Enqueue(LU_Audio._sounds["fx_2"]);
        }
    }
}
