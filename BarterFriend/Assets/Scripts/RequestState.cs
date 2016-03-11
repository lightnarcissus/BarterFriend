using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Experimental.Networking;
using System.Collections;

public class RequestState:MonoBehaviour {
	public WWW www;
	public GameObject quad;
	private GameObject listIP;
	public GameObject stateManager;
	void Start() {
		//StartCoroutine(GetText());
		//www=new WWW("http://lightnarcissus.com/wp-content/uploads/2015/10/trialogue_paintitblack-1024x573.png");
		listIP=ListIP.selfIP;
	}

	void Update()
	{
	//	quad.GetComponent<Renderer> ().material.mainTexture = www.texture;
		//Debug.Log (www.text);
	}

	public void ReceiveRequest()
	{
		//stateManager.GetComponent<StateManager> ().SwitchLevel (3);
	}
	
	IEnumerator GetText() {
		UnityWebRequest www = UnityWebRequest.GetTexture("http://lightnarcissus.com/wp-content/uploads/2015/10/trialogue_paintitblack-1024x573.png");
		yield return www.Send();
		
		if(www.isError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			quad.GetComponent<Renderer> ().material.mainTexture =((DownloadHandlerTexture)www.downloadHandler).texture;
		}

	}
}