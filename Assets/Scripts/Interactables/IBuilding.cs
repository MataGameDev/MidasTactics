using UnityEngine;

namespace LP.FDG.Interactables
{
    public class IBuilding : Interactable
    {

        public UI.HUD.PlayerActions actions;
        public GameObject spawnMarker = null;
        public GameObject spawnMarkerGraphics = null;
        public float maxMarkerDistance = 10f;

        public override void OnInteractEnter()
        {
            UI.HUD.ActionFrame.instance.SetActionButtons(actions, spawnMarker);
            spawnMarkerGraphics.SetActive(true);
            base.OnInteractEnter();
        }

        public override void OnInteractExit()
        {
            UI.HUD.ActionFrame.instance.ClearActions();
            spawnMarkerGraphics.SetActive(false);
            base.OnInteractExit();
        }

        public void SetSpawnMarkerLocation()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                spawnMarker.transform.position = hit.point;

            }
        }
    }
}