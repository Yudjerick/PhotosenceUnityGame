using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NextLvlBtn : MonoBehaviour
{
    public bool goToMenu;
    private int sceneI;

    
    private void Start()
    {
        sceneI = SceneManager.GetActiveScene().buildIndex;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(NextLevel);
    }

    public void NextLevel()
    {
        if (goToMenu)
        {
            SceneManager.LoadScene(0);
            return;
        }
        if (sceneI != SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(sceneI + 1);
        }
    
    }
}
