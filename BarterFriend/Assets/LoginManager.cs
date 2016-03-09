using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoginManager : MonoBehaviour {

	public GameObject loginPage;
	public GameObject registerPage; 

	//login page
	public Text loginUsername;
	public Text loginPassword;

	//register page
	public Text registerEmail;
	public Text registerUsername;
	public Text registerPassword;

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
		loginPage.SetActive (false);
		registerPage.SetActive (true);
	}
}
