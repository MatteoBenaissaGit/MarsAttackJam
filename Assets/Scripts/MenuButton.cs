using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    
    public void GoToMenu()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
