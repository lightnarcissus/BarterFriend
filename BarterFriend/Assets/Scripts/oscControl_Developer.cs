//
//	  UnityOSC - Example of usage for OSC receiver
//
//	  Copyright (c) 2012 Jorge Garcia Martin
//
// 	  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// 	  documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// 	  the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
// 	  and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// 	  The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// 	  of the Software.
//
// 	  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// 	  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// 	  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// 	  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// 	  IN THE SOFTWARE.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;
using UnityEngine.UI;

public class oscControl_Developer : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;

	public GameObject reqFeed;
	public string requestTitle;
	public int requestOptions;
	public string requestDesc;
	public bool hasCall;
	public bool hasPerson;
	public bool hasVideo;
	public bool hasText;
	public bool friendsOnly;
	private float boolVal=0f;
	// Script initialization
	void Start() {	
		OSCHandler_Developer.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {
		OSCHandler_Developer.Instance.UpdateLogs();
		servers = OSCHandler_Developer.Instance.Servers;
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/ReqTitle", "nice");
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/ReqOptions", 1);
	    foreach( KeyValuePair<string, ServerLog> item in servers )
		{
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if(item.Value.log.Count > 0) 
			{
				int lastPacketIndex = item.Value.packets.Count - 1;
//				
//				UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE 0: {2}", 
//				                                    item.Key, // Server name
//				                                    item.Value.packets[lastPacketIndex].Address, // OSC address
//				                                    item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value

				float tempVal = float.Parse (item.Value.packets [lastPacketIndex].Data [0].ToString ());
				string tempString = item.Value.packets [lastPacketIndex].Data [0].ToString ();
				int tempInt = int.Parse (item.Value.packets [lastPacketIndex].Data [0].ToString ());
				Debug.Log("Message received "+tempString);
				if (item.Value.packets[lastPacketIndex].Address == "/ReqTitle")
				{
					requestTitle = tempString;
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/ReqDesc")
				{
					requestDesc= tempString;
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/ReqOptions")
				{
					requestOptions = tempInt;
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/NeedCall")
				{
					if (tempVal == 0)
						hasCall = false;
					else
						hasCall = true;
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/NeedPerson")
				{
					if (tempVal == 0)
						hasPerson = false;
					else
						hasPerson= true;
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/NeedVideo")
				{
					if (tempVal == 0)
						hasVideo = false;
					else
						hasVideo = true;
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/NeedText")
				{
					if (tempVal == 0)
						hasText = false;
					else
						hasText = true;
				}
				else if (item.Value.packets[lastPacketIndex].Address == "/OnlyFriends")
				{
					if (tempVal == 0)
						friendsOnly = false;
					else
						friendsOnly = true;
				}

			//	GameObject tempObj = GameObject.Find ("Req1");
				reqFeed.GetComponent<RequestFeed>().ReceiveRequest (requestTitle, requestOptions, requestDesc, hasCall, hasPerson, hasVideo, hasText, friendsOnly);

			}
		}
	}
	public static void SendRequest(string reqTitle, int reqOptions, string reqDesc, bool needCall, bool needPerson, bool needVideo, bool needText, bool onlyFriends)
	{
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/ReqTitle", reqTitle);
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/ReqOptions", reqOptions);
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/ReqDesc", reqDesc);
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/NeedCall", needCall);
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/NeedPerson", needPerson);
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/NeedVideo", needVideo);
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/NeedText", needText);
		OSCHandler_Developer.Instance.SendMessageToClient ("Max", "/OnlyFriends", onlyFriends);
	}

	public void MakeRequest()
	{
		gameObject.transform.FindChild ("Title").gameObject.GetComponent<Text> ().text = requestTitle;
		gameObject.transform.FindChild ("Description").gameObject.GetComponent<Text> ().text = requestDesc;
	}
}