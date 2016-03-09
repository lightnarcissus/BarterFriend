using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System.Collections;

public class RequestState:MonoBehaviour {
	public WWW www;
	public GameObject quad;
	void Start() {
		//StartCoroutine(GetText());
		www=new WWW("http://lightnarcissus.com/wp-content/uploads/2015/10/trialogue_paintitblack-1024x573.png");
	}

	void Update()
	{
		quad.GetComponent<Renderer> ().material.mainTexture = www.texture;
		//Debug.Log (www.text);
	}
	
//	IEnumerator GetText() {
//		UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com");
//		yield return www.Send();
//		
//		if(www.isError) {
//			Debug.Log(www.error);
//		}
//		else {
//			// Show results as text
//			Debug.Log(www.downloadHandler.text);
//			
//			// Or retrieve results as binary data
//			byte[] results = www.downloadHandler.data;
//		}
//	}
}