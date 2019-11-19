using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image[] lifeImages;
    public Transform gameOverPanel;
    public Button playAgainButton;

    private void Start() {
        SetLifeVisuals(GameController.gameController.GetNumberOfLives());
        playAgainButton.onClick.AddListener(PlayAgain);
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

    private void PlayAgain() {
        GameController.gameController.SetNumberOfLives(5);
        GameController.gameController.EmptyItemsCollected();
        GameController.gameController.ReLoadCurrentScene();
    }
}
