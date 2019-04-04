using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [HideInInspector]
    public bool gameHasBegun = false;

    MenuSystem menuSystem;
    // Start is called before the first frame update
    void Start()
    {
        menuSystem = FindObjectOfType<MenuSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YouWin()
    {
        print("You Win");
        menuSystem.GameOverPanelLaunch("You Win");
    }

    public void YouLoose(string HowYouLost)
    {
        switch (HowYouLost)
        {
            case "Bomb":
                menuSystem.GameOverPanelLaunch("You Died From a Bomb Hitting You");
                break;
            case "Boulder":
                menuSystem.GameOverPanelLaunch("You Died from a Boulder Squishing You");
                break;
            case "Anvil":
                menuSystem.GameOverPanelLaunch("Really an Anvil?");
                break;
            case "Falling":
                menuSystem.GameOverPanelLaunch("Did you think you could fly?");
                break;
            default:
                break;
        }
        print("You Loose");
    }

}
