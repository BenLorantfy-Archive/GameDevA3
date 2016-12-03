using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPauseMenu : MonoBehaviour
{
    public GameObject Background;
    public GameObject Menu;
    public GameObject HelpMenu;

    public Button ResumeButton;
    public Button RestartButton;
    public Button HelpButton;
    public Button ExitButton;

    public int currentLevel;

    private bool pause;

    private RectTransform transform;
    private Image backImage;
    private AudioLowPassFilter audioFilter;

    private bool showMenu;
    private bool showHelp;

	void Start ()
	{
	    transform = Background.GetComponent<RectTransform>();
	    backImage = Background.GetComponent<Image>();
	    audioFilter = Camera.main.GetComponent<AudioLowPassFilter>();

	    pause = false;

        ResumeButton.onClick.AddListener(() =>
        {
            pause = false;
        });

        RestartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });

        HelpButton.onClick.AddListener(() =>
        {
            showHelp = true;
            showMenu = false;
        });

        ExitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
	
	// Update is called once per frame
	void Update () {
        UpdateBackground();

	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
            if (!showHelp)
            {
                pause = !pause;
            }

            showHelp = false;
	        showMenu = true;
	    }

	    if (pause)
	    {
	        Pause();
	    }
	    else
	    {
	        Resume();
	    }
	}

    private void UpdateBackground()
    {
        transform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    private void Pause()
    {
        Time.timeScale = 0;
        
        backImage.enabled = true;
        audioFilter.enabled = true;

        Menu.SetActive(showMenu);
        // HelpMenu.SetActive(showHelp);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
        backImage.enabled = false;
        audioFilter.enabled = false;
    }

    void OnGUI()
    {
    }
}
