using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ProtagonistVoice : MonoBehaviour
{
	private AudioSource audioSource;
	[SerializeField] private List<AudioClip> startSounds;
	[SerializeField] private List<AudioClip> endSounds;
	[SerializeField] private NPCHandler handler;
	private bool isStart = true;
	[SerializeField] private UnityEngine.UI.Image victory;

	public UnityEngine.Events.UnityEvent OnVicotry;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Start()
	{
		StartCoroutine(PlaySoundList(startSounds));
	}

	public void PlayEnd()
	{
		StartCoroutine(PlaySoundList(endSounds));
	}

	private void DonePlaying()
	{
		if(isStart)
		{
			isStart = false;
			handler.StartShit();
		}
		else
		{
			victory.gameObject.SetActive(true);
			OnVicotry.Invoke();
		}
	}

	IEnumerator PlaySoundList(List<AudioClip> list)
	{
		foreach(AudioClip sound in list)
		{
			audioSource.PlayOneShot(sound);
			yield return new WaitForSecondsRealtime(sound.length + 0.5f);
		}

		DonePlaying();
	}
}
