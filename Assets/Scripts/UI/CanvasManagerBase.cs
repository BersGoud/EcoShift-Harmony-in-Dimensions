using Assets.Scripts.Interfaces;
using StarterAssets;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class CanvasManagerBase : MonoBehaviour, ICanvasManager
    {
        public ThirdPersonController Player;
        public StarterAssetsInputs PlayerInput;
        private Canvas canvas;
        public virtual void Hide(bool enableMovement = true)
        {
            canvas.enabled = false;
            if (enableMovement)
            { 
                Player.CameraMovementEnabled = true;
                PlayerInput.movementEnabled = true;
            }
        }

        public virtual void Show(bool disableMovement = true)
        {
            canvas.enabled = true;
            if (disableMovement)
            {
                Player.CameraMovementEnabled = false;
                PlayerInput.movementEnabled = false;
            }
        }
        protected virtual void Awake()
        {
            if (PlayerInput == null)
                PlayerInput = GameObject.FindAnyObjectByType<StarterAssetsInputs>();
            canvas = gameObject.GetComponent<Canvas>();
        }
        protected virtual void Start()
        {
            canvas = gameObject.GetComponent<Canvas>();
        }
    }
}