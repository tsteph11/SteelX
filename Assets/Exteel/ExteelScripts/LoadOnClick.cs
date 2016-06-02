﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoadOnClick : MonoBehaviour {

	public string LoginURL = "https://afternoon-temple-1885.herokuapp.com/login";
	public InputField user, pass;
	public Text error;

	public void Login(){
		WWWForm form = new WWWForm();
//		if (user.text.Length == 0)
		form.AddField("username", user.text);
		form.AddField("password", pass.text);

		WWW www = new WWW(LoginURL, form);

		Debug.Log("Authenticating...");
		while (!www.isDone) {}
		foreach (KeyValuePair<string,string> entry in www.responseHeaders) {
			Debug.Log(entry.Key + ": " + entry.Value);
		}
			
		Debug.Log(www.text);
		if (www.responseHeaders["STATUS"] == "HTTP/1.1 200 OK") {
			string json = www.text;
			Data d = JsonUtility.FromJson<Data>(json);
			UserData.myData = d;
//			Debug.Log(UserData.data.User.Username);
//			Debug.Log(UserData.data.Mech.Core);
			Application.LoadLevel (1);
		}
		else {
			error.gameObject.SetActive(true);
		}
	}
}
