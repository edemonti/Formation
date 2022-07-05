using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Technical.Test
{
    /// <summary>
    /// Root du fichier de test.
    /// </summary>
    public class JsonTestRoot
    {
        [JsonPropertyName("tests")]
        public List<JsonTestData> Tests { get; set; }
    }

    /// <summary>
    /// Tests à effectuer.
    /// </summary>
    public class JsonTestData
    {
        /// <summary>
        /// Nom de la méthode de test.
        /// </summary>
        [JsonPropertyName("testName")]
        public string TestName { get; set; }

        /// <summary>
        /// Liste des paramètres.
        /// </summary>
        [JsonPropertyName("parameters")]
        public List<JsonTestParameter> Parameters { get; set; }

        /// <summary>
        /// Liste des asserts.
        /// </summary>
        [JsonPropertyName("asserts")]
        public List<JsonTestAssert> Asserts { get; set; }
    }

    /// <summary>
    /// Paramètre d’un ensemble.
    /// </summary>
    public class JsonTestParameter
    {
        /// <summary>
        /// Nom du paramètre.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Valeur du paramètre.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    /// <summary>
    /// Assert à tester.
    /// </summary>
    public class JsonTestAssert
    {
        /// <summary>
        /// Nom de l’assert.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Valeur à tester.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}