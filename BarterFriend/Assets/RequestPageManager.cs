using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Serialization;
public class RequestPageManager : MonoBehaviour {

	//request properties
	public InputField reqTitle;
	public Dropdown reqType;
	public InputField reqDescription;
	public Toggle person;
	public Toggle video;
	public Toggle call;
	public Toggle text;
	public Toggle friendsOnly;

	public string savepath;
	public float localBestScore;
	public Text bestScoreText;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			savepath = Application.dataPath.Replace ("game.app/Data", "/Documents/");
		} else {
			savepath = Application.dataPath;
		}

		Load ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SubmitRequest()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create	 (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		//Debug.Log ("saved with: " + localBestScore);
		data.reqTitle = reqTitle.text;
		data.reqType = reqType.value;
		data.reqDesc = reqDescription.text;
		data.needCall = call.isOn;
		data.needPerson = person.isOn;
		data.needVideo = video.isOn;
		data.needText = text.isOn;
		data.onlyFriends = friendsOnly.isOn;
		bf.Serialize (file, data);
		file.Close ();
		Application.LoadLevel ("RequestMenu");
		oscControl_Developer.SendRequest (data.reqTitle,data.reqType,data.reqDesc,data.needCall,data.needPerson,data.needVideo,data.needText,data.onlyFriends);
	}


		public void Save()
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create	 (Application.persistentDataPath + "/playerInfo.dat");

			PlayerData data = new PlayerData ();
			//Debug.Log ("saved with: " + localBestScore);
			data.reqTitle = reqTitle.text;
		data.reqType = reqType.value;
		data.reqDesc = reqDescription.text;
		data.needCall = call.isOn;
		data.needPerson = person.isOn;
		data.needVideo = video.isOn;
		data.needText = text.isOn;
		data.onlyFriends = friendsOnly.isOn;
			bf.Serialize (file, data);
			file.Close ();
		}

		public void Load()
		{
			if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
				PlayerData data = (PlayerData)bf.Deserialize (file);
				file.Close ();

				//Debug.Log ("file loaded with: "+data.persistentBestScore);

				//localBestScore = data.persistentBestScore;
				//UpdateBestScore ();
			} else {

				Debug.Log ("nothing found");
			}
		}
		
		public void UpdateBestScore()
		{
			bestScoreText.text = "Best Score: \n" + localBestScore.ToString ("F2");
		}


		[Serializable]
		class PlayerData
		{
		public string reqTitle;
		public int reqType;
		public string reqDesc;
		public bool needPerson;
		public bool needCall;
		public bool needVideo;
		public bool needText;
		public bool onlyFriends;

		}
	}
