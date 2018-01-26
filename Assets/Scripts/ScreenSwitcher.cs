using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenSwitcher : MonoBehaviour {

	public GameObject[] screens;

	public GameObject slide2OnClick;

	public GameObject[] slide3Cs;
	public GameObject slide3ClickHere;
	public Image slide3Dots;
	public Sprite[] slide3DotSprites;

	public GameObject[] slide4Anis;

	public GameObject[] slide6Ts;
	public CanvasGroup[] slide6TsCG;

	public GameObject[] slide7Buttons;

	public SoundManager soundManager;

	public bool destroyPreviousScreens;
	private int currentScreen = 0;

	void Start() {
		NextClicked (0);
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Home)) {
			Exit ();
		}
	}

	public void NextClicked(int screenIndex) {
		switch (screenIndex) {
		case 0:
			soundManager.PlayBgMusic1 ();
			break;
		case 1:
			slide2OnClick.SetActive (false);
			break;
		case 2:
			for (int i = 0; i < slide3Cs.Length; i++) {
				slide3Cs [i].SetActive (i == 0);
			}
			slide3ClickHere.SetActive (true);
			if (slide3DotSprites.Length > 0) {
				slide3Dots.sprite = slide3DotSprites [0];
			}
			break;
		case 3:
			for (int i = 0; i < slide4Anis.Length; i++) {
				slide4Anis [i].SetActive (false);
			}
			break;
		case 4:
			soundManager.PlayBgMusic2 ();
			break;
		case 5:
			for (int i = 0; i < slide6Ts.Length; i++) {
				slide6Ts [i].SetActive (false);
			}
			break;
		case 6:
			for (int i = 0; i < slide7Buttons.Length; i++) {
				slide7Buttons [i].SetActive (false);
			}
			Invoke ("ShowSlide7Buttons", 2.0f);
			break;
		}
		for (int i = 0; i < screens.Length; i++) {
			if (screens [i] != null) {
				screens [i].SetActive (i == screenIndex);
			}
		}
		if (destroyPreviousScreens) {
			GameObject.Destroy (screens [currentScreen]);
			screens [currentScreen] = null;
			Resources.UnloadUnusedAssets ();
		}
		currentScreen = screenIndex;
	}

	public void ResetClicked() {
		if (!destroyPreviousScreens) {
			NextClicked (0);
		} else {
			SceneManager.LoadScene (0);
		}
	}

	public void ExitClicked() {
		Exit ();
	}

	public void Slide2BabyClicked() {
		slide2OnClick.SetActive (true);
	}

	public void Slide3CClicked(int cIndex) {
		slide3ClickHere.SetActive (false);
		for (int i = 0; i < slide3Cs.Length; i++) {
			slide3Cs [i].SetActive (i == cIndex);
		}
		if (cIndex < slide3DotSprites.Length) {
			slide3Dots.sprite = slide3DotSprites [cIndex];
		}
	}

	public void Slide4AniClicked(int aniIndex) {
		for (int i = 0; i < slide4Anis.Length; i++) {
			slide4Anis [i].SetActive (i == aniIndex);
		}
	}

	public void Slide6TClicked(int tIndex) {
		for (int i = 0; i < slide6Ts.Length; i++) {
			slide6Ts [i].SetActive (i == tIndex);
		}
		StartCoroutine (AnimateSlide6T (tIndex));
	}

	private IEnumerator AnimateSlide6T(int tIndex) {
		if (tIndex < slide6TsCG.Length) {
			CanvasGroup cg = slide6TsCG [tIndex];
			WaitForSeconds wait = new WaitForSeconds (0.1f);
			cg.alpha = 0;
			while (cg.alpha < 1) {
				cg.alpha += 0.1f;
				yield return wait;
			}
			cg.alpha = 1;
		}
	}

	private void ShowSlide7Buttons() {
		for (int i = 0; i < slide7Buttons.Length; i++) {
			slide7Buttons [i].SetActive (true);
		}
	}

	private void Exit() {
		Application.Quit ();
	}

}
