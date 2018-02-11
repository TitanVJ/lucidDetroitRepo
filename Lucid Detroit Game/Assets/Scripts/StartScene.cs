using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class StartScene : MonoBehaviour
{

    public GameObject loadingImage;

    public void LoadScene(int level)
    {
        loadingImage.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}