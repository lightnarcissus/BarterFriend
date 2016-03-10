using UnityEngine;
using System.Collections;

public class RequestFeed : MonoBehaviour {

	private GameObject detailedReq;
	public GameObject submitButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RequestPage()
	{
		Application.LoadLevel("RequestPage");
	}
	public void ShowDetailedRequest(int reqID)
	{
		detailedReq = GameObject.Find ("Req" + reqID);
		submitButton.SetActive (false);
	}
}
