using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjTalker : MonoBehaviour, IUsable
{
    [SerializeField] private AudioClip[] _audioClips;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    public void Use()
    {
        _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
    }
}
