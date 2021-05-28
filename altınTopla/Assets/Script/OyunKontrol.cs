using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour {
	public bool oyunAktif = true;
	public int altinSayisi = 0;
	public GameObject GameOverPanel;
	public UnityEngine.UI.Text altinSayisiText;
	public UnityEngine.UI.Button baslaButton;
	public GameObject replayButton;
		public GameObject quitButton;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();
		oyunAktif = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AltinArttir(){
		altinSayisi += 1;
		altinSayisiText.text = "" + altinSayisi;
	}

	public void OyunaBasla(){
		oyunAktif = true;
		baslaButton.gameObject.SetActive (false);
		
	}
	public void Olum(){
		oyunAktif = false;
		GameOverPanel.SetActive (true);
		
	}
	public void kazandin(){
		if (altinSayisi ==3){
			SceneManager.LoadScene("Level");
		}
	}
	public void ReplayGame(){
		replayButton.gameObject.SetActive (true);
		SceneManager.LoadScene("Main");
		OyunaBasla();
	}
	public void Cikis(){
		quitButton.gameObject.SetActive(true);
		Application.Quit();
	}
}

