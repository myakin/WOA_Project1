using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image[] lifeImages;

    private void Start() {
        SetLifeVisuals(GameController.gameController.GetNumberOfLives());
    }

    public void SetLifeVisuals(int aLifeValue) {
        int lastIndexNoOfMyLives = aLifeValue - 1;
        for (int i=0; i<lifeImages.Length; i++) {
            if (i>lastIndexNoOfMyLives) {
                Color noAlphaColor = new Color(1,1,1,70f/255);
                lifeImages[i].color = noAlphaColor;
            }
        }
    } 
}
