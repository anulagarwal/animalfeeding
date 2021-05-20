using D2D.Utilities;
using D2D.Utils;
using UnityEngine;

namespace D2D.Databases
{
    public class PlayerDatabase : MonoBehaviour, ILazy
    {
        public DataContainer<float> MoneyContainer { get; } = new DataContainer<float>(0);
    }
}

