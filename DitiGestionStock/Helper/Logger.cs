using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DitiGestionStock.Model;

namespace DitiGestionStock.Helper
{
    public class Logger
    {
        BdDitiGestionStockContext db;
        /// <summary>
        /// Rédiger les erreurs au niveau de la base de donnée 
        /// Cette methode permet de logger les erreurs dans la table Td_erreur
        /// </summary>
        /// <param name="TitreErreur">Nom de la classe : nom de la methode</param>
        /// <param name="erreur">Les 2000 premiers caracteres</param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                db = new BdDitiGestionStockContext();
                Td_Erreur log = new Td_Erreur();
                log.DateErreur = DateTime.Now;
                log.DescriptionErreur = erreur.Length > 2000 ? erreur.Substring(0, 2000) : erreur;
                log.TitreErreur = TitreErreur;
                db.td_Erreurs.Add(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }
        }

        /// <summary>
        /// Cette methode permet de logger les erreurs dans le OS de la machine 
        /// </summary>
        /// <param name="erreur">Le message d'erreur</param>
        /// <param name="libelle">La classe : La methode</param>
        public static void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Gestion des stocks DITI 2025";
                eventLog.WriteEntry(string.Format("data:{0}, libelle: {1}, Description: {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }
    }
}
