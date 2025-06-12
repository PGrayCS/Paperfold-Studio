#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildPipelineScript
{
    [MenuItem("Build/Build All Platforms")]
    public static void BuildAll()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.locationPathName = "Build/Windows/PaperfoldStudio.exe";
        options.target = BuildTarget.StandaloneWindows64;
        options.scenes = new[] { "Assets/Scenes/Main.unity" };
        BuildReport report = BuildPipeline.BuildPlayer(options);
        Debug.Log(report.summary.result);
    }

    [MenuItem("Build/Build WebGL")]
    public static void BuildWebGL()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.locationPathName = "Build/WebGL";
        options.target = BuildTarget.WebGL;
        options.scenes = new[] { "Assets/Scenes/Main.unity" };
        BuildReport report = BuildPipeline.BuildPlayer(options);
        Debug.Log(report.summary.result);
    }
}
#endif
