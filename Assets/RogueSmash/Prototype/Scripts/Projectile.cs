using System.Collections;
using MyCompany.GameFramework.Physics.Interfaces;
using MyCompany.GameFramework.ResourceSystem;
using UnityEngine;

namespace MyCompany.RogueSmash.Prototype
{
    public class Projectile : MonoBehaviour, ICollisionEnterHandler
    {
        private float lifetime;
        private Vector3 direction;
        private float velocity;
        private bool isAlive;

        public void Init(Vector3 direction, float velocity = 20.0f, float lifetime = 1.0f)
        {
            this.lifetime = lifetime;
            this.velocity = velocity;
            this.direction = direction;
        }

        private void Update()
        {
            if (isAlive)
            {
                transform.position += direction * Time.deltaTime * velocity;
            }
        }

        public void Shoot()
        {
            StartCoroutine(DeathTimer(lifetime));
            isAlive = true;
        }

        private IEnumerator DeathTimer(float timer)
        {
            yield return new WaitForSeconds(timer);
            Destroy(gameObject);
        }

        public void Handle(GameObject instigator, Collision collision)
        {
            IDamageable damageable = instigator.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(1);
            }
        }
    }
}

