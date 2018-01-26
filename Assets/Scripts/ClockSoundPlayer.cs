using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSoundPlayer : MonoBehaviour {

	public SoundManager soundManager;

	public void PlayClock () {
		if (soundManager != null) {
			soundManager.PlayClock();
		}
	}

}
