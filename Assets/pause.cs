using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {

	public bool isGamePaused = false;

	public GameObject PauseMenuUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void paused () {
		if(isGamePaused){
			Resume();
		}else{
			Pause();
		}
	}

	void Resume(){
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isGamePaused = false;
	}
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
