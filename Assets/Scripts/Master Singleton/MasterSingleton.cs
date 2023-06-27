using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSingleton : MonoBehaviour
{
    private static MasterSingleton _instance;
    public static MasterSingleton Instance
    {
        get
        {
            return _instance;
        }
    }

    private SceneLoader _sceneLoader;

    public SceneLoader SceneLoader => _sceneLoader;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);

            // Get Child Components
            _sceneLoader = GetComponentInChildren<SceneLoader>();
        }
        else
        {
            Destroy(this);
        }


    }


}
