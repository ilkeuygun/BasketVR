using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class BackKeyListener : MonoBehaviour {

    public Canvas MainMenuCanvas;
    public Button StartButton;
    public Text StartButtonText;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartButtonText.text = "CONTINUE GAME";
            MainMenuCanvas.enabled = true;
            Game.Current.IsRunning = false;
        }
    }
}
