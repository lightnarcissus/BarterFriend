using UnityEngine;
using System.Collections;

public class WebcamScript : MonoBehaviour {

	private int filter=0; //0 for normal
	//public GameObject main;
	// Use this for initialization
	void Start () {
		//yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
		WebCamTexture webcamTexture = new WebCamTexture();
		GetComponent<Renderer>().material.mainTexture = webcamTexture;
		webcamTexture.Play();
	
	}
	
	// Update is called once per frame
	void Update () {



	
	}
}
