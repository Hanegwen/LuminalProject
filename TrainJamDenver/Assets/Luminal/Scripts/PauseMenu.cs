using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePrefab;

    bool isPaused = false;

    private void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.N))
        {
            if (!isPaused)
            {
                pausePrefab.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                pausePrefab.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }
}
