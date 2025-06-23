using Nrasix.SimpleTabSystem.Utilities;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Nrasix.SimpleTabSystem.Editor
{
    [CanEditMultipleObjects, CustomEditor(typeof(ZeroGraphics))]
    public class ZeroGraphicsEditor : GraphicEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_Script, new GUILayoutOption[0]);
            RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}