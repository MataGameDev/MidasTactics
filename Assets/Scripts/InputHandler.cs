using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP.FDG.Units.Player;

namespace LP.FDG.InputManager
{
   public class InputHandler : MonoBehaviour
   {
        public static InputHandler instance;

        private RaycastHit hit;//what we hit with the raycast

        private List<Transform> selectedUnits = new List<Transform>();

        private bool isDragging = false;

        private Vector3 mousePos; 


        
        void Start()
        {

            instance = this;

        }

        private void OnGUI()
        {
            if(isDragging)
            {

                Rect rect = MultiSelect.GetScreenRect(mousePos,Input.mousePosition);
                MultiSelect.DrawScreenRect(rect,new Color (0f,0f,0f,0.25f));
                MultiSelect.DrawScreenRectBorder(rect,3,Color.blue);

            }
        }


        public void HandleUnitMovement()
        {
            if(Input.GetMouseButtonDown(0))
            {
            
                mousePos = Input.mousePosition;

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
                            SelectUnit(hit.transform, Input.GetKey(KeyCode.LeftShift));
                            break;
                        default: // if none of the above happens 
                            // do something
                            isDragging = true;
                            DeselectUnits();
                            break;
                    }
                }
                
            }
            if(Input.GetMouseButtonUp(0))
            {
                foreach (Transform child in Player.PlayerManager.instance.playerUnits)
                {
                    foreach(Transform unit in child)
                    {
                        if(isWithinSelectionBounds(unit))
                        {
                            SelectUnit(unit,true);
                        }   
                    }
                }
                isDragging = false;
            }

            if(Input.GetMouseButtonDown(1) && HaveSelectedUnits())
            {
                mousePos = Input.mousePosition;

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
                            break;
                        case 9: // Enemy Units Layer

                            break;
                        default: // if none of the above happens 
                            // do something
                            foreach(Transform unit in selectedUnits)
                            {
                                PlayerUnit pU = unit.gameObject.GetComponent<PlayerUnit>();
                                pU.MoveUnit(hit.point);
                            }
                            break;
                    }
                }
            }


        }

        private void SelectUnit(Transform unit, bool canMultiselect = false)
        {
            if(!canMultiselect)
            {
                DeselectUnits();
            }
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

        private bool isWithinSelectionBounds(Transform tf)
        {
            if(!isDragging)
            {
                return false;
            }

            Camera cam = Camera.main;
            
            Bounds vpBounds = MultiSelect.GetVPBounds(cam,mousePos,Input.mousePosition);
            
            return vpBounds.Contains(cam.WorldToViewportPoint(tf.position));

        }

        private bool HaveSelectedUnits()
        {
            if(selectedUnits.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

   }

}



