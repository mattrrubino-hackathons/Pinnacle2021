using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    AudioSource aSource;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void PlayClip(int n)
    {
        if (n < 0 || n > clips.Length)
        {
            Debug.Log("Invalid sound clip index.");
        }

        aSource.clip = clips[n];
        aSource.Play();
    }
}
