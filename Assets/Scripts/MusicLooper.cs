using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicLooper : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField] private AudioClip music;

	public static MusicLooper singleton;

	private void Awake()
	{
		if (singleton)
		{
			GameObject.Destroy(this.gameObject);
			return;
		}

		singleton = this;

		audioSource = GetComponent<AudioSource>();
		audioSource.clip = music;
		audioSource.loop = true;
		audioSource.Play();
		DontDestroyOnLoad(this);
	}
}
