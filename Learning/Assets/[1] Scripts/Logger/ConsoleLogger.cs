using UnityEngine;

namespace Logger
{
    public class ConsoleLogger : MonoBehaviour, ILogger
    {
        public void Log(string message)
        {
            Debug.Log("Console Log");
        }
    }
}