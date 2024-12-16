using UnityEngine;

public class LU_CollectibleAttractor : MonoBehaviour
{
    LU_PlayAudioInQueue _audio;
    GameObject character;
    Vector3 originalPos;
    float timer = 0;
    private void Start()
    {
        originalPos = transform.parent.position;
        _audio = transform.parent.GetChild(4).GetComponent<LU_PlayAudioInQueue>();
    }
    private void Update()
    {
        if(character != null)
        {
            transform.parent.position = Vector3.Lerp(originalPos, character.transform.position, timer);
            timer += 2*Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<LU_CharacterController>(out LU_CharacterController chacharacter))
        {
            _audio.StopLoop();
            LU_Audio.PlaySound(SoundType.fx, 3,0.1f);
            _audio._audioToClipInSequence.Enqueue(LU_Audio._sounds["fx_2"]);
            character=collision.gameObject;
            GetComponent<CircleCollider2D>().enabled = false;

        }
    }
}
