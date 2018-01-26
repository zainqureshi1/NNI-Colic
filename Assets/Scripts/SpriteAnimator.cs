using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour {

	public bool initialDelay;
	public float delayTime;

	public float frameSeconds = 1;
	public bool loop;
	public int loopStartFrame;

	//The file location of the sprites within the resources folder
	public string location;

	public ResourceLoader loader;
	public int loaderIndex;

	private Image image;
	private Sprite [] sprites;
	private bool loaded;
	private int frame = 0;
	private float deltaTime = 0;

	void Start () {
		image = GetComponent<Image> ();
		loaded = false;
		if (loader == null) {
			Debug.Log ("Loading Start: " + gameObject.name + " Time:" + Time.realtimeSinceStartup);
			Invoke ("LoadSprites", 0.01f);
		}
	}

	void Update () {
		if (!loaded) {
			if (loader != null) {
				if (loader.isLoaded (loaderIndex)) {
					sprites = loader.getSprites (loaderIndex);
					loaded = true;
				}
			}
			return;
		}
		if (!loop && frame == sprites.Length - 1) {
			return;
		}
		if (initialDelay && delayTime > 0) {
			delayTime -= Time.deltaTime;
			return;
		}

		deltaTime += Time.deltaTime;

		/*Loop to allow for multiple sprite frame 
          jumps in a single update call if needed
          Useful if frameSeconds is very small*/
		while (deltaTime >= frameSeconds) {
			deltaTime -= frameSeconds;
			frame++;
			if (frame >= sprites.Length) {
				if (loop) {
					frame = loopStartFrame;
				} else {
					frame = sprites.Length - 1;
				}
			}
		}

		image.sprite = sprites [frame];
	}

	private void LoadSprites() {
		sprites = Resources.LoadAll<Sprite> (location);
		loaded = true;
		Invoke ("LoadComplete", 0.01f);
	}

	private void LoadComplete() {
		Debug.Log ("Loading Complete: " + gameObject.name + " Time:" + Time.realtimeSinceStartup);
	}

}
