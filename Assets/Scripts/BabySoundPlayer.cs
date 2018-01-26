using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySoundPlayer : MonoBehaviour {

	public SoundManager soundManager;

	public void PlayBabyCrying () {
		if (soundManager != null) {
			soundManager.PlayBabyCrying ();
		}
	}

}
