using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IInteractable
    {
        /// <summary>
        /// Called when a player tries to interact with an object.
        /// </summary>
        /// <returns>The string that needs displaying when a key was pressed. (OPTIONAL)</returns>
        public string Interact();
        /// <summary>
        /// Gets the interaction text that needs displaying. (OPTIONAL)
        /// </summary>
        /// <returns>The text that needs to be displayed.</returns>
        public string GetInteractionText();
        public KeyCode GetInteractionKey();
    }
}
