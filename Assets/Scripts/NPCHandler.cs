using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
	[SerializeField] private List<NPC> npcList;
	private int currentNPC = 0;

	private int customerSatisfaction = 10;

	[SerializeField] private Transform spawnPos;
	[SerializeField] private Transform despawnPos;
	[SerializeField] private UnityEngine.UI.Text score;
	[SerializeField] private UnityEngine.UI.Image fired;

	public UnityEngine.Events.UnityEvent OnLose;

	public void NPCGotBored()
	{
		customerSatisfaction -= 4;
		UpdateScore();
	}

	private void UpdateScore()
	{
		score.text = $"Customer Satisfaction: {customerSatisfaction}";

		if(customerSatisfaction <= 0)
		{
			StartCoroutine(DelayEnd(2));
		}
	}

	IEnumerator DelayEnd(float delay)
	{
		yield return new WaitForSecondsRealtime(delay);
		fired.gameObject.SetActive(true);
		OnLose.Invoke();
	}

	public void StartShit()
	{
		npcList[0].transform.position = spawnPos.position;
		npcList[0].Go(transform.position);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Player"))
			return;

		var player = collision.GetComponent<ItemHolder>();

		if (!player.holdingItem)
			return;

		if(string.Equals(npcList[currentNPC].itemName, player.itemName))
		{
			player.ClearHand();
			npcList[currentNPC].CorrectItem();
		}
		else
		{
			npcList[currentNPC].WrongItem();
			--customerSatisfaction;
			UpdateScore();
		}
	}

	public void NPCDone()
	{
		npcList[currentNPC].Go(despawnPos.position);
		++currentNPC;

		if (npcList.Count > currentNPC)
		{
			npcList[currentNPC].transform.position = spawnPos.position;
			npcList[currentNPC].Go(transform.position);
		}
		else
		{
			FindObjectOfType<ProtagonistVoice>().PlayEnd();
		}
	}
}
