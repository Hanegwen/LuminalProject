using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{

    [SerializeField]
    GameObject MainPanel, InstructionsPanel, CreditsPanel, GameOverPanel;

    CoreyManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<CoreyManager>();

        MainPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameButton()
    {
        manager.gameHasBegun = true;
        this.gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void InstructionsButton()
    {
        InstructionsPanel.SetActive(true);

        MainPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void CreditsButton()
    {
        CreditsPanel.SetActive(true);

        MainPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        MainPanel.SetActive(true);

        InstructionsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void GameOverPanelLaunch(string textToSetForGameOverText)
    {
        this.gameObject.GetComponent<Canvas>().enabled = true;

        GameOverPanel.GetComponentInChildren<TextMesh>().text = textToSetForGameOverText;

        GameOverPanel.SetActive(true);
        MainPanel.SetActive(true);
        InstructionsPanel.SetActive(true);
        CreditsPanel.SetActive(true);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
