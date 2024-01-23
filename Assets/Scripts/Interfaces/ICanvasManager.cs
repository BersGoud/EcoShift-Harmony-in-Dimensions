using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface ICanvasManager
    {
        /// <summary>
        /// Hides the canvas.
        /// </summary>
        /// <param name="disableMovement">Disable player movement and unlock cursor.</param>
        public void Show(bool disableMovement = true);
        /// <summary>
        /// Shows the canvas.
        /// </summary>
        /// <param name="enableMovement">Enables player movement and locks the cursor.</param>
        public void Hide(bool enableMovement = true);
    }
}
