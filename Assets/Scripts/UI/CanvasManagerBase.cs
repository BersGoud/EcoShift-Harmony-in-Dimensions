using Assets.Scripts.Interfaces;
using StarterAssets;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CanvasManagerBase : MonoBehaviour, ICanvasManager
    {
        public ThirdPersonController Player;
        private Canvas canvas;
        public virtual void Hide(bool enableMovement = true)
        {
            canvas.enabled = false;
            if (enableMovement)
            { 
                Player.CameraMovementEnabled = true;
            }
        }

        public virtual void Show(bool disableMovement = true)
        {
            canvas.enabled = true;
            if (disableMovement)
            {
                Player.CameraMovementEnabled = false;
            }
        }
        protected virtual void Start()
        {
            canvas = gameObject.GetComponent<Canvas>();
        }
    }
}