using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public int numberOfLives = 5;
    private int lastKnownNumberOfLives = 5;
    public int starCount;
    private int lastKnownStarCount;
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

    private void Start() {
        lastKnownNumberOfLives = numberOfLives;
        lastKnownStarCount = starCount;
    }

    #region SCENE MANAGEMENT
    public void ReLoadCurrentScene() {
        //DefreezeGame();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.sceneLoaded += DefreezeGame;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadNextScene() {
        lastKnownNumberOfLives = numberOfLives;
        lastKnownStarCount = starCount;
        //DefreezeGame();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneInex = currentSceneIndex + 1;
        SceneManager.sceneLoaded += DefreezeGame;
        SceneManager.LoadScene(nextSceneInex);
    }
    public int GetCurrentLevelNo() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        return currentSceneIndex;
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
    public void IncreaseStarCount() {
        starCount++;
        SetStarCountVisual();
    }
    public void SetStarCount(int aNumber) {
        starCount = aNumber;
        SetStarCountVisual();
    }
    private void SetStarCountVisual() {
        GameObject userInterface = GameObject.FindGameObjectWithTag("UserInterface");
        userInterface.GetComponent<UIController>().SetStarCount(starCount);
    }
    public int GetStarCount() {
        return starCount;
    }
    public int[] GetLastKnownStats() {
        int[] returnValue = new int[2];
        returnValue[0] = lastKnownNumberOfLives;
        returnValue[1] = lastKnownStarCount;
        return returnValue;
    }
    public void FreezeGame() {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.GetComponent<PlayerMovement>().DisablePlayerMovement();
        Time.timeScale = 0;
    }
    public void DefreezeGame(Scene scene, LoadSceneMode mode) {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.GetComponent<PlayerMovement>().EnablePlayerMovement();

        GameObject myUI = GameObject.FindGameObjectWithTag("UserInterface");
        myUI.GetComponent<UIController>().UpdateCurrentLevelText();

        Time.timeScale = 1;
        SceneManager.sceneLoaded -= DefreezeGame;
    }
    public void DefreezeGame() {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerGO.GetComponent<PlayerMovement>().EnablePlayerMovement();
        
        GameObject myUI = GameObject.FindGameObjectWithTag("UserInterface");
        myUI.GetComponent<UIController>().UpdateCurrentLevelText();
        
        Time.timeScale = 1;
    }
    #endregion


}
