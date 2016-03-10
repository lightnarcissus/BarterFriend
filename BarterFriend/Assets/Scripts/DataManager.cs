using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Serialization;
public class DataManager : MonoBehaviour {

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
		//UpdateBestScore();
	}
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create	 (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		//Debug.Log ("saved with: " + localBestScore);
		data.persistentBestScore = localBestScore;
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

			localBestScore = data.persistentBestScore;
			UpdateBestScore ();
		} else {

			Debug.Log ("nothing found");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
//		PlayerData play;
	}

	public void UpdateBestScore()
	{
		bestScoreText.text = "Best Score: \n" + localBestScore.ToString ("F2");
	}


	[Serializable]
	class PlayerData
	{
		public float persistentBestScore;
	}
}
