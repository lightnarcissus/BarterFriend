using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoginManager : MonoBehaviour {

	public GameObject loginPage;
	public GameObject registerPage; 

	//login page
	public InputField loginUsername;
	public InputField loginPassword;

	//register page
	public InputField registerEmail;
	public InputField registerUsername;
	public InputField registerPassword;

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
}
