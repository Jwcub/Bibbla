# Bibbla - Bibliotekssystem för skola

Från och med juli 2025 är det ett lagkrav att alla skolor ska ha ett bemannat skolbibliotek. I detta projekt har ett enkelt bibliotekssystem för skolor skapats, där elever enkelt ska kunna söka böcker i bibliotekskatalogen samt kunna låna och reservera böcker. I systemet finns även en privat sida där användaren kan se sina lån och reservationer. För bibliotekarien finns en administratörssida som ger överblick över pågående lån och reservationer.

Detta system har byggts i C# och ASP.NET med ramverket Razor Pages. All data i systemet lagras i en SQLite-databas och vars kommunikation med systemet hanterats via Entity Framework Core. Under utvecklingen har stor vikt lagts vid säkerhet och användbarhet. Gränssnittet, som byggts med Tailwind CSS, har en medvetet avskalad design med enkel logik och stora klickytor. Inloggningar hanteras med ASP.NET Core Authenication och lösenord lagras som hashade-strängar.

## Projektet finns tillgängligt via:

https://bibbla-a4e4e0afe8c6embr.swedencentral-01.azurewebsites.net/

## Kom igång

1. Klona arkivet: git clone [[Bibbla](https://github.com/Jwcub/Bibbla)]
2. Navigera in i projektmappen: cd eLibrary
3. Starta applikationen: dotnet run (Seeds kommer då installeras till databasen med cirka 20 böcker och 3 testanvändare)

### Testanvändare

Admin:
karber1
Admin123

annand4
elev123

erilun1
elev456
