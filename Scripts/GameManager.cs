using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static bool[] keyFound = new bool[3];
	public static int playerHealth = 3;
	public static GameObject[] key;
	//public static int level = 1;

	// Use this for initialization
	void Start () 
	{
		playerHealth = 3;
		for (int i = 0; i < 3; i++) 
		{
			keyFound [i] = false;
		}
	}

	public static bool checkIfKeyFound()
	{
		bool status = false;
		for (int i = 0; i < 3; i++) 
		{
			status = keyFound [i];
			if (status == false) 
			{
				break;
			}
		}
		return status;
	}
		
	public static bool checkKey (int key)
	{
		if(keyFound[key]==true)
		return true;
		else return false;
	}

	public static void allKeyFound()
	{
		for (int i = 0; i < 3; i++) 
		{
			keyFound [i] = false;
		}
	}

	public static int countKeyFound()
	{
		int found = 0;
		for (int i = 0; i < 3; i++) 
		{
			if (keyFound [i] == true) 
			{
				found++;
			}
		}
		return found;
	}
		
	public static void setkeyFound(int keyNumber)
	{
		keyFound [keyNumber] = true;
	}

	public static void resetLife()
	{
		playerHealth = 3;
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
