using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class BackKeyListener : MonoBehaviour {

    public Canvas MainMenuCanvas;
    public Button StartButton;
    public Text StartButtonText;
    public Canvas ContinueCanvas;

    // Use this for initialization
    void Start () {
        ContinueCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueCanvas.enabled = true;
            MainMenuCanvas.enabled = true;
            Game.Current.IsRunning = false;
        }
    }
}
