using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.InputManager;

namespace LP.FDG.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;

        public Transform enemyUnits;

        void Start()
        {
            instance = this;
            Units.UnitHandler.instance.SetBasicUnitStats(playerUnits);
            //Units.UnitHandler.instance.SetBasicUnitStats(enemyUnits);
        }

        void Update()
        {

            InputHandler.instance.HandleUnitMovement();

        }
    }   
}

