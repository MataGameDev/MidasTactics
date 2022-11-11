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


        public bool IsPlayerUnit;
        
        public UnitType type;

        public string unitName;

        public GameObject HumanPrefab;
        public GameObject InfectedPrefab;

        public int Cost;

        public int Attack;

        public int Health;

        public int Armor;





    } 
}


