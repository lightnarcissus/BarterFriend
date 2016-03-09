using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public int appState=0;
	// Use this for initialization
	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
		appState = 1;
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		switch (appState) {

		case 1:
			if (Input.GetMouseButtonDown (0)) {
				appState = 2;
				Application.LoadLevel ("LoginPage");
			}
			break;
		case 2:
			break;
		}
	
	}
}
