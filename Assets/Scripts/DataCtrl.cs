using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class DataCtrl : MonoBehaviour {
	public GameData data;
	string dataFilePath;
	BinaryFormatter bf;
	public bool devMode;

	public static DataCtrl instance=null;
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} 
		else {
		Destroy (gameObject);
		}
		bf = new BinaryFormatter ();
		dataFilePath=Application.persistentDataPath + "/game.bat";
		Debug.Log (dataFilePath);
	}
	public void SaveData(){
		FileStream fs = new FileStream (dataFilePath , FileMode.Create);
		bf.Serialize (fs,data);
		fs.Close ();
	}
	 public void SaveData(GameData data){
		FileStream fs = new FileStream (dataFilePath , FileMode.Create);
		bf.Serialize (fs,data);
		fs.Close ();
	}

	public void RefreshData(){
		if (File.Exists (dataFilePath)) {
			FileStream fs = new FileStream (dataFilePath,FileMode.Open);
			data = (GameData)bf.Deserialize (fs);
			fs.Close ();
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnEnable(){
		CheckDB ();
	}
//	public bool IsUnlocked(int LevelNum){
//		return data.levelData [LevelNum].isUnLocked;
//	}
//	public int GetStars( int levelNumber){
//		return data.levelData [levelNumber].starAwards;
//	}
	public void CheckDB(){
		if (!File.Exists (dataFilePath)) {
			#if UNITY_ANDROID
			CopyDB();
			#endif
		} else {

			if (SystemInfo.deviceType == DeviceType.Desktop) {
				string destFile = System.IO.Path.Combine (Application.streamingAssetsPath,"game.bat");
				File.Delete (destFile);
				File.Copy (dataFilePath,destFile);
			}
			if (devMode) {
				if (SystemInfo.deviceType == DeviceType.Handheld) {
					File.Delete (dataFilePath);
					CopyDB ();
				}
			}
			RefreshData ();
		}
	}
	void CopyDB(){
		string srcFile = System.IO.Path.Combine (Application.streamingAssetsPath, "game.bat");
		WWW downloader = new WWW (srcFile);
		while (!downloader.isDone) {
		}
		File.WriteAllBytes (dataFilePath, downloader.bytes);
		RefreshData ();
	}
}
