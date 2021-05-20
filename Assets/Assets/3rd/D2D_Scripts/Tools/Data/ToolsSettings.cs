using D2D.Utilities;
using UnityEngine;

namespace D2D.Utils.Data
{
    [CreateAssetMenu(fileName = "ToolsSettings", menuName = "SO/ToolsSettings", order = 0)]
    public class ToolsSettings : SingletonData<ToolsSettings>
    {
        [Header("Hierarchy keeper")] 
        public bool isOn = true;
        public string separatorName = "--------------------"; 
        
        [Header("Palette")]
        public float contentToBorderProportion = 10;
        public float spaceSize;
        public bool isPopup;

        [Space(5)]

        public Color sceneCellsColors;
        public Color prefabCellsColor;
        public Color scriptableCellsColor;
        
        [Space(5)]

        public bool sceneCellsVisible = true;
        public bool projectCellsVisible = true;
        public bool scriptableCellsVisible = true;
        
        [Space(5)]
        
        public bool showScenesScriptable = true;
        public bool showGameScriptable = true;
        public bool showUIScriptable = true;
        public bool showToolsScriptable = false;
    }
}