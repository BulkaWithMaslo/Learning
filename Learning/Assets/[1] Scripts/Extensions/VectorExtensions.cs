using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static Vector3 RandomInsideBox(Vector3 bottomLeft, Vector3 topRight)
        {
            Vector3 result = new Vector3();
            result.x = Random.Range(bottomLeft.x, topRight.x);
            result.y = Random.Range(bottomLeft.y, topRight.y);
            result.z = Random.Range(bottomLeft.z, topRight.z);
            return result;
        }
    }
}
