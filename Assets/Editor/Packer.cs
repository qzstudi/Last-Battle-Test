using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Diagnostics;
using UnityEditor;

public class Packer {

    public static string platform = string.Empty;
    static List<string> paths = new List<string>();
    static List<string> files = new List<string>();

    [MenuItem("Game/Build iPhone Resource", false, 1)]
    public static void BuildiPhoneResource()
    {
        BuildTarget target;
        target = BuildTarget.iOS;
        BuildAssetResource(target, false);
    }

    [MenuItem("Game/Build Android Resource", false, 2)]
    public static void BuildAndroidResource()
    {
        BuildTarget target;
        target = BuildTarget.Android;
        BuildAssetResource(target, true);
    }

    [MenuItem("Game/Build Windows Resource", false, 3)]
    public static void BuildWindowsResource()
    {
        BuildTarget target;
        target = BuildTarget.StandaloneWindows;
        BuildAssetResource(target, true);
    }
    public static void BuildAssetResource(BuildTarget target, bool isWin)
    {
        string dataPath = Util.DataPath;
        if (Directory.Exists(dataPath))
        {
            Directory.Delete(dataPath,true);
        }
        string assetFile = string.Empty;
        string resPath = AppDataPath + "/" + AppConst.AssetDirName + "/";
        if (!Directory.Exists(resPath))
        {
            Directory.CreateDirectory(resPath);
        }
        BuildPipeline.BuildAssetBundles(resPath, BuildAssetBundleOptions.None, target);
        AssetDatabase.Refresh();
    }
    static string AppDataPath {
        get { return Application.dataPath.ToLower(); }
    }

    static void Recursive(string path)
    {
        string[] names = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);
        foreach (string filename in names)
        {
            string ext = Path.GetExtension(filename);
            if (ext.Equals(".meta"))continue;
            files.Add(filename.Replace("\\", "/"));
        }
        foreach (string dir in dirs)
        {
            paths.Add(dir.Replace("\\", "/"));
            Recursive(dir);
        }
    }
    static void UpdateProgress(int progress, int progressMax, string desc)
    {
        string title = "Processing..[" + progress + "-" + progressMax + "]";
        float value = (float)progress / (float)progressMax;
        EditorUtility.DisplayProgressBar(title, desc, value);
    }
}
