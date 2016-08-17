//-------------------------------------------
// Unity プロジェクト内にあるシーン一覧によって
// シーン名の定数を自動生成する拡張です
// Tools/SceneNameConstGenerator
//-------------------------------------------
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class SceneNameConstGenerator
{
    // 生成されるファイル名
    static readonly string filename = "SceneNameConst.cs";

    // シーンの名前一覧取得
    static List<string> SceneNames()
    {
        List<string> res = new List<string>();

        var guids = AssetDatabase.FindAssets("t:Scene");
        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            res.Add(Path.GetFileNameWithoutExtension(path));
        }
        res.Sort();
        return res;
    }

    // 生成されるファイルの出力パス
    // 初めて生成する場合、"Project" Window に選択されているパスを返す
    // 既に生成された場合、既存の階層のパスを返す
    static string OutputPath()
    {
        // 出力済のファイルを検索する
        var fns = Directory.GetFiles(Application.dataPath, filename, SearchOption.AllDirectories);

        if (fns.Length <= 0)
        {
            // 初めて実行なので、選択しているフォルダーに出力
            var guids = Selection.assetGUIDs;
            if (guids.Length != 1) return Application.dataPath;
            var path = AssetDatabase.GUIDToAssetPath(guids[0]);
            if (path.StartsWith("Assets")) path = path.Substring("Assets".Length);
            return Path.Combine(Application.dataPath, path.TrimStart('/','\\'));
        }
        else
        {
            return Path.GetDirectoryName(fns[0]);
        }
    }

    [MenuItem("Tools/SceneNameConstGenerator")]
    static void Exec()
    {
        var sb = new StringBuilder();

        // ヘッダーを記載する
        sb.AppendLine("//--------------------------------------------------------");
        sb.AppendLine("// このファイルは SceneNameConstGenerator によって生成されます");
        sb.AppendLine("// 直接編集しないでください");
        sb.AppendLine("// Tools/SceneNameConstGenerator");
        sb.AppendLine("// ");
        sb.AppendFormat("// Created Date : {0}", DateTime.Now.ToString()).AppendLine();
        sb.AppendLine("//--------------------------------------------------------");
        sb.AppendLine();

        // クラス名の書き出し
        sb.AppendLine("public class SceneNameConst");
        sb.AppendLine("{");

        // シーン一覧出力
        foreach (var scene in SceneNames())
        {
            sb.AppendLine(String.Format("    static public readonly string {0} = \"{0}\";", scene));
        }
        sb.AppendLine("}");

        // 書き出し
        File.WriteAllText(Path.Combine(OutputPath(), filename), sb.ToString());

        // リフレッシュ
        AssetDatabase.Refresh();
    }
}
