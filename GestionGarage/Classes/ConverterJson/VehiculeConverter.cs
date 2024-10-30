using GestionGarage.Classes.GarageGestion.Enum_Garage;
using GestionGarage.Classes.GarageGestion;
using GestionGarage.Classes.GarageGestion.VehiculesGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionGarage.Classes.ConverterJson
{
    internal class VehiculeConverter : JsonConverter<Vehicule>
    {
        public override Vehicule Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Lire l'objet JSON
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDoc.RootElement;

                // Identifier le type de véhicule
                if (root.TryGetProperty("TypeVehicule", out var typeVehicule))
                {
                    var typeVehiculeString = typeVehicule.GetString();
                    switch (typeVehiculeString)
                    {
                        case "Voiture":
                            //return JsonSerializer.Deserialize<Voiture>(root.GetRawText(), options);
                            return DeserializeVoiture(root, options);
                        case "Moto":
                            // Désérialisation manuelle pour Moto
                            return DeserializeMoto(root, options);
                            //return JsonSerializer.Deserialize<Moto>(root.GetRawText(), options);
                        case "Camion":
                            //return JsonSerializer.Deserialize<Camion>(root.GetRawText(), options);
                            return DeserializeCamion(root, options);
                        default:
                            throw new JsonException($"Type de véhicule non supporté : {typeVehiculeString}");
                    }
                }

                throw new JsonException("TypeVehicule manquant dans le JSON.");
            }
        }
        private Voiture DeserializeVoiture(JsonElement root, JsonSerializerOptions options)
        {
            var id = root.GetProperty("Id").GetInt32();
            var nom = root.GetProperty("Nom").GetString();
            var prixHT = root.GetProperty("PrixHT").GetInt32();
            var marque = (Marque)root.GetProperty("Marque").GetInt32();
            var moteur = JsonSerializer.Deserialize<Moteur>(root.GetProperty("Moteur").GetRawText(), options);
            var optionsList = JsonSerializer.Deserialize<List<Option>>(root.GetProperty("OptionsList").GetRawText(), options);
            var tailleCoffre = root.GetProperty("TailleCoffre").GetInt32();
            var cheveauxFiscaux = root.GetProperty("CheveauxFiscaux").GetInt32();
            var nbPorte = root.GetProperty("NbPorte").GetInt32();
            var nbSiege = root.GetProperty("NbSiege").GetInt32();

            return new Voiture(nom, prixHT, id, marque, moteur, optionsList, tailleCoffre, cheveauxFiscaux, nbPorte, nbSiege);
        }

        private Camion DeserializeCamion(JsonElement root, JsonSerializerOptions options)
        {
            var id = root.GetProperty("Id").GetInt32();
            var nom = root.GetProperty("Nom").GetString();
            var prixHT = root.GetProperty("PrixHT").GetInt32();
            var marque = (Marque)root.GetProperty("Marque").GetInt32();
            var moteur = JsonSerializer.Deserialize<Moteur>(root.GetProperty("Moteur").GetRawText(), options);
            var optionsList = JsonSerializer.Deserialize<List<Option>>(root.GetProperty("OptionsList").GetRawText(), options);
            var nbEssieu = root.GetProperty("NbEssieu").GetInt32();
            var poids = root.GetProperty("Poids").GetInt32();
            var volume = root.GetProperty("Volume").GetInt32();

            return new Camion(nbEssieu, poids, volume, nom, prixHT, marque, moteur, optionsList, id);
        }

        private Moto DeserializeMoto(JsonElement root, JsonSerializerOptions options)
        {
            var id = root.GetProperty("Id").GetInt32();
            var nom = root.GetProperty("Nom").GetString();
            var prixHT = root.GetProperty("PrixHT").GetInt32();
            var marque = (Marque)root.GetProperty("Marque").GetInt32();
            var moteur = JsonSerializer.Deserialize<Moteur>(root.GetProperty("Moteur").GetRawText(), options);
            var optionsList = JsonSerializer.Deserialize<List<Option>>(root.GetProperty("OptionsList").GetRawText(), options);
            var cylindres = root.GetProperty("Cylindres").GetInt32();

            return new Moto(id, nom, prixHT, optionsList, marque, moteur, cylindres);
        }

        public override void Write(Utf8JsonWriter writer, Vehicule value, JsonSerializerOptions options)
        {
            // Commencer à écrire l'objet JSON avec le type de véhicule
            writer.WriteStartObject();

            // Écrire le champ "TypeVehicule"
            writer.WriteString("TypeVehicule", value.GetType().Name);

            // Sérialiser les propriétés manuellement en incluant leurs noms
            writer.WriteNumber("Id", value.Id);
            writer.WriteString("Nom", value.Nom);
            writer.WriteNumber("PrixHT", value.PrixHT);
            writer.WriteStartArray("OptionsList");
            foreach (var option in value.OptionsList)
            {
                JsonSerializer.Serialize(writer, option, options);
            }
            writer.WriteEndArray();

            writer.WriteNumber("Marque", (int)value.Marque);
            writer.WritePropertyName("Moteur");
            JsonSerializer.Serialize(writer, value.Moteur, options);

            // Gestion des propriétés spécifiques à chaque sous-classe de véhicule
            switch (value)
            {
                case Voiture voiture:
                    writer.WriteNumber("CheveauxFiscaux", voiture.CheveauxFiscaux);
                    writer.WriteNumber("NbSiege", voiture.NbSiege);
                    writer.WriteNumber("NbPorte", voiture.NbPorte);
                    writer.WriteNumber("TailleCoffre", voiture.TailleCoffre);
                    break;
                case Moto moto:
                    writer.WriteNumber("Cylindres", moto.Cylindres);
                    break;
                case Camion camion:
                    writer.WriteNumber("NbEssieu", camion.NbEssieu);
                    writer.WriteNumber("Poids", camion.Poids);
                    writer.WriteNumber("Volume", camion.Volume);
                    break;
            }

            writer.WriteEndObject();
        }
    }
}
