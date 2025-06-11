using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Nrasix.SimpleTabSystem.Editor
{
    [CustomEditor(typeof(TabSystem))]
    public class TabSystemEditor : UnityEditor.Editor
    {
        private VisualElement _root;

        private SerializedProperty _tabsProperty;

        private TabSystem _tabSystem;

        private void OnEnable()
        {
            _tabsProperty = serializedObject.FindProperty("_tabs");

            _root = new VisualElement();
            _tabSystem = (TabSystem)target;
        }

        public override VisualElement CreateInspectorGUI()
        {
            var tabsField = new PropertyField(_tabsProperty, "TABS") {style = { paddingTop = 5, paddingBottom = 5 } };
            _root.Add(tabsField);

            var findButton = new Button(() =>
            {
                Undo.RecordObject(_tabSystem, "Find Tabs in Children");
                FindTabsInChildren();
                EditorUtility.SetDirty(_tabSystem);
                serializedObject.ApplyModifiedProperties();
            })
            {
                text = "Find Tabs in Children",
                style =
                    {
                        height = 30
                    }
            };

            _root.Add(findButton);

            return _root;
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