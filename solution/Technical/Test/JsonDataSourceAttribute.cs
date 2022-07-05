using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Technical.Test
{
    /// <summary>
    /// Attribut de test pour tester les méthodes utilisant un fichier JSON en entrée.
    /// </summary>
    public class JsonDataSourceAttribute : Attribute, ITestDataSource
    {

        /// <summary>
        /// Nom du fichier JSON de test.
        /// </summary>
        private string _dataFileName;

        /// <summary>
        /// Constructeur permettant la récupération du fichier JSON de test.
        /// </summary>
        /// <param name="dataFileName"></param>
        public JsonDataSourceAttribute(string dataFileName)
        {
            _dataFileName = dataFileName;
        }

        /// <summary>
        /// Récupération des données présentes dans le fichier JSON paramétré au niveau de classe fille.
        /// </summary>
        IEnumerable<object[]> ITestDataSource.GetData(MethodInfo methodInfo)
        {
            // Ouverture du fichier json et récupération des données.
            FileStream openStream = File.OpenRead($@"{_dataFileName}");
            var jsonRoot = JsonSerializer.Deserialize<JsonTestRoot>(openStream);

            // Récupération uniquement des paramètres correspondant au test en cours et convertion en IEnumerable<object[]>.
            var result = jsonRoot.Tests.Where(w => w.TestName == methodInfo.Name).Select(s => new object[] { s }).ToList();
            if (!result.Any())
                throw new Exception($"Le fichier de données {_dataFileName} ne contient aucun enregistrement pour la méthode {methodInfo.Name}");

            return jsonRoot.Tests.Where(w => w.TestName == methodInfo.Name).Select(s => new object[] { s });
        }

        /// <summary>
        /// Test à afficher au niveau de l’explorateur de test.
        /// On affiche le nom de la méthode testée ainsi que les paramètres.
        /// </summary>
        string ITestDataSource.GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null && data[0] is JsonTestData testData && testData.Parameters.Any())
                return string.Format(CultureInfo.CurrentCulture, "{0} : {1}", methodInfo.Name, string.Join(", ", testData.Parameters.Select(s => new { param = $"{s.Name} = {s.Value}" }).Select(s => s.param).ToList()));
            else
                return string.Format(CultureInfo.CurrentCulture, "{0}", methodInfo.Name);
        }
    }
}
