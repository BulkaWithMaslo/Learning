using Extensions;
using UnityEngine;

namespace Logger
{
    public class SecureLogger : MonoBehaviour, ILogger
    {
        [SerializeField] private GameObject _goLogger;
        [SerializeField] private GameObject _goSecurity;

        private ILogger _logger;
        private ILoggerSecurity _loggerSecurity;

        public void Log(string message)
        {
            GrabLoggers();
            
            if (_loggerSecurity == null)
                Debug.Log("Logger has no security");
            else
                _loggerSecurity.IsSecure();
            _logger.Log(message);
        }

        [EditorButton]
        private void GrabLoggers()
        {
            _logger = _goLogger.GetComponent<ILogger>();
            _loggerSecurity = _goSecurity.GetComponent<ILoggerSecurity>();
        }
    }
}