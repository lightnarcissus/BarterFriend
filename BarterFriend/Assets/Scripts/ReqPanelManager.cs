using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ReqPanelManager : MonoBehaviour {

	public GameObject titleText;
	public GameObject descText;
	public GameObject video;
	public GameObject call;
	public GameObject person;
	public GameObject text;
	private bool hasCall=false;
	private bool hasVideo=false;
	private bool hasPerson=false;
	private bool hasText=false;
	public bool myReq=true;
	public GameObject address;
	public GameObject cancel;
	//public Vector3 locScale;
	// Use this for initialization
	void Start () {
			address.SetActive (false);
			call.SetActive (false);
			person.SetActive (false);
			video.SetActive (false);
			text.SetActive (false);
		cancel.SetActive (false);

	//	transform.localScale = locScale;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SendRequest(string reqTitle, int reqOptions, string reqDesc, bool needCall, bool needPerson, bool needVideo, bool needText, bool onlyFriends)
	{
		Debug.Log ("sending request");
		titleText.GetComponent<Text> ().text = reqTitle;
		descText.GetComponent<Text> ().text = reqDesc;
		hasVideo = needVideo;
		hasCall = needCall;
		hasPerson = needPerson;
		hasText = needText;
		if (myReq) {
			if (hasCall)
				call.SetActive (true);
			if (hasPerson)
				person.SetActive (true);
			if (hasVideo)
				video.SetActive (true);
			if (hasText)
				text.SetActive (true);

			cancel.SetActive (false);
		}
	}
	public void BarterTony()
	{
		call.SetActive (true);
			person.SetActive (true);
			video.SetActive (true);
		//	text.SetActive (true);
		cancel.SetActive (true);
	}
	public void Barter()
	{
		//call.SetActive (true);
		person.SetActive (true);
		video.SetActive (true);
		text.SetActive (true);
		cancel.SetActive (true);
	}

	public void Delete()
	{
		Destroy (gameObject);
	}
	public void Video()
	{
		Application.OpenURL ("facetime://archonjake@yahoo.com");
	}
	public void Call()
	{
		Application.OpenURL ("facetime-audio://archonjake@yahoo.com");
	}

	public void Address()
	{
		call.SetActive (false);
		person.SetActive (false);
		video.SetActive (false);
		text.SetActive (false);
		address.SetActive (true);
	}

	public void Cancel()
	{
			call.SetActive (true);

			person.SetActive (true);

			video.SetActive (true);
		address.SetActive (false);
		//cancel.SetActive (false);
	}
}
