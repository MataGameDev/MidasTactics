using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.FDG.InputManager
{
   public class InputHandler : MonoBehaviour
   {
        public static InputHandler instance;

        private RaycastHit hit;//what we hit with the raycast

        private List<Transform> selectedUnits = new List<Transform>();
        
        void Start()
        {

            instance = this;

        }


        public void HandleUnitMovement()
        {
            if(Input.GetMouseButtonDown(0))
            {
                //create a Ray
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //check if we hit something
                if(Physics.Raycast(ray,out hit))
                {
                    //if we do, then do something with that data
                    LayerMask layerHit = hit.transform.gameObject.layer;

                    switch(layerHit.value)
                    {
                        case 8: // Units Layer
                            // do something
                            SelectUnit(hit.transform);
                            break;
                        default: // if none of the above happens 
                            // do something
                            DeselectUnits();
                            break;
                    }
                }
                
            }

        }

        private void SelectUnit(Transform unit)
        {
            DeselectUnits();
            selectedUnits.Add(unit);
            //Lets set an obj on the unit called Highlight
            unit.Find("Highlight").gameObject.SetActive(true);
        }

        private void DeselectUnits()
        {
            for (int i = 0; i < selectedUnits.Count; i++)
            {
                selectedUnits[i].Find("Highlight").gameObject.SetActive(false);
            }
            selectedUnits.Clear();
        }

   }

}



