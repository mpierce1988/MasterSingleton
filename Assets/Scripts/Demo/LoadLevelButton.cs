using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelButton : MonoBehaviour
{
    [SerializeField]
    private string _levelName;

    // Load the given level name using the MasterSingleton SceneLoader
    public void LoadLevel()
    {
        MasterSingleton.Instance.SceneLoader.LoadLevel(_levelName);
    }
}
