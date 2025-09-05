using Skin_Face_Expressions_Mod;
using Skin_LipSync_Mod;
using UCDC_Mod_Api.Models;
using UCDC_Mod_Api.Models.Skins;
using UnityEngine;
using UnityEditor;


namespace Editor
{
    [CustomEditor(typeof(LipSyncDataLocator))]
    public class LipSyncLocatorEditor : UnityEditor.Editor
    {
        
    string[] names;

    public override void OnInspectorGUI()
    {
        var selector = (LipSyncDataLocator)target;

        // Mesh picker
        selector.selectedMesh = (SkinnedMeshRenderer)EditorGUILayout.ObjectField(
            "Selected Mesh", selector.selectedMesh,
            typeof(SkinnedMeshRenderer), true);

        if (selector.selectedMesh != null && selector.selectedMesh.sharedMesh != null)
        {
            var mesh = selector.selectedMesh.sharedMesh;
            int count = mesh.blendShapeCount;

            if (count > 0)
            {
                // Prepare blendshape name list
                names = new string[count];
                for (int i = 0; i < count; i++)
                    names[i] = $"{i}: {mesh.GetBlendShapeName(i)}";

                DrawExpression("a", selector.aMorph);
                DrawExpression("i", selector.iMorph);
                DrawExpression("u", selector.uMorph);
                DrawExpression("e", selector.eMorph);
                DrawExpression("o", selector.oMorph);
                DrawExpression("n", selector.nMorph);
                DrawExpression("-", selector.noneMorph);
            }
            else
            {
                EditorGUILayout.HelpBox("Mesh has no blendshapes.", MessageType.Info);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Assign a SkinnedMeshRenderer.", MessageType.Info);
        }
        
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            );
        }
    }

    void DrawExpression(string label, BlendShapeMorph expression)
    {
        EditorGUILayout.LabelField(label, EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        expression.BlendShapeId = EditorGUILayout.Popup(expression.BlendShapeId, names);
        expression.MorphValue = EditorGUILayout.Slider(expression.MorphValue, 0f, 100f);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
    }
    }
}