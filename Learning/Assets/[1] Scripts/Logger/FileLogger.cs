using UnityEngine;

namespace Logger
{
    public class FileLogger : MonoBehaviour, ILogger
    {
        public void Log(string message)
        {
            Debug.Log("File Log");
        }
    }
}