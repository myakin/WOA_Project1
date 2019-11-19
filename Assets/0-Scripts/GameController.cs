using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public int numberOfLives = 5;

    private void Awake() {
        if (GameController.gameController==null) {
            GameController.gameController = this;
        } else {
            if (this != GameController.gameController) {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(GameController.gameController.gameObject);
    }


    #region UTILITIES
    public void SetNumberOfLives(int aLifeValue) {
        numberOfLives = aLifeValue;
        SetLifeVisuals();
    }
    public int GetNumberOfLives() {
        return numberOfLives;
    }
    public void ReduceLives(int aReductionNumber) {
        numberOfLives -= aReductionNumber;
        SetLifeVisuals();
    }
    public void IncreaseLives(int anIncrement) {
        numberOfLives += anIncrement;
        SetLifeVisuals();
    }
    private void SetLifeVisuals() {
        GameObject myInterface = GameObject.FindGameObjectWithTag("UserInterface");
        myInterface.GetComponent<UIController>().SetLifeVisuals(numberOfLives);
    }

    #endregion


}
