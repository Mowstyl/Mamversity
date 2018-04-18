using UnityEditor;
using UnityEngine;

namespace BrainyBeard.Procedural.Building.Unity
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BuildingController))]
    public class BuildingControllerEditor : BuildingManagerEditor
    { protected override void PostGenerate(GameObject prefab) { } }
}