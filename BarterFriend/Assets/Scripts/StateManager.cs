using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public int appState=0;
	private GameObject listIP;
	public GameObject mainMenu;
	public GameObject loginPage;
	public GameObject requestMenu;
	public GameObject requestPage;
	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
		appState = 1;
		listIP = ListIP.selfIP;
		loginPage.SetActive (false);
		requestMenu.SetActive (false);
		requestPage.SetActive (false);
	}
	void Start () {
	
	}

	void Update()
	{
		if (appState == 1) {
			if (Input.GetMouseButtonDown (0)) {
				SwitchLevel (1);
			}
		}
	}
	
	// Update is called once per frame
	public void SwitchLevel (int newLevel) {
		Debug.Log("new level");
		switch (newLevel) {

		case 1:
				appState = 2;
				//Application.LoadLevel ("LoginPage");
				mainMenu.SetActive(false);
				loginPage.SetActive (true);
			break;
		case 2:
			appState = 3;
			loginPage.SetActive (false);
			requestMenu.SetActive (true);
			break;
		case 3:
			appState = 4;
			requestMenu.SetActive (false);
			requestPage.SetActive (true);
			break;
		case 4:
			appState = 3;
			requestMenu.SetActive (true);
			requestPage.SetActive (false);
			break;
		}
	
	}
}
