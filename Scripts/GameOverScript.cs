using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverScript : MonoBehaviour 
{

	IEnumerator playFading()
	{
		float fadeTime = GameObject.Find ("Fade").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
	}

	public void ReturnToMenu()
	{
		StartCoroutine (playFading ());
		SceneManager.LoadScene("Main Menu");
	}


	public void QuitGame()
	{
		StartCoroutine (playFading ());
		Application.Quit ();
	}
}
