using System;
using UnityEngine;

namespace Shop_Thingy
{
    [CreateAssetMenu(menuName = "Create Good", fileName = "Good", order = 0)]
    public class Good : ScriptableObject
    {
        public string Name;
        public int Cost;

        public bool Compare(Good good)
        {
            return String.CompareOrdinal(Name, good.Name) == 0 && Cost == good.Cost;
        }
    }
}
