using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerAudioManager : MonoBehaviour {
    public AudioClip sound;

    private AudioSource audioSource;
    private Animator animator;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Firing") && !audioSource.isPlaying) {
            audioSource.PlayOneShot(sound);
        }
    }
}
