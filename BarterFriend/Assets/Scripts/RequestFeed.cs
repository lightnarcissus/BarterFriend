using UnityEngine;
using System.Collections;

public class RequestFeed : MonoBehaviour {

	private GameObject detailedReq;
	public GameObject submitButton;
	public GameObject stateManager;
	public GameObject yourReq;
	private GameObject tempPanel;
	public Vector3 reqPos;
	public int reqNum=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReceiveRequest(string reqTitle, int reqOptions, string reqDesc, bool needCall, bool needPerson, bool needVideo, bool needText, bool onlyFriends)
	{
		reqNum++;
		tempPanel = Instantiate (tempPanel, new Vector3(reqPos.x,reqPos.y+ (100f*reqNum),reqPos.z), Quaternion.identity) as GameObject;
		tempPanel.GetComponent<ReqPanelManager> ().SendRequest (reqTitle, reqOptions, reqDesc, needCall, needPerson, needVideo, needText, onlyFriends);
	}

	public void RequestPage()
	{
		stateManager.GetComponent<StateManager> ().SwitchLevel (3);
		//Application.LoadLevel("RequestPage");
	}
	public void ShowDetailedRequest(int reqID)
	{
		detailedReq = GameObject.Find ("Req" + reqID);
		submitButton.SetActive (false);
	}
}
