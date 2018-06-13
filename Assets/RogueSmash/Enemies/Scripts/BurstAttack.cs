using System;
using UnityEngine;
using MyCompany.GameFramework.EnemyAI.Interfaces;
using System.Collections;
using MyCompany.GameFramework.Coroutines;
using Object = UnityEngine.Object;

namespace MyCompany.RogueSmash.Enemies
{
    public class BurstAttack : IEnemyAbility
    {
        private readonly float burstIterations;
        private Transform emissionPoint;
        private GameObject bulletPrefab;

        private float duration;
        private int steps;

        private bool inUse;
        
        public event Action onBegin;
        public event Action onComplete;

        public BurstAttack(int burstCount, Transform emissionPoint, GameObject bulletPrefab, float duration = 2.0f,
            int steps = 36)
        {
            burstIterations = Mathf.PI * 2 * burstCount;
            this.emissionPoint = emissionPoint;
            this.bulletPrefab = bulletPrefab;
            this.duration = duration;
            this.steps = steps * burstCount;
        }

        public void UseAbility()
        {
            if (inUse)
            {
                return;
            }

            if (onBegin != null)
            {
                onBegin.Invoke();
            }
            inUse = true;
            CoroutineHelper.RunCoroutine(Burst);
        }

        private IEnumerator Burst()
        {
            float timer = burstIterations;
            float mult = timer / duration;
            float t = 0.0f;
            while (t < duration)
            {
                t += (duration / steps);
                Vector3 point = new Vector3(emissionPoint.position.x + Mathf.Sin(t * mult) * 2, 0.2f,
                    emissionPoint.position.z + Mathf.Cos(t * mult) * 2);
                Vector3 dir = point - emissionPoint.position;
                dir.Normalize();
                dir = emissionPoint.position + dir * 10;
                dir.y = 0.2f;
                GameObject ins = Object.Instantiate(bulletPrefab, point, Quaternion.identity);
                ins.transform.LookAt(dir);
                ins.GetComponent<Rigidbody>().velocity = ins.transform.forward * 7;
                yield return new WaitForSeconds(duration / steps);
            }

            inUse = false;
            if (onComplete != null)
            {
                onComplete.Invoke();
            }
        }
    }
}