using UnityEditor;

namespace Editor
{
    public class MenuItems
    {
        [MenuItem("Customs/Custom Window #1")]
        private static void CallCustomEditorWindow()
        {
            EditorWindow.GetWindow(typeof(MyEditorWindow), true, "Hello Editor", true);
        }
    }
}