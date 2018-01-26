using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioClip buttonClick;
	public AudioClip animationClick;
	public AudioClip babyCrying;
	public AudioClip babyLaughing;
	public AudioClip clock;
	public AudioClip stomach;

	public AudioClip bgMusic1;
	public AudioClip bgMusic2;

	public AudioSource soundSource;
	public AudioSource musicSource;

	public void PlayButtonClick() {
		soundSource.Stop ();
		soundSource.clip = buttonClick;
		soundSource.Play ();
	}

	public void PlayAnimationClick() {
		soundSource.Stop ();
		soundSource.clip = animationClick;
		soundSource.Play ();
	}

	public void PlayBabyCrying() {
		soundSource.Stop ();
		soundSource.clip = babyCrying;
		soundSource.Play ();
	}

	public void PlayBabyLaughing() {
		soundSource.Stop ();
		soundSource.clip = babyLaughing;
		soundSource.Play ();
	}

	public void PlayClock() {
		soundSource.Stop ();
		soundSource.clip = clock;
		soundSource.Play ();
	}

	public void PlayStomach() {
		soundSource.Stop ();
		soundSource.clip = stomach;
		soundSource.Play ();
	}

	public void StopSound() {
		soundSource.Stop ();
	}

	public void PlayBgMusic1() {
		musicSource.Stop ();
		musicSource.clip = bgMusic1;
		musicSource.loop = true;
		musicSource.Play ();
	}

	public void PlayBgMusic2() {
		musicSource.Stop ();
		musicSource.clip = bgMusic2;
		musicSource.loop = true;
		musicSource.Play ();
	}

}
