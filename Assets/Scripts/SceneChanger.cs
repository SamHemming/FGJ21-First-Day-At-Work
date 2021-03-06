﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public void GotoMenu()
	{
		SceneManager.LoadScene("mainmenuscene");
	}

	public void GotoGame()
	{
		SceneManager.LoadScene("SampleScene");
	}

	public void GotoGameDelayed()
	{
		StartCoroutine(Delayed(5, "SampleScene"));
	}

	public void GotoMenuDelayed()
	{
		StartCoroutine(Delayed(5, "mainmenuscene"));
	}

	IEnumerator Delayed(float delay, string sceneName)
	{
		yield return new WaitForSecondsRealtime(delay);
		SceneManager.LoadScene(sceneName);
	}
}
