using System;
using UnityEngine;
using UnityEngine.Pool;

namespace Examples.ObjectPooling {
    public class ObjectPoolerExample : MonoBehaviour {
        public ObjectPool<GameObject> pool;

        [SerializeField] private GameObject _projectile;
        [SerializeField] private float _projectileSpeed;
        
        private void Awake() {
            pool = new ObjectPool<GameObject>(ActionOnCreate, ActionOnGet, ActionOnRelease, ActionOnDestroy);
            InvokeRepeating("Fire", 2f, 0.4f);
        }
        GameObject ActionOnCreate() {
            GameObject go = Instantiate(_projectile);
            go.AddComponent<Projectile>();
            return go;
        }

        private void ActionOnDestroy(GameObject obj) {
            Destroy(obj);
        }

        private void ActionOnRelease(GameObject obj) {
            obj.SetActive(false);
        }

        private void ActionOnGet(GameObject obj) {
            obj.SetActive(true);
        }

        private void Fire() {
            var go = pool.Get();
            
            go.transform.position = transform.position + transform.forward;
            go.transform.rotation = Quaternion.LookRotation(transform.forward);
            go.GetComponent<Projectile>().Init(pool);
            go.GetComponent<Rigidbody>().velocity = transform.forward * _projectileSpeed;
            
        }

    }
}