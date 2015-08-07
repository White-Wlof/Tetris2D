using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	void Start () {
	}
	void Update () {
		setScoreText ();
	}
	void setScoreText(){
		this.GetComponent<Text>().text = Main.scoreText;

	}
}
