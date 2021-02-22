using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAudioManager : MonoBehaviour
{
    public AudioClip enemyRangedShoot;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip) {
        switch(clip) {
        case "shoot":
            audioSource.PlayOneShot(enemyRangedShoot);
            break;
        }
    }
}
