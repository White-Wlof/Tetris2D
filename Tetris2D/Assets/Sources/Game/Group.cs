using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour
{
	float lastFall = 0;
	public static float speed = 0;
	private int flag;
	//子ブロックの位置確認
	bool isValidGridPos ()
	{        
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2 (child.position);
			if (!Grid.insideBorder (v))
				return false;
			if (Grid.grid [(int)v.x, (int)v.y] != null &&
			    Grid.grid [(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}
	//グリッド更新
	void updateGrid ()
	{
		//ブロック位置削除
		for (int y = 0; y < Grid.h; ++y) {
			for (int x = 0; x < Grid.w; ++x) {
				if (Grid.grid [x, y] != null) {
					if (Grid.grid [x, y].parent == transform) {
						Grid.grid [x, y] = null;
					}
				}
			}
		}
		//ブロック位置追加
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2 (child.position);
			Grid.grid [(int)v.x, (int)v.y] = child;
		}        
	}

	void Start ()
	{
		flag = 0;
		//生成の有効確認
		if (!isValidGridPos ()) {
			Debug.Log (Main.score);
			Debug.Log ("GAME OVER");
			speed = 0;
			Application.LoadLevel ("Title");
			Destroy (gameObject);
		}
	}

	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-1, 0, 0);
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.position += new Vector3 (1, 0, 0);
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1, 0, 0);

			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.position += new Vector3 (-1, 0, 0);
			}
		} else if (Input.GetKeyDown (KeyCode.Space) && flag == 0 && tag != "O") {
			this.transform.Rotate (0, 0, 90);
			if (tag == "S") {
				this.transform.Rotate (0, 0, -180);
			}
			if (tag == "I") {
				this.transform.localPosition += new Vector3 (0, -1, 0);
			}
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.Rotate (0, 0, -90);
				if (tag == "S") {
					this.transform.Rotate (0, 0, 180);
				}
				if (tag == "I") {
					this.transform.localPosition += new Vector3 (0, 1, 0);
				}
			}
			flag = 1;
			if (tag == "Z" || tag == "S" || tag == "I") {
				flag = 3;
			}
		} else if (Input.GetKeyDown (KeyCode.Space) && flag == 1 && tag != "O") {
			this.transform.Rotate (0, 0, 90);
			this.transform.localPosition += new Vector3 (0, -1, 0);
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				this.transform.Rotate (0, 0, -90);
				this.transform.localPosition += new Vector3 (0, 1, 0);
			}
			flag = 2;
		} else if (Input.GetKeyDown (KeyCode.Space) && flag == 2 && tag != "O") {
			this.transform.Rotate (0, 0, 90);
			this.transform.localPosition += new Vector3 (0, 1, 0);
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				this.transform.Rotate (0, 0, -90);
				this.transform.localPosition += new Vector3 (0, -1, 0);
			}
			flag = 3;
		} else if (Input.GetKeyDown (KeyCode.Space) && flag == 3 && tag != "O") {
			this.transform.Rotate (0, 0, 90);
			if (tag == "Z") {
				this.transform.Rotate (0, 0, -180);
			}
			if (tag == "I") {
				this.transform.Rotate (0, 0, -180);
				this.transform.localPosition += new Vector3 (0, 1, 0);
			}
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.Rotate (0, 0, -90);
				if (tag == "Z") {
					this.transform.Rotate (0, 0, 180);
				}
				if (tag == "I") {
					this.transform.Rotate (0, 0, 180);
					this.transform.localPosition += new Vector3 (0, -1, 0);
				}
			}
			flag = 0;

		}else if (Input.GetKeyDown (KeyCode.X) && flag == 3 && tag != "O") {
			this.transform.Rotate (0, 0, -90);
			if (tag == "S") {
				this.transform.Rotate (0, 0, 180);
			}
			if (tag == "I") {
				this.transform.localPosition += new Vector3 (0, 1, 0);
			}
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.Rotate (0, 0, 90);
				if (tag == "S") {
					this.transform.Rotate (0, 0, -180);
				}
				if (tag == "I") {
					this.transform.localPosition += new Vector3 (0, -1, 0);
				}
			}
			flag = 2;
			if (tag == "Z" || tag == "S" || tag == "I") {
				flag = 0;
			}
		} else if (Input.GetKeyDown (KeyCode.X) && flag == 2 && tag != "O") {
			this.transform.Rotate (0, 0, -90);
			this.transform.localPosition += new Vector3 (0, 1, 0);
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				this.transform.Rotate (0, 0, 90);
				this.transform.localPosition += new Vector3 (0, -1, 0);
			}
			flag = 1;
		} else if (Input.GetKeyDown (KeyCode.X) && flag == 1 && tag != "O") {
			this.transform.Rotate (0, 0, -90);
			this.transform.localPosition += new Vector3 (0, -1, 0);
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				this.transform.Rotate (0, 0, 90);
				this.transform.localPosition += new Vector3 (0, 1, 0);
			}
			flag = 2;
		} else if (Input.GetKeyDown (KeyCode.X) && flag == 0 && tag != "O") {
			this.transform.Rotate (0, 0, -90);
			if (tag == "Z") {
				this.transform.Rotate (0, 0, 180);
			}
			if (tag == "I") {
				this.transform.Rotate (0, 0, 180);
				this.transform.localPosition += new Vector3 (0, -1, 0);
			}
			//有効確認
			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.Rotate (0, 0, 90);
				if (tag == "Z") {
					this.transform.Rotate (0, 0, -180);
				}
				if (tag == "I") {
					this.transform.Rotate (0, 0, -180);
					this.transform.localPosition += new Vector3 (0, 1, 0);
				}
			}
			flag = 3;

		}
//			transform.Rotate(0, 0, -90);

		else if (Input.GetKeyDown (KeyCode.DownArrow) || Time.time - lastFall + speed >= 0.4f) {
			transform.position += new Vector3 (0, -1, 0);
			//有効確認

			if (isValidGridPos ()) {
				updateGrid ();
			} else {
				transform.position += new Vector3 (0, 1, 0);
				Grid.deleteFullRows ();

				//次のグループ呼びだし
				FindObjectOfType<Spawner> ().spawnNextGenerate ();
				FindObjectOfType<Spawner> ().spawnCheck ();
				Spawner.holdflag = 0;
				enabled = false;
			}
			lastFall = Time.time;
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			while (true) {	
				transform.position += new Vector3 (0, -1, 0);
				//有効確認

				if (isValidGridPos ()) {
					updateGrid ();
				} else {
					transform.position += new Vector3 (0, 1, 0);
					Grid.deleteFullRows ();

					//次のグループ呼びだし
					FindObjectOfType<Spawner> ().spawnNextGenerate ();
					FindObjectOfType<Spawner> ().spawnCheck ();
					Spawner.holdflag = 0;
					enabled = false;
					break;
				}
			}
		}
		else if(Input.GetKeyDown(KeyCode.Z)&&Spawner.holdflag==0&&this.transform.position.y<=20){
			FindObjectOfType<Spawner> ().hold();
			Destroy (this.gameObject);
			if (Spawner.holdflag != 1) {
				FindObjectOfType<Spawner> ().spawnNextGenerate ();

			}
			FindObjectOfType<Spawner> ().spawnCheck ();
		}
	}
}
