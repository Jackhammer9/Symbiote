using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class SceneLoader : MonoBehaviour
{
    private int index;
    public Image Bar;
    public GameObject LoadingBar;

    public void LoadScene(int buildIndex)
    {
        index = buildIndex;
        GetComponent<Animator>().SetTrigger("Transition");
        StartCoroutine(AsyncLoader(index));
    }
    IEnumerator AsyncLoader(int buildIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);
            
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            Bar.fillAmount = operation.progress;
            yield return null;
        }
    }

}
