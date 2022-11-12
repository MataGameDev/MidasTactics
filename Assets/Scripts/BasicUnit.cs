using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LP.FDG.Units
{
    [CreateAssetMenu(fileName = "New Unit",menuName="New Unit/Basic")]
    public class BasicUnit : ScriptableObject
    {

        public enum UnitType
        {
            Worker,
            Warrior,
            Healer
        };

        [Space(10)]
        [Header("Unit Settings")]
        [Space(10)]

        public UnitType type;
        public string unitName;
        public GameObject HumanPrefab;
        public GameObject InfectedPrefab;

        [Space(10)]
        [Header("Unit Base Stats")]
        [Space(10)]
        public int Cost;
        public int Attack;
        public int AtkRange;
        public int Health;
        public int Armor;






    } 
}


