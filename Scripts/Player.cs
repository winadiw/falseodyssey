using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour 
{
	private Animator animator;
	public float moveSpeed = 8f;
	public float turnSpeed = 50f;
	public bool canMove = true;
	public AudioClip keyFoundSound;
	public AudioClip gameOverSound;
	GameObject key1;
	GameObject key2;
	GameObject key3;

	public float fadeTime;
	// Use this for initialization
	void Awake()
	{
		animator = this.GetComponent<Animator>();
		key1 = GameObject.FindGameObjectWithTag("Key1");
		key2 = GameObject.FindGameObjectWithTag("Key2");
		key3 = GameObject.FindGameObjectWithTag("Key3");

		if (GameManager.checkKey (0) == true) 
		{
			Destroy (key1);
		}

		if (GameManager.checkKey (1) == true) 
		{
			Destroy (key2);
		}

		if (GameManager.checkKey (2) == true) 
		{
			Destroy (key3);
		}

		Debug.Log (key1);
		Debug.Log (key2);
		Debug.Log (key3);
	}
		
	void Update() 
	{
		CheckIfGameOver ();
		if (canMove) {
			Vector2 v2 = new Vector2 (CrossPlatformInputManager.GetAxisRaw ("Horizontal"), CrossPlatformInputManager.GetAxisRaw ("Vertical"));
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || CrossPlatformInputManager.GetAxisRaw ("Vertical") > 0) {  
				animator.SetInteger ("Direction", 2);
				v2 += Vector2.up; 
			}  
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) || CrossPlatformInputManager.GetAxisRaw ("Vertical") < 0) {  
				animator.SetInteger ("Direction", 0);
				v2 += Vector2.down; 
			}
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || CrossPlatformInputManager.GetAxisRaw ("Horizontal") < 0) { 
				animator.SetInteger ("Direction", 1);
				v2 += Vector2.left;  
			} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) || CrossPlatformInputManager.GetAxisRaw ("Horizontal") > 0) {    
				animator.SetInteger ("Direction", 3);
				v2 += Vector2.right; 
			} else if (!Input.anyKey) {
				animator.SetInteger ("Direction", -1);
			}
			transform.Translate(moveSpeed * v2.normalized * Time.deltaTime);   
		}
		 
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Trap" || other.tag == "FireTrap")
		{
			GameManager.playerHealth--;
			//Debug.Log (GameManager.playerHealth);
			StartCoroutine(hitTrap ());
			CheckIfGameOver();
		}
		if (other.tag == "Key1") 
		{
			GameManager.setkeyFound (0);
			Destroy (other.gameObject);
			playKeySound ();
		}
		if (other.tag == "Key2") 
		{
			GameManager.setkeyFound (1);
			Destroy (other.gameObject);
			playKeySound ();
		}
		if (other.tag == "Key3") 
		{
			GameManager.setkeyFound (2);
			Destroy (other.gameObject);
			playKeySound ();
		}
		else if (other.tag == "Exit1" && GameManager.checkIfKeyFound() == true) 
		{
			NextLevel ();
		}
		else if (other.tag == "Exit2" && GameManager.checkIfKeyFound() == true) 
		{
			NextLevel ();
		}
		else if (other.tag == "Exit3" && GameManager.checkIfKeyFound() == true) 
		{
			NextLevel ();
		}
		else if (other.tag == "Exit4" && GameManager.checkIfKeyFound() == true) 
		{
			NextLevel ();
		}
	}
		
	private void playKeySound()
	{ 
		SoundManager.instance.PlaySingle (keyFoundSound);
	}


	private void NextLevel()
	{
		SoundManager.instance.destroyMusic ();
		GameManager.allKeyFound ();
		GameManager.resetLife ();
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	private void CheckIfGameOver()
	{
		if (GameManager.playerHealth <= 0) 
		{
			StartCoroutine (playerDead ());
		}
	}

	IEnumerator playerDead()
	{
		Debug.Log ("Player Dead", gameObject);
		SoundManager.instance.destroyMusic ();
		float fadeTime = GameObject.Find ("Fade").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		GameManager.resetLife ();
		Application.LoadLevel ("You Died");
		canMove = true;
	}

	IEnumerator hitTrap()
	{
		animator.Play("death");
		canMove = false;
		this.GetComponent<PolygonCollider2D> ().enabled = false;
		//Debug.Log (GameManager.playerHealth, gameObject);
		SoundManager.instance.PlaySingle (gameOverSound);
		yield return new WaitForSeconds(1.5f);
		float fadeTime = GameObject.Find ("Fade").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds(fadeTime);
		this.GetComponent<PolygonCollider2D> ().enabled = true;
		Application.LoadLevel(Application.loadedLevel);
	}


}
