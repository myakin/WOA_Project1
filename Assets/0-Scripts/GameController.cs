using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public int numberOfLives = 5;
    public List<string> itemsCollected = new List<string>();

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

    #region SCENE MANAGEMENT
    public void ReLoadCurrentScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    #endregion



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
        if (numberOfLives<=0) {
            numberOfLives = 0;
            GameObject myInterface = GameObject.FindGameObjectWithTag("UserInterface");
            myInterface.GetComponent<UIController>().SetGameOver();
        }
    }
    public void IncreaseLives(int anIncrement) {
        numberOfLives += anIncrement;
        if (numberOfLives>5)
            numberOfLives = 5;
        SetLifeVisuals();
    }
    private void SetLifeVisuals() {
        GameObject myInterface = GameObject.FindGameObjectWithTag("UserInterface");
        myInterface.GetComponent<UIController>().SetLifeVisuals(numberOfLives);
    }

    public bool CheckItemIdInCollectedItemsList(string anId) {
        // for (int i=0; i<itemsCollected.Count; i++) {
        //     if (itemsCollected[i]==anId) {
        //         return true;
        //     }
        // }

        // if (itemsCollected.Contains(anId))
        //     return true;
        // return false;

        return itemsCollected.Contains(anId);
    }
    public void AddToItemsCollected(string anId) {
        if (!itemsCollected.Contains(anId))
            itemsCollected.Add(anId);
    }
    public void EmptyItemsCollected() {
        itemsCollected.Clear();
    }
    #endregion


}
