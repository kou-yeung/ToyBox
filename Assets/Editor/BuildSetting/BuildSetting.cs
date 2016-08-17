using UnityEditor;
using System.Collections.Generic;

public class BuildSetting
{
    [MenuItem("BuildSetting/Master")]
    public static void Master()
    {
        SetScriptingDefineSymbols("");
    }

    [MenuItem("BuildSetting/Develop")]
    public static void Develop()
    {
        SetScriptingDefineSymbols("UNITY_DEBUG");
    }

    static void SetScriptingDefineSymbols(string definds)
    {
        var group = EditorUserBuildSettings.selectedBuildTargetGroup;
        PlayerSettings.SetScriptingDefineSymbolsForGroup(group, definds);
    }
}
