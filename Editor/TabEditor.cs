using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Nrasix.SimpleTabSystem.Effect;

namespace Nrasix.SimpleTabSystem.Editor
{
    [CustomEditor(typeof(Tab))]
    public class TabEditor : UnityEditor.Editor
    {
        private List<Type> _effectTypes;
        private string[] _effectNames;

        private void OnEnable()
        {
            _effectTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    typeof(BaseTabEffect).IsAssignableFrom(t))
                .ToList();

            _effectNames = new string[_effectTypes.Count + 1];
            _effectNames[0] = "None";
            for (int i = 0; i < _effectTypes.Count; i++)
            {
                _effectNames[i + 1] = _effectTypes[i].Name;
            }
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            DrawPopUpForEffect();
        }

        private void DrawPopUpForEffect()
        {
            int newIndex = EditorGUILayout.Popup("Add effect", 0, _effectNames);

            if (newIndex > 0)
            {
                var effectType = _effectTypes[newIndex - 1];
                Undo.AddComponent(((Tab)target).gameObject, effectType);
            }
        }
    }
}