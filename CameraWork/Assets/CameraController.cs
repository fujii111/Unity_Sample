using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// 複数カメラを格納する配列
	public Object[] cameras;
	// ターゲットに一番近いカメラまでの距離
	public int nearest = 0;

	// Use this for initialization
	void Start () {
		// カメラオブジェクトをすべて配列に格納
		cameras = GameObject.FindObjectsOfType(typeof(Camera));
	}

	// Update is called once per frame
	void Update () {
		setNearestCamera();
		// カメラをターゲットに向ける
		((Camera)cameras[nearest]).transform.LookAt(this.transform.position);
	}

	// ターゲットに一番近いカメラをセットする
	void setNearestCamera() {
		float min = float.MaxValue;
		for (int i = 0; i < cameras.Length; i++) {
			// いったんすべてのカメラを無効にする
			((Camera)cameras[i]).enabled = false;

			// カメラとターゲットとの距離を計算する
			float distance = Vector3.Distance(this.transform.position, ((Camera)cameras[i]).transform.position);

			// 距離が最小値であれば一番近いカメラとして更新する
			if (distance < min) {
				min = distance;
				nearest = i;
			}
		}
		
		// ターゲットに一番近いカメラを有効にする
		((Camera)cameras[nearest]).enabled = true;
	}
}
