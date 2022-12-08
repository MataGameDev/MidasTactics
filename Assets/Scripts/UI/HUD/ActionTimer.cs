using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.FDG.UI.HUD
{
    public class ActionTimer : MonoBehaviour
    {
        public static ActionTimer instance = null;

        private void Awake()
        {
            instance = this;
        }

        public IEnumerator SpawnQueueTimer
        {
            get
            {
                if (ActionFrame.instance.spawnQueue.Count > 0)
                {
                    Debug.Log( $"Waiting for {ActionFrame.instance.spawnQueue[0]}");

                    yield return new WaitForSeconds(ActionFrame.instance.spawnQueue[0]);

                    ActionFrame.instance.SpawnObject();

                    

                    if (ActionFrame.instance.spawnQueue.Count > 0)
                    {
                        StartCoroutine(SpawnQueueTimer);
                    }
                }
            }
        }
    }
}