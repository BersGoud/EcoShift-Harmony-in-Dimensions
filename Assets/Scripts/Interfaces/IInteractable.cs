using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IInteractable
    {
        /// <summary>
        /// Called when a player tries to interact with an object.
        /// </summary>
        public void Interact();
    }
}
