using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AppInit : MonoBehaviour
{
	void Start ()
    {
        CreateDebugWindow();
        SceneManager.LoadScene(SceneNameConst.Title);        	
	}

    void CreateDebugWindow()
    {
        string name = "DebugWindow";
        Instantiate(Resources.Load(name));
    }
}
