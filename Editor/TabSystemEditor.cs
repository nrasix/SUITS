using UnityEditor;
using UnityEngine;

namespace Nrasix.SimpleTabSystem.Editor
{
    [CustomEditor(typeof(TabSystem))]
    public class TabSystemEditor : UnityEditor.Editor
    {
        private SerializedProperty m_Script;
        private SerializedProperty _tabsProperty;
        private SerializedProperty _selectedTab;

        private TabSystem _tabSystem;

        private void OnEnable()
        {
            _tabsProperty = serializedObject.FindProperty("_tabs");
            m_Script = serializedObject.FindProperty("m_Script");
            _selectedTab = serializedObject.FindProperty("_selectedTab");

            _tabSystem = (TabSystem)target;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(m_Script, new GUILayoutOption[0]);
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.PropertyField(_tabsProperty, new GUIContent("Tabs"), true);

            if (Application.isPlaying)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                {
                    EditorGUILayout.BeginVertical(GUI.skin.box);
                    {
                        EditorGUILayout.LabelField("Editor Debug", EditorStyles.boldLabel);

                        EditorGUILayout.BeginHorizontal();
                        {
                            if (GUILayout.Button("Previous tab"))
                            {
                                _tabSystem.PreviousTab();
                            }
                            if (GUILayout.Button("Next tab"))
                            {
                                _tabSystem.NextTab();
                            }
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    EditorGUILayout.EndVertical();
                }
                EditorGUILayout.EndVertical();
            }
            else
            {
                if (GUILayout.Button("Find child Tabs"))
                {
                    FindTabsInChildren();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void FindTabsInChildren()
        {
            var gameObjects = _tabSystem.GetComponentsInChildren<Tab>(true);

            if (gameObjects.Length == 0)
                return;

            ClearTabList();

            _tabsProperty.arraySize = gameObjects.Length;

            for (int i = 0, len = gameObjects.Length; i < len; i++)
            {
                var tab = gameObjects[i];
                _tabsProperty.GetArrayElementAtIndex(i).objectReferenceValue = tab;
            }
        }

        private void ClearTabList()
        {
            _tabsProperty.ClearArray();
        }
    }
}