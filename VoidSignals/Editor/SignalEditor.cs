using UnityEngine;

namespace VoidSignals
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEditorInternal;
    using UnityEngine;
    using System.Reflection;
    using System;

    /// <summary>
    /// Slick inspector for signals: shows listeners and a "Raise" button.
    /// Like odin but free 🤑 (and the quality way worse... hehe)
    /// </summary>
    [CustomEditor(typeof(SignalBase), true)]
    public class SignalEditor : Editor
    {
        private ReorderableList listenerList;

        private void OnEnable()
        {
            var field = typeof(SignalBase).GetField("_listeners", BindingFlags.NonPublic | BindingFlags.Instance);
            var lst = field.GetValue(target) as System.Collections.IList;
            listenerList = new ReorderableList(lst, typeof(Delegate), true, true, false, false);
            listenerList.drawHeaderCallback = r => EditorGUI.LabelField(r, "Listeners");
            listenerList.drawElementCallback = (r, i, a, f) => {
                var d = lst[i] as Delegate;
                EditorGUI.LabelField(r, d?.Method.DeclaringType.Name + ":" + d?.Method.Name);
            };
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GUILayout.Space(8);
            listenerList.DoLayoutList();
            GUILayout.Space(8);
            if (GUILayout.Button("Raise Signal (Editor)"))
            {
                var m = target.GetType().GetMethod("Raise");
                m.Invoke(target, m.GetParameters().Length == 0 ? null : new object[] { default });
            }
        }
    }
#endif

}
