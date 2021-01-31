using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterMovement : MonoBehaviour
{
	[SerializeField, Range(0.01f, 2f)] private float movementSpeed = 1f;
	//[SerializeField, Range(0, 360)] private int angleOffset = 0;
	private AudioSource audioSource;
	[SerializeField] private AudioClip sound;
	private Coroutine step;
	private Rigidbody2D rb;
	private bool playingStep = false;

	private void Awake()
	{
		rb = this.GetComponent<Rigidbody2D>();
		audioSource = this.GetComponent<AudioSource>();
		audioSource.clip = sound;
	}

	private void FixedUpdate()
	{
		//this.transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed;
		
		rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * movementSpeed;

		if(rb.velocity.sqrMagnitude > Mathf.Epsilon)
		{
			if (!playingStep)
			{
				startStep();
				playingStep = true;
			}
		}
		else if(playingStep)
		{
			stopStep();
			playingStep = false;
		}

		/*
		//Not mine, copy-paste ain't no sin :DD
		var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//----
		*/
	}

	private void startStep()
	{
		step = StartCoroutine(PlayFootSteps());
	}

	private void stopStep()
	{
		StopCoroutine(step);
		audioSource.Stop();
	}

	IEnumerator PlayFootSteps()
	{
		while(true)
		{
			if(!audioSource.isPlaying)
			{
				audioSource.Play();
			}

			yield return null;
		}
	}
}
