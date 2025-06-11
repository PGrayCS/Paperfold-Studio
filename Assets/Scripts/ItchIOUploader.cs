#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Diagnostics;

public class ItchIOUploader : MonoBehaviour
{
    [MenuItem("Build/Upload to itch.io")]
    public static void UploadBuild()
    {
        var path = "Build"; // adjust build path
        var user = "youruser/paperfoldstudio:windows";
        Process.Start("butler", $"push {path} {user}");
    }
}
#endif
