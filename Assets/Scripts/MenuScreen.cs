using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
