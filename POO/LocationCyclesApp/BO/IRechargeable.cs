using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationCycles.BO
{
    /// <summary>
    /// Définit le service de Rechargement des batteries
    /// </summary>
    public interface IRechargeable
    {

		/// <summary>
		/// charger la batterie jusqu'au niveau indiqué
		/// </summary>
		void Charger(int nouveauNiveau);

        /// <summary>
        /// gérer le niveau de batterie
        /// </summary>
        int NiveauBatterie { get; }

	}
}
