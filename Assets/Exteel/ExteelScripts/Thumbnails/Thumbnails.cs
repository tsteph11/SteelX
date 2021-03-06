﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System.IO;

public class Thumbnails : MonoBehaviour {

	private string[] parts = {"SHL009", "APS403", "SHS309"};//, "CES301", "LTN411", "HDS003", "AES707", "AES104", "PBS000" };

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		for (int i = 0; i < parts.Length; i++) {
			Debug.Log(parts[i]);
			string part = parts[i];
			GameObject o = Resources.Load (part) as GameObject;
//			Material material = Resources.Load (part + "mat", typeof(Material)) as Material;
//			o.GetComponentInChildren<SkinnedMeshRenderer> ().material = material;

			Instantiate (o, new Vector3 (0, 0, 0), Quaternion.identity);
			Texture2D t2d = AssetPreview.GetAssetPreview (o);
			if (t2d == null) {
				Debug.Log("null, going to next");
			}
			byte[] bytes = t2d.EncodeToPNG ();
			Debug.Log ("Path: " + Application.dataPath + "/Exteel/ExteelScripts/Thumbnails/" + parts [i] + ".png");
			File.WriteAllBytes(Application.dataPath + "/Exteel/ExteelScripts/Thumbnails/" + parts[i]+".png", bytes);
		}
		#endif
	}
}
