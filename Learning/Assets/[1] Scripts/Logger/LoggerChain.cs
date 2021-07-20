using System.Linq;
using Extensions;
using UnityEngine;

namespace Logger
{
    public class LoggerChain : MonoBehaviour, ILogger
    {
        [SerializeField] private GameObject[] _goLoggers;
        
        private ILogger[] _loggers;

        public void Log(string message)
        {
            GrabLoggers();
            
            foreach (var logger in _loggers)
            {
                logger.Log(message);
            }
        }
        
        [EditorButton]
        private void GrabLoggers()
        {
            _loggers = _goLoggers.Select(go => go.GetComponent<ILogger>()).ToArray();
        }
    }
}