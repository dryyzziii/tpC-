# Application de Gestion de Garage

**Version** : 1.0

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

## Instructions pour l'exécution
1. Cloner le projet Visual Studio.
2. Nettoyer la solution (`Menu Générer / Nettoyer la solution`) pour enlever les fichiers temporaires.
3. Supprimer le dossier `.vs` caché.
4. Exécuter le fichier `Program.cs` dans Visual Studio pour lancer l'application.
5. Interagir avec le menu pour gérer les véhicules et le garage.

## Sérialisation
La sérialisation des objets est effectuée en ajoutant l'attribut `[Serializable]` aux classes des véhicules. Les méthodes `Enregistrer` et `Charger` permettent de sauvegarder et de charger les données du garage.

## Exemples d'utilisation
### Ajouter un véhicule
1. Sélectionner l'option 2 du menu.
2. Entrer les informations demandées, y compris le nom, la marque, le type de moteur et le prix.
3. Le véhicule sera ajouté au garage et sauvegardé automatiquement.

### Afficher les véhicules
1. Sélectionner l'option 1 pour voir tous les véhicules du garage.
2. L'application affichera les informations détaillées de chaque véhicule, y compris le prix total (prix HT + taxe).

## Installation et livraison
Pour rendre l'application, veuillez :
1. Créer un fichier compressé (zip, 7z, rar) contenant l’ensemble des fichiers de la solution et du projet.
2. Nommer le fichier au format `nom.prenom.zip`.
3. Déposer le fichier dans le dossier de rendu **MonCampus** ou l'envoyer à l'adresse suivante : nicolas.chevalier4@intervenant.igensia.com.

**Note** : N'oubliez pas de nettoyer la solution et de supprimer le dossier `.vs` avant de créer le fichier compressé.

---

