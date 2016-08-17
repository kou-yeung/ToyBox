using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DebugWindow : MonoBehaviour
{
#if UNITY_DEBUG
    public InputField inputField;
    bool active = false;

    void Start()
    {
        SetActive(active);
    }

    void Update()
    {
        DisplaySwitch();
    }

    // DebugWindow の入れ子を表示・非表示を設定する
    // MEMO : 直接 DebugWindow を非表示すると、イベントが届かなくなるので・・
    void SetActive(bool active)
    {
        this.active = active;
        foreach (Transform t in transform) t.gameObject.SetActive(active);
    }

    // 表示・非表示の切り替え
    // Esc キー で行います
    void DisplaySwitch()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetActive(!active);
        }
    }

    public void OnExec()
    {
        var str = inputField.text.Trim();
        if (String.IsNullOrEmpty(str)) return;
        var cmns = str.Split(' ');

        switch (cmns[0].ToLower())
        {
            // コマンド[scene]: シーン遷移
            case "scene":
                SceneManager.LoadScene(cmns[1]);
                break;
            default: break;
        }

        inputField.text = ""; // クリア
    }
#endif //UNITY_DEBUG
}
