using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using LP.FDG.Buildings;

namespace LP.FDG.Units
{
    public class UnitStatDisplay : MonoBehaviour
    {
        public float maxHealth, armor, currentHealth;

        [SerializeField] private Image healthBarAmount;

        private bool isPlayerUnit = false;

        //public void SetStatDisplayBasicUnit(UnitStatTypes.Base stats, bool isPlayer)
        //{
            //maxHealth = stats.health;
            //armor = stats.armor;
            //isPlayerUnit = isPlayer;

            //currentHealth = maxHealth;


        //}

<<<<<<< HEAD
        public void SetStatDisplayBasicBuilding(BuildingStatTypes.Base stats , bool isPlayer)
        {
            maxHealth = stats.health;
            armor = stats.armor;
            isPlayerUnit = isPlayer;

            currentHealth = maxHealth;
        }
=======
        //public void SetStatDisplayBasicBuilding(Buildings.BuildingStatTypes)
>>>>>>> 49f670bb93198b8eeb916bfb0f9aeb0a7f55b40f

        private void Update()
        {
            HandleHealth();
        }

        public void TakeDamage(float damage)
        {
            float totalDamage = damage - armor;
            currentHealth -= totalDamage;
        }

        private void HandleHealth()
        {
            Camera camera = Camera.main;
            gameObject.transform.LookAt(gameObject.transform.position +
                camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

            healthBarAmount.fillAmount = currentHealth / maxHealth;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isPlayerUnit)
            {
                InputManager.InputHandler.instance.selectedUnits.Remove(gameObject.transform.parent);
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }

        
    }
}