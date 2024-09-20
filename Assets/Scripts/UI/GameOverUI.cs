using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        GameplayManager.instance.GameEnd.AddListener(Show);
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        highScoreText.text = GameManager.instance.HighScore.ToString();
        currentScoreText.text = GameManager.instance.CurrentScore.ToString();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ClickedPlay()
    {
        SceneManager.LoadScene(Constants.DATA.GAMEPLAY_SCENE);
    }

    public void ClickedMenu()
    {
        SceneManager.LoadScene(Constants.DATA.MAIN_MENU_SCENE);
    }
}
