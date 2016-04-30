using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class MenuButtonListener : MonoBehaviour {

    public Canvas MainMenuCanvas;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonClicked()
    {
        MainMenuCanvas.enabled = false;
        Game.Current.IsRunning = true;
    }

    public void QuitPressed()
    {
        OVRManager.instance.ReturnToLauncher();
    }
}
