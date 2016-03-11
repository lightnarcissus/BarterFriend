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
	//public Vector3 locScale;
	// Use this for initialization
	void Start () {

	//	transform.localScale = locScale;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SendRequest(string reqTitle, int reqOptions, string reqDesc, bool needCall, bool needPerson, bool needVideo, bool needText, bool onlyFriends)
	{
		titleText.GetComponent<Text> ().text = reqTitle;
		descText.GetComponent<Text> ().text = reqDesc;
		hasVideo = needVideo;
		hasCall = needCall;
		hasPerson = needPerson;
		hasText = needText;
	}
	public void Barter()
	{
		if (hasCall)
			call.SetActive (false);
		if (hasPerson)
			person.SetActive (false);
		if (hasVideo)
			video.SetActive (false);
		if (hasText)
			text.SetActive (false);
	}

	public void Delete()
	{
		Destroy (gameObject);
	}
}
