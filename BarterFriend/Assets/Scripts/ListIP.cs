using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ListIP : MonoBehaviour {

	public static string ipAddress="";
	public static string otherIPAddress="";
	public InputField ipField;
	public InputField otherField;

	public GameObject requestPage;
	public GameObject requestMenu;
	public GameObject mainMenu;
	public GameObject loginPage;
	public GameObject title;
	public static GameObject selfIP;

	private bool found = false;

	private int activeLevel=0;
	private GameObject activeLevelObj;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(GameObject.Find("PlatformManager_Dev"));
		DontDestroyOnLoad(GameObject.Find("OSCHandler_Developer"));
		DontDestroyOnLoad (gameObject);
//		Application.LoadLevelAdditive ("MainMenu");
//		Application.LoadLevelAdditive ("LoginPage");
//		Application.LoadLevelAdditive ("RequestPage");
//		Application.LoadLevelAdditive ("RequestMenu");
		selfIP = this.gameObject;
		//InvokeRepeating ("FindLevels", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetMouseButtonDown (0)) {
//			Application.LoadLevel ("MainMenu");
		//}
	

	}

	public void SwitchLevel(int activeLevel)
	{
		activeLevelObj.SetActive (false);
		switch (activeLevel) {

		case 1:
			mainMenu.SetActive (true);
			activeLevelObj = mainMenu;
			break;
		case 2:
			loginPage.SetActive (true);
			activeLevelObj = loginPage;
			break;
		case 3:
			requestMenu.SetActive (true);
			activeLevelObj = requestMenu;
			break;
		case 4:
			requestPage.SetActive (true);
			activeLevelObj = requestPage;
			break;
		}


	}

	void FindLevels()
	{
		if (!found) {
			if (requestPage == null)
				requestPage = GameObject.Find ("RequestPage");
			else if (requestMenu == null)
				requestMenu = GameObject.Find ("RequestMenu");
			else if (loginPage == null)
				loginPage = GameObject.Find ("LoginPage");
			else if (mainMenu == null)
				mainMenu = GameObject.Find ("MainMenu");
			else if (title == null)
				title = GameObject.Find ("Title");
			else
				found = true;
		
		requestPage.SetActive (false);
		loginPage.SetActive (false);
		requestMenu.SetActive (false);
		mainMenu.SetActive (false);
		activeLevelObj = title;
		}
	}

	public void OnEnterApp()
	{
		ipAddress = ipField.text.ToString ();
		otherIPAddress = otherField.text.ToString ();
	//	SwitchLevel (1);
		if (PlatformManager_Dev.platformVersion == 2)
			Application.LoadLevel ("MainMenu");
		else
			Application.LoadLevel ("MainMenu");
	}
}
