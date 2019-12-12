using UnityEngine;
using UnityEngine.SceneManagement;

public class NextCutScript : MonoBehaviour
{
    public void PreGameCut1To2()
    {
        SceneManager.LoadScene("PreGameCut2");
    }
    public void PreGameCut2To3()
    {
        SceneManager.LoadScene("PreGameCut3");
    }
    public void PreGameCut3ToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
