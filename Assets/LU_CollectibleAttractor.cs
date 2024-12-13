using UnityEngine;

public class LU_CollectibleAttractor : MonoBehaviour
{
    LU_PlayAudioInQueue _audio;
    GameObject character;
    Vector3 originalPos;
    private void Start()
    {
        originalPos = transform.position;
        _audio = transform.parent.GetChild(4).GetComponent<LU_PlayAudioInQueue>();
    }
    private void Update()
    {
        if(character != null)
        {
            transform.position = Vector3.Lerp(originalPos, character.transform.position, 0.5f * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LU_CharacterController>(out LU_CharacterController chacharacter))
        {
            _audio.StopLoop();
            _audio._audioToClipInSequence.Enqueue(LU_Audio._sounds["fx_3"]);
            character=collision.gameObject;
            GetComponent<CircleCollider2D>().enabled = false;

        }
    }
}
