using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] AudioClip[] clips;
    [SerializeField] float timeBetweenSounds;

    float nextSoundEffectTime;

    private void Start()
    {
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        RandomSounds();
    }

    private void RandomSounds()
    {
        if (Time.time >= nextSoundEffectTime)
        {
            int randomNum = Random.Range(0, clips.Length);
            source.clip = clips[randomNum];
            source.Play();
            nextSoundEffectTime = Time.time + timeBetweenSounds;
        }
    }
}
