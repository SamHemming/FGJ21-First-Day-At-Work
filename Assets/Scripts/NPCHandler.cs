using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHandler : MonoBehaviour
{
	[SerializeField] private List<NPC> npcList;
	private int currentNPC = 0;


	[SerializeField] private Transform spawnPos;
	[SerializeField] private Transform despawnPos;


	public void Start()
	{
		npcList[0].transform.position = spawnPos.position;
		npcList[0].Go(transform.position);
	}

	private bool toggle = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag("Player"))
			return;



		if(toggle) //TODO: Player has correct item
		{
			npcList[currentNPC].CorrectItem();
		}
		else //Twas wrong item
		{
			npcList[currentNPC].WrongItem();
		}

		toggle = !toggle;
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
			Debug.Log("You WIN!!!");
			//TODO: you win?
		}
	}
}
