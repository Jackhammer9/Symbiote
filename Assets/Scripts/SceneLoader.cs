using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int index;
    public void LoadScene(int buildIndex)
    {
        index = buildIndex;
        GetComponent<Animator>().SetTrigger("Transition");
        Invoke("AsyncLoader" , 2f);
    }
    private void AsyncLoader()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
    }
}
