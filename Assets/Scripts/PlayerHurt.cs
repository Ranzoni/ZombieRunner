using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public void PlaySoundEffect()
    {
        GetComponent<AudioSource>().Play();
    }
}
