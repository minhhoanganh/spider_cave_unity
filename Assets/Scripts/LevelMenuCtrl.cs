using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuCtrl : MonoBehaviour
{
    public void LevelPlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
