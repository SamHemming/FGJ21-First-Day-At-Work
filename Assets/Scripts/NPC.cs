using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(AudioSource))]
public class NPC : MonoBehaviour
{


	[SerializeField] private Sprite sprite;
	[SerializeField] private float speed = 1;
	[SerializeField] private float timePerDialogLine = 5f;
	[SerializeField] private string characterName = "defaultName";


	[SerializeField] private List<AudioClip> dialogAudio;
	[SerializeField] private List<AudioClip> successdDalogAudio;
	[SerializeField] private List<AudioClip> wrongDialogAudio;


	[SerializeField, TextArea] private string dialog;
	[SerializeField, TextArea] private string successDialog;
	[SerializeField, TextArea] private string wrongItemDialog;


	[SerializeField] private RectTransform dialogPanel;
	[SerializeField] private UnityEngine.UI.Text dialogText;
	[SerializeField] private UnityEngine.UI.Text speakerText;
	

	private List<(string, AudioClip)> dialogList = new List<(string, AudioClip)>();
	private List<(string, AudioClip)> successDialogList = new List<(string, AudioClip)>();
	private List<(string, AudioClip)> wrongItemDialogList = new List<(string, AudioClip)>();


	private Coroutine talk;
	private int whereWasI = 0;
	private AudioSource audioSource;


	[SerializeField] private UnityEngine.Events.UnityEvent OnDone;
	[SerializeField] private Vector2Int dialogPanelOffset = Vector2Int.zero;


	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();

		dialogList = StringAndAudioToList(dialog, dialogAudio);
		successDialogList = StringAndAudioToList(successDialog, successdDalogAudio);
		wrongItemDialogList = StringAndAudioToList(wrongItemDialog, wrongDialogAudio);
	}


	private List<(string, AudioClip)> StringAndAudioToList(string inputString, List<AudioClip> audioList)
	{
		List<string> list = new List<string>();

		list.AddRange(inputString.Split('\n'));

		List<(string, AudioClip)> stringAudioList = new List<(string, AudioClip)>();

		for(int i = 0; i < list.Count; ++i)
		{
			if(audioList.Count > i)
				stringAudioList.Add((list[i], audioList[i]));
			else
				stringAudioList.Add((list[i], null));
		}

		return stringAudioList;
	}


	IEnumerator Talk(List<(string, AudioClip)> list, int startIndex, bool isMainDialog = false)
	{
		dialogPanel.position = Vector3Int.FloorToInt(Camera.main.WorldToScreenPoint(this.transform.position)) + (Vector3Int)dialogPanelOffset;
		speakerText.text = characterName;

		for(int i = startIndex; i < list.Count; ++i)
		{
			if(isMainDialog) whereWasI = i;
			dialogText.text = list[i].Item1;

			if (list[i].Item2 != null)
			{
				audioSource.PlayOneShot(list[i].Item2);
				yield return new WaitForSecondsRealtime(list[i].Item2.length + timePerDialogLine);
			}

		}

		dialogPanel.position = new Vector3Int(10000, 10000, 0);
		DoneTalking();
	}


	IEnumerator MoveToPosition(Vector3 pos)
	{

		while (Vector3.Distance(pos, transform.position) > .1f)
		{
			yield return null;

			var dir = pos - transform.position;
			transform.position += (dir.magnitude > speed * Time.deltaTime) ? dir.normalized * speed * Time.deltaTime : pos;
		}

		DoneMoving();
	}


	private void DoneTalking()
	{
		Debug.Log("DoneTalking");
		if (whereWasI < dialogList.Count - 1)
			talk = StartCoroutine(Talk(dialogList, whereWasI, true));
		else
			Done();
	}


	private void DoneMoving()
	{
		Debug.Log("DoneMoving");
		if (whereWasI < dialogList.Count - 1)
			YourTurn();
		else
			this.enabled = false;
	}


	private void Done()
	{
		Debug.Log("Done");
		OnDone.Invoke();
	}


	private void YourTurn()
	{
		Debug.Log("YourTurn");
		talk = StartCoroutine(Talk(dialogList, 0, true));
	}


	//Publics-----------------------------------------------------

	public void WrongItem()
	{
		StopCoroutine(talk);
		audioSource.Stop();

		StartCoroutine(Talk(wrongItemDialogList, 0));
		
	}

	public void CorrectItem()
	{
		StopAllCoroutines();
		audioSource.Stop();

		whereWasI = 1000; //Larger then dialog list, I hope O.O'

		StartCoroutine(Talk(successDialogList, 0));
	}

	public void Go(Vector3 pos)
	{
		StartCoroutine(MoveToPosition(pos));
	}
}
