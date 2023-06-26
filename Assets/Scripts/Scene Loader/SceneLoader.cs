using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public UnityEvent OnLoadLevelStart;
    public UnityEvent<float> OnLoadLevelProgress;
    public UnityEvent OnLoadLevelComplete;

    /// <summary>
    /// Load a scene by the given levelName
    /// </summary>
    /// <param name="levelName">Name of the scene to load</param>
    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadSceneAsync(levelName));
    }

    /// <summary>
    /// Loads a given scene by the given level name asynchronously.
    /// </summary>
    /// <param name="levelName"></param>
    /// <returns></returns>
    IEnumerator LoadSceneAsync(string levelName)
    {
        // Create AsyncOperation to hold async scene load
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);

        // Invoke initial Load Level events
        OnLoadLevelStart.Invoke();
        OnLoadLevelProgress.Invoke(0);

        while (!op.isDone)
        {
            // Calculate progress and scale to 0.9f
            // This is because Unity Scene Manager activates the next
            // scene at 0.9f, and the remaining 0.1f is the awake methods in
            // your scene
            float progress = Mathf.Clamp01(op.progress / 0.9f);

            // Invoke current progress from 0f to 1f
            OnLoadLevelProgress.Invoke(progress);

            yield return null;
        }

        // Level Load is complete
        // Invoke Level Load complete events
        OnLoadLevelProgress.Invoke(1f);
        OnLoadLevelComplete.Invoke();
    }

}
