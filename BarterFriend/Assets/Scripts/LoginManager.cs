using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Experimental.Networking;
public class LoginManager : MonoBehaviour {

	public GameObject loginPage;
	public GameObject registerPage; 

	private UnityWebRequest registerDetails;
	private UnityWebRequest loginDetails;

	//login page
	public InputField loginUsername;
	public InputField loginPassword;

	//register page
	public InputField registerEmail;
	public InputField registerUsername;
	public InputField registerPassword;
	public GameObject dataManager;
	public string screenShotURL= "http://lightnarcissus.com/projects/barterfriend/cgi-bin/upload.cgitrangecreatures/cgi-bin/upload.cgi";
	private int loginState = 0;

	// Use this for initialization
	void Start () {
		loginState = 1;
		registerPage.SetActive (false);
		loginPage.SetActive (true);
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	public void LoginUser()
	{
		Application.LoadLevel ("RequestMenu");
	}

	public void MakeUserRegister()
	{
		loginState = 2;
		loginPage.SetActive (false);
		registerPage.SetActive (true);
	}
	public void RegisterUser()
	{
		//registers
		loginState=1;
		loginPage.SetActive (true);
		registerPage.SetActive (false);
	}

	IEnumerator UploadNewUser() {
		WWWForm form = new WWWForm();
		form.AddField ("Email", registerEmail.text);
		form.AddField("Username", registerUsername.text);
		form.AddField ("Password", registerPassword.text);

		UnityWebRequest www = UnityWebRequest.Post("http://lightnarcissus.com/upload", form);
		yield return www.Send();

		if(www.isError) {
			Debug.Log(www.error);
		}
		else {
			Debug.Log("Form upload complete!");
		}
	}

}
