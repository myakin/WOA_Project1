using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image[] lifeImages;
    public Transform gameOverPanel, endLevelPanel;
    public Button playAgainButton, endLevelPanelQuitAppButton, endLevelPanelPlayAgainButton;
    public Button endLevelPanelNextLevelButton;
    public Text starCountText, endLevelPanelStarCountText, endLevelPanelLevelNoText, currentLevelText;


    private void Start() {
        UpdateCurrentLevelText();
        SetLifeVisuals(GameController.gameController.GetNumberOfLives());
        SetStarCount(GameController.gameController.starCount);
        playAgainButton.onClick.AddListener(PlayAgain);
        endLevelPanelQuitAppButton.onClick.AddListener(QuitApp);
        endLevelPanelPlayAgainButton.onClick.AddListener(PlayAgain);
        endLevelPanelNextLevelButton.onClick.AddListener(NextLevel);
    }

    public void SetLifeVisuals(int aLifeValue) {
        int lastIndexNoOfMyLives = aLifeValue - 1;
        for (int i=0; i<lifeImages.Length; i++) {
            if (i>lastIndexNoOfMyLives) {
                Color noAlphaColor = new Color(1,1,1,70f/255);
                lifeImages[i].color = noAlphaColor;
            } else {
                Color yesAlphaColor = new Color(1,1,1,1);
                lifeImages[i].color = yesAlphaColor;
            }
        }
    } 

    public void SetGameOver() {
        gameOverPanel.gameObject.SetActive(true);
    }

    

    public void SetStarCount(int aNumber) {
        starCountText.text = aNumber.ToString();
    }



    #region endLevelPanel Functions
    public void ShowEndLevelPanel() {
        UpdateLevelTextInEndPanel();
        UpdateStarTextInEndPanel();
        SetEndLevelPanelVisibility(true);
        GameController.gameController.FreezeGame();
    }
    public void SetEndLevelPanelVisibility(bool aVisibilityValue){
        endLevelPanel.gameObject.SetActive(aVisibilityValue);
    }

    private void QuitApp(){
        Application.Quit();
    }
    private void NextLevel() {
        GameController.gameController.LoadNextScene();
    }
    private void PlayAgain() {
        int[] lastKnownStats = GameController.gameController.GetLastKnownStats();
        GameController.gameController.SetStarCount(lastKnownStats[1]);
        GameController.gameController.SetNumberOfLives(lastKnownStats[0]);
        GameController.gameController.EmptyItemsCollected();
        GameController.gameController.ReLoadCurrentScene();
    }

    private void UpdateLevelTextInEndPanel() {
        endLevelPanelLevelNoText.text = GameController.gameController.GetCurrentLevelNo().ToString();
    }
    private void UpdateStarTextInEndPanel() {
        endLevelPanelStarCountText.text = GameController.gameController.GetStarCount().ToString();
    }


    #endregion

    #region UTILITIES
    public void UpdateCurrentLevelText() {
        currentLevelText.text = GameController.gameController.GetCurrentLevelNo().ToString();
    }

    #endregion
    
}
