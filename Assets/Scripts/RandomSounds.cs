using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] AudioClip[] clips;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        int randomNum = Random.Range(0, clips.Length);
        source.clip = clips[randomNum];
        source.Play();
    }
}
