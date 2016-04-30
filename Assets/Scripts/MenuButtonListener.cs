using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonListener : MonoBehaviour {

    public Canvas MainMenuCanvas;
    public Button ContinueButton;

	// Use this for initialization
	void Start () {
        ContinueButton.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartNewGame()
    {
        Game.Current.Reset();
        hideMenu();
    }

    public void ContinueGame()
    {
        hideMenu();
    }

    public void QuitPressed()
    {
        OVRManager.instance.ReturnToLauncher();
    }

    private void hideMenu()
    {
        MainMenuCanvas.enabled = false;
        Game.Current.IsRunning = true;
    }
}
