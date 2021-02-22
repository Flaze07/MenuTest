using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip swordSwingSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        swordSwingSound = Resources.Load<AudioClip> ("swordswing");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "swordswing":
                audioSrc.PlayOneShot(swordSwingSound);
                break;
        }
    }
}
