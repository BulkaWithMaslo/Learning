using UnityEngine;

namespace Logger
{
    public class NormalLoggerSecurity : MonoBehaviour, ILoggerSecurity
    {
        public bool IsSecure()
        {
            Debug.Log("Normal log security");
            return true;
        }
    }
}