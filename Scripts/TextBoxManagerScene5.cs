using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TextBoxManagerScene5 : MonoBehaviour 
{
	public GameObject textBox;
	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	// public PlayerController player;

	public bool canPress = true;
	public bool isActive;

	// Use this for initialization
	void Start () 
	{
		// player = FindObjectOfType<PlayerController> ();
		canPress = true;
		if (textFile != null) 
			textLines = (textFile.text.Split ('\n'));

		if (endAtLine == 0)
			endAtLine = textLines.Length-1;

		if (isActive)
			EnableTextBox ();
		else
			DisableTextBox ();
	}

	IEnumerator playFading()
	{
		float fadeTime = GameObject.Find ("Fade").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
	}

	void Update()
	{
		theText.text = textLines[currentLine];

		if (Input.GetKeyDown (KeyCode.Return) || Input.GetMouseButtonDown(0))
		currentLine++;


		if(currentLine > endAtLine)
		{
			DisableTextBox ();
			currentLine = 0;
			SoundManager.instance.destroyMusic ();
			StartCoroutine (playFading ());
			Application.LoadLevel(Application.loadedLevel + 1);
		}﻿

	}
		
	public void EnableTextBox()
	{
		textBox.SetActive(true);

		/* if (stopPlayerMovement)
		 *	player.canMove = false;*/
	}

	public void DisableTextBox()
	{
		textBox.SetActive(false);

		// player.canMove = true;
	}
}
