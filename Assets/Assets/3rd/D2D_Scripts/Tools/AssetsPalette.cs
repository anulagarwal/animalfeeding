using D2D.Utilities;
using UnityEngine;

namespace D2D.Tools
{
    [CreateAssetMenu(fileName = "ObjectFavourites", menuName = "SO/ObjectFavourites", order = 0)]
    public class AssetsPalette : SingletonData<AssetsPalette>
    {
        [SerializeField] private ScriptableObject _settings;
        [SerializeField] private Object _level;
        
        [Space(10)]
        
        [SerializeField] private Object[] _favourites;
    }
}