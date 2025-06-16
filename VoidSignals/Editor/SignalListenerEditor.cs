using UnityEngine;

namespace VoidSignals
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(SignalListener))]
    public class SignalListenerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.HelpBox("Hook up your signal and UnityEvent. Auto-unsubscribes on disable.", MessageType.Info);
        }
    }
#endif
}
