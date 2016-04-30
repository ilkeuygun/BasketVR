using AssemblyCSharp;
using UnityEngine;
using UnityEngine.UI;

public class BackKeyListener : MonoBehaviour {

    public Canvas MainMenuCanvas;
    public Button StartButton;
    public Text StartButtonText;
    public Button ContinueButton;
    public Light LightSource;

    // Use this for initialization
    void Start () {
        ContinueButton.gameObject.SetActive(false);
        LightSource.intensity = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MainMenuCanvas.enabled)
            {
                // Game has started before
                if (ContinueButton.gameObject.activeInHierarchy)
                {
                    // Hide Menu
                    ContinueButton.gameObject.SetActive(false);
                    MainMenuCanvas.enabled = false;
                    Game.Current.IsRunning = true;
                    LightSource.intensity = 1f;
                }
            }
            else
            {
                // Show Menu
                ContinueButton.gameObject.SetActive(true);
                MainMenuCanvas.enabled = true;
                Game.Current.IsRunning = false;
                LightSource.intensity = 0f;
            }
        }
    }
}
