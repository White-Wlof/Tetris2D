using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject[] groups = new GameObject[7];
	public string[] groupNameList = new string[7] { "I", "L", "J", "O", "Z", "S", "T" };
	public int[] spawnNum;
	public int holdNum;
	public int holdNowNum;
	public GameObject nowNum;
	public GameObject[] next;
	public GameObject holdObject;
	public GameObject holding;
	public static int holdflag;
	public int count = 0;

	void Start ()
	{   
		holdflag = 0;
		holdNowNum = 0;
		holdObject = null;
		spawnNum = new int[4] { 7, 7, 7, 7 };
		next = new GameObject[4]; 
		holding = new GameObject ();
		holding = GameObject.Find ("Hold");
		for (int i = 0; i < next.Length; i++) {
			next [i] = GameObject.Find ("Next-" + i);
		}
		loadObject ();
		spawnCheck ();
		spawnNextGenerate ();
		spawnCheck ();
	}

	void Update ()
	{
	}

	public void loadObject ()
	{
		for (int i = 0; i < groups.Length; i++) {
			groups [i] = (GameObject)Resources.Load ("PreFab/" + groupNameList [i]);
		}
	}

	public void spawnCheck ()
	{
		for (int i = 0; i < spawnNum.Length; i++) {
			if (spawnNum [i] == 7) {
				spawnNext (i);
			}
		}
	}

	public void spawnNext (int p)
	{
		int i = Random.Range (0, groups.Length);
		spawnNum [p] = i;
	}

	public void spawnNextGenerate ()
	{
		Instantiate (groups [spawnNum [0]], transform.position, Quaternion.identity);
//		nowNum = spawnNum [0];
		holdNowNum = spawnNum [0];
		nowNum = groups [spawnNum [0]];
		spawnNum [0] = spawnNum [1];
		spawnNum [1] = spawnNum [2];
		spawnNum [2] = spawnNum [3];
		spawnNum [3] = 7;
		nextObject (spawnNum);
//		Debug.Log (Group.speed);
//		Debug.Log (Time.time);
		if (Time.time > 20*count) {
			Group.speed +=0.025f;
			Debug.Log (Group.speed);
			count++;
		}
	}

	private void nextObject (int[] n)
	{
		for (int i = 0; i < next.Length - 1; i++) {
			for (int j = 0; j < groupNameList.Length; j++) {
				next [i].transform.FindChild ("N" + groupNameList [j]).GetComponent<Renderer> ().enabled = false;
			}
		}
		for (int i = 0; i < next.Length - 1; i++) {
			next [i].transform.FindChild ("N" + groupNameList [n [i]]).GetComponent<Renderer> ().enabled = true;
		}
	}

	public void hold ()
	{
		if(holdObject!=null){
			Instantiate (groups [holdNum], transform.position, Quaternion.identity);
			holdflag = 1;
		}
//		else if(holdObject==null){
//			FindObjectOfType<Spawner> ().spawnNextGenerate ();
//			FindObjectOfType<Spawner> ().spawnCheck ();
//		}
		holdNum = holdNowNum;
		holdObject = nowNum;
	
		for (int j = 0; j < groupNameList.Length; j++) {
			holding.transform.FindChild ("N" + groupNameList [j]).GetComponent<Renderer> ().enabled = false;
		}
		holding.transform.FindChild ("N" + holdObject.name).GetComponent<Renderer> ().enabled = true;



	}

}
