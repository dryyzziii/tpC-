# Application de Gestion de Garage

**Version** : 2.0

## Description du projet
Ce projet est une application de gestion de garage développée dans le cadre du cours de programmation orientée objet en C#. L'objectif est de mettre en œuvre des concepts avancés de POO, tels que les classes abstraites, les interfaces, les exceptions personnalisées et la sérialisation. Cette application permet de gérer des véhicules de différents types (voitures, camions et motos) ainsi que leurs caractéristiques propres et options associées.

## Fonctionnalités principales

1. **Gestion des véhicules**  
   - **Types de véhicules** : Voiture, camion, moto.
   - **Attributs spécifiques** :  
     - *Voiture* : nombre de portes, nombre de sièges, taille du coffre, puissance fiscale.
     - *Camion* : nombre d'essieux, poids de chargement, volume de chargement.
     - *Moto* : cylindrée.
   - **Fonctionnalités** :  
     - Ajout de véhicules au garage.
     - Suppression de véhicules du garage.
     - Affichage des informations détaillées d’un véhicule.
     - Tri des véhicules par prix total (prix HT + taxe).

2. **Gestion des options et moteurs**  
   - **Options** : Chaque véhicule peut avoir des options telles que la climatisation, le GPS, etc.
   - **Moteurs** : Types de moteurs disponibles (diesel, essence, hybride, électrique) avec puissance.
   - **Fonctionnalités** :  
     - Ajout d'options et de moteurs au garage.
     - Affichage des options et moteurs existants dans le garage.

3. **Calcul de taxe spécifique par type de véhicule**
   - *Voiture* : taxe calculée en fonction de la puissance fiscale (10€ par cheval fiscal).
   - *Camion* : taxe basée sur le nombre d'essieux (50€ par essieu).
   - *Moto* : taxe calculée sur la cylindrée (0,3€ par unité de cylindrée, arrondi à l'entier inférieur).

4. **Menu interactif**  
   Un menu textuel permet à l’utilisateur d’accéder aux différentes fonctionnalités de manière intuitive. Les options incluent :
   - Afficher, ajouter, supprimer un véhicule.
   - Gérer les options d'un véhicule.
   - Afficher les marques et types de moteurs disponibles.
   - Charger et sauvegarder le garage dans un fichier JSON.

5. **Sérialisation et gestion des fichiers JSON**
   - Sauvegarde de l’état du garage dans un fichier JSON pour permettre une persistance des données.
   - Chargement des données d’un fichier JSON pour restaurer l’état du garage.

## Structure du projet
Le projet est organisé en plusieurs dossiers pour une meilleure gestion du code :
- `ConverterJson` : Contient les classes pour la conversion JSON des véhicules.
- `Exceptions` : Contient les classes d'exceptions personnalisées, notamment pour la gestion des erreurs de menu.
- `GarageGestion` : Contient les classes principales pour la gestion du garage, des véhicules, des options, et des moteurs.
- `MenuGestion` : Contient les classes liées à l'affichage du menu interactif et à la gestion des interactions avec l'utilisateur.
- `JSON` : Dossier de stockage pour les fichiers de sauvegarde JSON du garage.

## Exécution des tests

### Packages nécessaires
Pour exécuter les tests avec **xUnit** dans Visual Studio, assurez-vous d'avoir installé les packages suivants :

- **Microsoft.NET.Test.Sdk (17.11.1)**
- **xunit (2.9.2)**
- **xunit.runner.visualstudio (2.8.2)**

Ces packages sont nécessaires pour la détection et l'exécution des tests dans Visual Studio. Vous pouvez les installer via le gestionnaire de packages NuGet.

### Étapes pour exécuter les tests dans Visual Studio
1. Ouvrez le projet dans Visual Studio.
2. Allez dans **Test** > **Fenêtre de l'explorateur de tests** pour afficher la fenêtre de tests.
3. Cliquez sur **Exécuter tout** dans la fenêtre de l'explorateur de tests pour exécuter tous les tests de l'application.
4. Les résultats de chaque test seront affichés dans cette fenêtre.

---