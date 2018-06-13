using System.Collections;
using MyCompany.GameFramework.Coroutines;
using MyCompany.GameFramework.ResourceSystem;
using MyCompany.GameFramework.ResourceSystem.Interfaces;
using UnityEngine;

namespace MyCompany.RogueSmash.Weapons
{
	public class Pistol : IWeapon
	{
		private WeaponData weaponData;
		private IResource ammo;
		private bool isReloading = false;
		private float lastFire = 0;
		private Transform actorLocation;

		public IResource Ammo
		{
			get { return ammo; }
		}

		public Pistol(WeaponData weaponData, GameObject actor)
		{
			this.weaponData = weaponData;
			ammo = new Ammo(weaponData.MaxAmmo);
			actorLocation = actor.transform;
		}


		public bool Shoot()
		{
			if (lastFire + weaponData.MinFireInterval > Time.time)
			{
				//Debug.LogWarning("CLICK");
				return false;
			}
			
			if (isReloading)
			{
				//Debug.LogWarning("RELOADING");
				return false;
			}
			
			if (ammo.CurrentValue > 0)
			{
				ammo.Remove(1.0f);
				lastFire = Time.time;
				SpawnProjectile();
				//Debug.Log("PEW " + currentAmmo + "/" + weaponData.MaxAmmo);
				return true;
			} 
			if (ammo.CurrentValue <= 0 && weaponData.DoesAutoReload)
			{
				//Debug.LogWarning("RELOADING");
				Reload();
				return false;
			}
			else
			{
				//Debug.LogWarning("Out of ammo!");
				return false;
			}

		}

		private void SpawnProjectile()
		{
			GameObject instance = GameObject.Instantiate(weaponData.ProjectilePrefab, actorLocation.position, actorLocation.rotation);
			instance.name = "Projectile";
			Rigidbody rb = instance.GetComponent<Rigidbody>();
			rb.velocity = rb.transform.forward.normalized * weaponData.ProjectileSpeed;
			GameObject.Destroy(instance, 5.0f);
		}

		public void Reload()
		{
			isReloading = true;
			CoroutineHelper.RunCoroutine(ReloadTimer);
		}

		private IEnumerator ReloadTimer()
		{
			float timer = 0;
			while (timer <= weaponData.ReloadTime)
			{
				timer += Time.deltaTime;
				yield return null;
			}
			//Debug.LogError("RELOAD COMPLETE");
			ammo.Add(weaponData.MaxAmmo);
			isReloading = false;
		}
	}
}
