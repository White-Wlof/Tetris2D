using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	//グリッド
	public static int w = 10;
	public static int h = 27;
	public static int n = 0;
	public static Transform[,] grid = new Transform[w, h];
	//ベクトルの小数点の切り捨て
	public static Vector2 roundVec2(Vector2 v) {
		return new Vector2(Mathf.Round(v.x),Mathf.Round(v.y));
	}
	//グリッド内判定
	public static bool insideBorder(Vector2 pos) {
		return ((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
	}
	//特定の行のすべてのブロックを削除
	public static void deleteRow(int y) {
		for (int x = 0; x < w; ++x) {

			Destroy(grid[x, y].gameObject);
			grid[x, y] = null;

		}
//		Main.setScore ();
	}
	//行削除時、一段落下
	public static void decreaseRow(int y) {
		for (int x = 0; x < w; ++x) {
			if (grid[x, y] != null) {
				//底部に向かって1を移動
				grid[x, y-1] = grid[x, y];
				grid[x, y] = null;
				//更新ブロック位置
				grid[x, y-1].position += new Vector3(0, -1, 0);
			}
		}
	}
	//decreaseRoW関数を削除行以上に適応
	public static void decreaseRowsAbove(int y) {
		for (int i = y; i < h; ++i) {
			decreaseRow (i);
		}
	}
	//削除開始命令
	public static bool isRowFull(int y) {
		for (int x = 0; x < w; ++x) {
			if (grid [x, y] == null) {
				return false;
			}
		}
		return true;
	}
	//削除命令統括
	public static void deleteFullRows() {
		for (int y = 0; y < h; ++y) {
			if (isRowFull(y)) {
				n++;
//				Debug.Log (n);
				deleteRow(y);
				decreaseRowsAbove(y+1);
				--y;
			}
		}
		Main.setScore ();
	}
}
