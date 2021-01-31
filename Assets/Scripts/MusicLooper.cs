using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicLooper : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField] private AudioClip music;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = music;
		audioSource.loop = true;
		audioSource.Play();
		DontDestroyOnLoad(this);
	}
}
