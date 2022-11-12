using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.FDG.Units
{
    public class UnitHandler : MonoBehaviour
    {
        public static UnitHandler instance;

        [SerializeField]

        private BasicUnit worker,warrior,healer;

        private void Start()
        {
            instance = this;
        }

        public (int Cost,int Attack,int AtkRange, int Health, int Armor) GetBasicUnitStats(string type)
        {
            BasicUnit unit;
            switch(type)
            {
                case "worker":
                    unit = worker;
                    break;
                case "warrior":
                    unit = warrior;
                    break;
                case "healer":
                    unit = healer;
                    break;
                default:
                    Debug.Log($"Unit Type : {type} could not be found or does not exist!");
                    return (0,0,0,0,0);

            }
            return (unit.Cost,unit.Attack,unit.AtkRange,unit.Health,unit.Armor);
        }

        public void SetBasicUnitStats(Transform type)
        {
            foreach (Transform child in type)
            {
                foreach (Transform unit in child)
                {
                    string unitName = child.name.Substring(0,child.name.Length - 1).ToLower();
                    var stats = GetBasicUnitStats(unitName);
                    Player.PlayerUnit pU;
                    if(type == FDG.Player.PlayerManager.instance.playerUnits)
                    {

                        pU = unit.GetComponent<Player.PlayerUnit>();
                        pU.Cost = stats.Cost;
                        pU.Attack = stats.Attack;
                        pU.AtkRange = stats.AtkRange;
                        pU.Health = stats.Health;
                        pU.Armor = stats.Armor;

                    }
                    else if(type == FDG.Player.PlayerManager.instance.enemyUnits)
                    {
                        //Añadir las Stats del Enemigo
                    }
                    //asignar las stats a cada una de las unidades
                    

                    // si tenemos actualizaciones/mejoras aqui es donde podrian ir 
                    // añadir mejoras a las Stats de los personajes 

                }
            }
        }


    }
}
