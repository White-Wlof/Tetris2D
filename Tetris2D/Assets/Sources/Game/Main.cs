using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public static float score;
	public static string scoreText;
	public static GameObject objectTask;
	public static int count4;
	void Start () {
		score = 0;
		count4 = 0;
		scoreText = "0";
		objectTask = null;
	}
	public static void setScore(){
		float s = 0;
		if (Grid.n  == 1) {
			s = 100;
			count4 = 0;
		} else if (Grid.n == 2) {
			s = 300;
			count4 = 0;
		}else if (Grid.n == 3) {
			s = 450;
			count4 = 0;
		}else if (Grid.n == 4) {
			count4++;
			s = 600 * 1.5f * count4;
		}
		score += s;
		setScoreText ();
		Grid.n = 0;
	}
	public static void setScoreText(){
		scoreText = score.ToString();
	}
	void Update () {
	}
}
