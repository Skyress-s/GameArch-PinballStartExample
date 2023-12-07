using UnityEngine;

namespace Utility {
    public static class VectorExtensionMethods {
        public static Vector3 RemY(this Vector3 vec) {
            vec.y = 0;
            return vec;
        }
    }
}