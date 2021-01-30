using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
	[SerializeField] private List<NPC> npcList;
	private int currentNPC = 0;


	[SerializeField] private Transform spawnPos;
	[SerializeField] private Transform despawnPos;


	private void Start()
	{
		npcList[0].YourTurn();
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Player"))
			return;

		if(true) //TODO: Player has correct item
		{
			npcList[currentNPC].CorrectItem();
		}
		else //Twas wrong item
		{
			npcList[currentNPC].WrongItem();
		}
	}

	public void NPCDone()
	{
		npcList[currentNPC].Go(despawnPos.position);
		++currentNPC;

		if (npcList.Count > currentNPC)
		{
			npcList[currentNPC].transform.position = spawnPos.position;
			npcList[currentNPC].YourTurn();
			npcList[currentNPC].Go(transform.position);
		}
		else
		{
			Debug.Log("You WIN!!!");
			//TODO: you win?
		}
	}
}
