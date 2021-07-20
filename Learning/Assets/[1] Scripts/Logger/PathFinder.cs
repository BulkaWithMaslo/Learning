using Extensions;
using UnityEngine;

namespace Logger
{
    public class PathFinder : MonoBehaviour
    {
        [SerializeField] private GameObject _logger;

        [EditorButton]
        private void LogSomething()
        {
            _logger.GetComponent<ILogger>().Log("Something");
        }
    }
}