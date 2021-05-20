using D2D.Tools;
using D2D.Utilities;
using UnityEditor;
using UnityEngine;

namespace D2D.Tools
{
    public class AssetsPaletteWindow : EditorWindow
    {
        private Editor _editor;
        private AssetsPalette _attachedPalette;

        private static AssetsPaletteWindow _currentWindow;

        [MenuItem("D2D/Open Palette &e")]
        private static void Init()
        {
            if (_currentWindow != null)
            {
                _currentWindow.Close();
                _currentWindow = null;
            }
            else
            {
                _currentWindow = ScriptableObject.CreateInstance<AssetsPaletteWindow>();
                _currentWindow.position = new Rect(1200, 25, 300, 835);
                _currentWindow.ShowPopup();
            }
        }

        [MenuItem("D2D/Close Palette &d")]
        private static void CloseAll() 
        {
            GetWindow(typeof(AssetsPaletteWindow))?.Close();
        }

        private void OnEnable()
        {
            _attachedPalette = AssetsPalette.Instance;
            _editor = Editor.CreateEditor(_attachedPalette);
        }
 
        private void OnGUI()
        {
            // GUILayout.Space(100);

            _editor.OnInspectorGUI();

            GUILayout.Space(20);
            
            GUILayout.BeginHorizontal("box");

            if (GUILayout.Button("Player"))
            {
                FastSelector.SelectPlayer();
            }
            
            if (GUILayout.Button("Level"))
            {
                FastSelector.SelectLevel();
            }
            
            if (GUILayout.Button("Canvas"))
            {
                FastSelector.SelectCanvas();
            }
            
            HierarchyKeeper.Keep();
            
            GUILayout.EndHorizontal();
            
            // EditorGUILayout.LabelField("");
        }
    }
}