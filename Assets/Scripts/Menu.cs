﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	// Use this for initialization
	Slider bar;

	private GameObject _playbutton;
	// Use this for initialization
	private void Awake()
	{
		bar = GetComponent<Slider>();
		_playbutton = GameObject.Find("Jogar");

	}

	public void Load(int cena)
	{
		_playbutton.SetActive(false);
		StartCoroutine(LoadAssincrono(cena));
	}

	IEnumerator LoadAssincrono(int cena)
	{
		AsyncOperation op = SceneManager.LoadSceneAsync(cena);
		while (!op.isDone)
		{
			var progresso =  Mathf.Clamp01(op.progress / 0.9f);
			bar.value = progresso;
			Debug.Log(progresso);
			yield return null;
		}
	}

	public void Sair()
	{
		Application.Quit();
	}
	
}
