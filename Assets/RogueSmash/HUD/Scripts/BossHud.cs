using MyCompany.GameFramework.ResourceSystem.Interfaces;
using MyCompany.RogueSmash.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace MyCompany.RogueSmash.HUD
{
    public class BossHud : MonoBehaviour
    {
        private IResource health;
        [SerializeField] private Slider healthBar;
        [SerializeField] private Text nameTag;

        private void Start()
        {
            GameObject boss = GameObject.FindWithTag("Boss");

            BigBoss bossScript = boss.GetComponent<BigBoss>();

            health = bossScript.Health;
            health.onValueChanged += OnValueChanged;
            healthBar.maxValue = health.CurrentValue;
            healthBar.value = healthBar.maxValue;

            nameTag.text = "Big Boss Name Goes Here!";
        }

        private void OnValueChanged(float newValue)
        {
            healthBar.value = newValue;
        }
    }
}
