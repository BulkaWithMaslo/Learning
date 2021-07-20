using UnityEngine;

namespace Logger
{
    public class FridayLoggerSecurity : MonoBehaviour, ILoggerSecurity
    {
        public bool IsSecure()
        {
            Debug.Log("Friday log security");
            return true;
        }
    }
}