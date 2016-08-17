using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public void OnButton()
    {
        SceneManager.LoadScene(SceneNameConst.Title);
    }
}
