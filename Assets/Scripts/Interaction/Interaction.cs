using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interaction
{
    public class Interaction : MonoBehaviour, IInteractable
    {
        public KeyCode keyCode = KeyCode.E;
        public string OnPressedText = null;
        public string InteractionText = "Press [KEY] to interact.";
        public virtual KeyCode GetInteractionKey()
        {
            return keyCode;
        }

        public virtual string GetInteractionText()
        {
            return InteractionText.Replace("[KEY]", keyCode.ToString());
        }

        public virtual string Interact()
        {
            return OnPressedText;
        }
    }
}
