using Skin_Face_Expressions_Mod;
using UCDC_Mod_Api.Models;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlendShapeSelector))]
public class BlendShapeSelectorEditor : Editor
{
    string[] names;

    public override void OnInspectorGUI()
    {
        var selector = (BlendShapeSelector)target;

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

                DrawExpression("Happy", selector.happy);
                DrawExpression("Sad", selector.sad);
                DrawExpression("Angry", selector.angry);
                DrawExpression("Surprised", selector.surprised);
                DrawExpression("Flirty", selector.flirty);
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

    void DrawExpression(string label, Expression expression)
    {
        EditorGUILayout.LabelField(label, EditorStyles.boldLabel);

        // Buttons for list management
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("+", GUILayout.Width(25)))
            expression.blendshapes.Add(new BlendShapeMorph());
        if (GUILayout.Button("-", GUILayout.Width(25)) && expression.blendshapes.Count > 0)
            expression.blendshapes.RemoveAt(expression.blendshapes.Count - 1);
        EditorGUILayout.EndHorizontal();

        // Show each blendshape entry
        for (int i = 0; i < expression.blendshapes.Count; i++)
        {
            var entry = expression.blendshapes[i];
            EditorGUILayout.BeginHorizontal();
            entry.BlendShapeId = EditorGUILayout.Popup(entry.BlendShapeId, names);
            entry.MorphValue = EditorGUILayout.Slider(entry.MorphValue, 0f, 100f);
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();
    }
}