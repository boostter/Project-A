using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	public void NextScene (){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame(){
		Application.Quit();
	}
	public void MainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
    public void SelectScene()
    {

        switch (this.gameObject.name)
        {
            case "0-1":
                SceneManager.LoadScene("Level0-1");
                Debug.Log("go to brazil");
                break;
            case "0-2":
                SceneManager.LoadScene("Level0-2");
                break;
            case "0-3":
                SceneManager.LoadScene("Level0-3");
                break;
            case "0-4":
                SceneManager.LoadScene("Level0-4");
                break;
            case "1-1":
                SceneManager.LoadScene("Level1-1");
                break;
            case "1-2":
                SceneManager.LoadScene("Level1-2");
                break;
            case "1-3":
                SceneManager.LoadScene("Level1-3");
                break;
            case "1-4":
                SceneManager.LoadScene("Level1-4");
                break;
        }


    }
}
