using UnityEngine;
using UnityEngine.Pool;

namespace Examples.ObjectPooling {
    public class Projectile : MonoBehaviour {
        private ObjectPool<GameObject> _ownerPooler;

        public void Init(ObjectPool<GameObject> objectPoolerExample) {
            _ownerPooler = objectPoolerExample;
            Invoke("OnFinished", 4.4f);    
        }

        public void OnFinished() {
            _ownerPooler.Release(gameObject);
        }
    }
}