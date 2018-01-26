using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour {

	public string[] folders;
	public int[] framesInFolder;

	private Sprite[][] sprites;
	private bool[] loaded;

	private int currentFolder;
	private int currentFrame;

	void Start() {
		currentFolder = 0;
		currentFrame = 0;
		sprites = new Sprite[folders.Length][];
		loaded = new bool[folders.Length];
		StartCoroutine ("Load");
	}

	private IEnumerator Load() {
		while (currentFolder < folders.Length && currentFolder < framesInFolder.Length) {
			float startTime = Time.realtimeSinceStartup;
			int frames = framesInFolder [currentFolder];
			sprites[currentFolder] = new Sprite[frames];
			string folderName = folders [currentFolder];
			while (currentFrame < frames) {
				string filePath = folderName + currentFrame.ToString("000");
				ResourceRequest request = Resources.LoadAsync(filePath, typeof(Sprite));
				yield return request;
				sprites [currentFolder] [currentFrame] = request.asset as Sprite;
				currentFrame++;
				yield return null;
			}
			loaded [currentFolder] = true;
			currentFolder++;
			currentFrame = 0;
			float endTime = Time.realtimeSinceStartup;
			Debug.Log ("Loader: " + folderName + " Time:" + (endTime - startTime));
		}
	}

	public bool isLoaded(int folder) {
		return folder < loaded.Length && loaded [folder];
	}

	public Sprite[] getSprites(int folder) {
		if (folder < sprites.Length) {
			return sprites [folder];
		}
		return null;
	}

}
