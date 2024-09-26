using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneListManager : MonoBehaviour
{

    public static int sceneNumbers = 0;

    public static int selectedSceneIndex = 0;

    public static String selectedSceneString = "";

    public GameObject selectedSceneTextDisplay;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
        sceneNumbers = SceneManager.sceneCountInBuildSettings;
        selectedSceneIndex = SceneManager.GetActiveScene().buildIndex;
        selectedSceneString = SceneManager.GetActiveScene().name;
        selectedSceneTextDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = selectedSceneString;
    }

    public void GetPreviousScene () {
        if (selectedSceneIndex > 0) {
            selectedSceneIndex--;
        }
        selectedSceneTextDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = SceneUtility.GetScenePathByBuildIndex(selectedSceneIndex).Replace("Assets/Scenes/","").Replace(".unity","");
    }
        

    public void GetNextScene() {
        if (selectedSceneIndex < (sceneNumbers - 1)) {
            selectedSceneIndex++;
        }
        selectedSceneTextDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = SceneUtility.GetScenePathByBuildIndex(selectedSceneIndex).Replace("Assets/Scenes/","").Replace(".unity","");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene() {
         SceneManager.LoadScene(selectedSceneIndex);
    }

    public void ExitToMain() {
        selectedSceneIndex = 0;
        SceneManager.LoadScene(0);
    }
}
