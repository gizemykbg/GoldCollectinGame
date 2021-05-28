using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    	public GameObject playButton;
		public GameObject quitButton;
    
    public void PlayGame()
    {
        playButton.SetActive(true);
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        quitButton.SetActive(true);
        Application.Quit();
    }
}
