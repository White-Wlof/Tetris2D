using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	void Start () {
	}
	void Update () {
	}
	public void OnClick(){
		Debug.Log ("Play");

		Application.LoadLevel ("Game");
	}
}
