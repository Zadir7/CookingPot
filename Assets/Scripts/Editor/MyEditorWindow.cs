using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MyEditorWindow : EditorWindow
    {
        private GameObject _gameObject;
        private void OnGUI()
        {
            GUILayout.Label("Дратуте, это мое кастомное окно Editor'а");
            _gameObject = EditorGUILayout.ObjectField(_gameObject, typeof(GameObject), true) as GameObject;
            GUILayout.TextArea("Прикольная штука, оказывается", 100);
        }
    }
}