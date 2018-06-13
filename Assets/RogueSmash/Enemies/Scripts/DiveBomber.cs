using UnityEngine;
using System.Collections;

namespace MyCompany.RogueSmash.Enemies
{
    public class DiveBomber : BasicEnemy
    {
        private float lockOnDistance = 7.0f;
        private bool isLockedOn;
        private float lockOnTime = 2.0f;

        private float dashSpeed = 30.0f;
        private float dashDuration = 0.4f;

        protected void Update()
        {
            if (!agent.hasPath && !isLockedOn)
            {
                movementBehavior.SetNextTargetPosition();
            }

            if (CheckForTarget())
            {
                if (!isLockedOn)
                {
                    LockOn();
                }
            }
        }

        private bool CheckForTarget()
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < lockOnDistance)
            {
                return true;
            }
            return false;
        }

        private void LockOn()
        {
            isLockedOn = true;
            agent.isStopped = true;
            transform.LookAt(player.transform.position);
            StartCoroutine(ChargeAttack());
        }

        private IEnumerator ChargeAttack()
        {
            float chargeMeter = 0.0f;
            while (chargeMeter < lockOnTime)
            {
                transform.LookAt(player.transform);
                chargeMeter += Time.deltaTime;
                yield return null;
            }

            StartCoroutine(Dash());
        }

        private IEnumerator Dash()
        {
            float dashTimer = 0.0f;
            while (dashTimer < dashDuration)
            {
                transform.position += transform.forward * dashSpeed * Time.deltaTime;
                dashTimer += Time.deltaTime;
                yield return null;
            }
            
            isLockedOn = false;
            agent.isStopped = false;
        }
    }
}
