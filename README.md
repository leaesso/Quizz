# Quizz
📘 Projet WPF – Quizz
1. Présentation du projet

Ce projet est une application de bureau développée en C# avec WPF (Windows Presentation Foundation), suivant l’architecture MVVM (Model – View – ViewModel).

L’application permet de :

réaliser des quiz,

enregistrer les résultats,

afficher l’historique des parties jouées.

Les données sont stockées localement à l’aide d’une base de données SQLite.

2. Environnement et prérequis
Système requis

Windows 10 ou Windows 11

Outils nécessaires

Visual Studio 2022 (ou Visual Studio 2019 à jour)

Charge de travail obligatoire :

✅ Développement .NET Desktop

Aucune autre configuration spécifique n’est requise.

3. Framework et versions utilisées

Le projet cible une version moderne de .NET :

.NET 6 (Windows)
(compatible également avec .NET 7 (Windows))

Le projet ne dépend pas de .NET Framework 4.x.

4. Gestion du projet avec le fichier .csproj

Le fichier Quizz.csproj est l’élément central du projet.
Il permet de :

définir la version du framework (.NET 6 / .NET 7),

activer WPF,

gérer automatiquement les dépendances NuGet.

Grâce à ce fichier, le projet peut être ouvert et compilé directement dans Visual Studio sans configuration manuelle supplémentaire.

Après la restauration des packages, certains fichiers devenus inutiles (comme le dossier Properties ou le fichier AssemblyInfo.cs) ont été supprimés afin d’éviter des conflits liés à la génération automatique des informations d’assembly dans les versions récentes de .NET.

5. Dépendances (NuGet)

Le projet utilise Entity Framework Core pour la gestion des données avec SQLite.

Les dépendances suivantes ont été installées via NuGet :

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.Sqlite

Microsoft.EntityFrameworkCore.Tools

Les versions utilisées sont compatibles avec :

.NET 6

.NET 7

Lors de l’ouverture du projet, Visual Studio restaure automatiquement ces dépendances.

6. Lancement du projet

Ouvrir le fichier Quizz.sln avec Visual Studio

Attendre la restauration automatique des packages NuGet

Menu Build → Rebuild Solution

Lancer l’application avec F5

La base de données SQLite est créée automatiquement au premier lancement si elle n’existe pas.

7. Gestion des fichiers et du dépôt GitHub

Les fichiers temporaires et générés automatiquement ne sont pas inclus dans le dépôt GitHub, notamment :

.vs

bin

obj

fichiers de base de données locaux

Un fichier .gitignore est utilisé pour garantir un dépôt propre et portable.

8. Note pour l’enseignant

Pour exécuter le projet :

Visual Studio avec la charge de travail Développement .NET Desktop suffit

Les dépendances sont restaurées automatiquement

Aucune installation manuelle supplémentaire n’est nécessaire

9. Conclusion

Ce projet utilise des technologies modernes (.NET 6 / 7, WPF, EF Core) garantissant :

une bonne portabilité,

une maintenance simplifiée,

une exécution fiable sur tout poste Windows configuré avec Visual Studio.
