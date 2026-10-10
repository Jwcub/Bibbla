using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Models;


namespace eLibrary.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            // Om testdata redan finns, avbryt
            if(context.Books.Any()) return;

            // Skapa författare
            var alindgren = new Author { FirstName = "Astrid", LastName = "Lindgren", BirthYear = 1907 };
            var widmark = new Author { FirstName = "Martin", LastName = "Widmark", BirthYear = 1961 };
            var ohlsson = new Author { FirstName = "Kristina", LastName = "Ohlsson", BirthYear = 1979 };
            var vahlund = new Author { FirstName = "Elias", LastName = "Våhlund", BirthYear = 1973 };
            var wegelius = new Author { FirstName = "Jakob", LastName = "Wegelius", BirthYear = 1966 };
            var nilsson = new Author { FirstName = "Moni", LastName = "Nilsson", BirthYear = 1955 };
            var lindenbaum = new Author { FirstName = "Pija", LastName = "Lindenbaum", BirthYear = 1955 };
            var larsson = new Author { FirstName = "Åsa", LastName = "Larsson", BirthYear = 1966 };
            var korsell = new Author { FirstName = "Ingela", LastName = "Korsell", BirthYear = 1967 };
            var soderlund = new Author { FirstName = "Tobias", LastName = "Söderlund", BirthYear = 1989 };
            var gaines = new Author { FirstName = "Stef", LastName = "Gaines", BirthYear = 1985 };
            var lagercrantz = new Author { FirstName = "Rose", LastName = "Lagercrantz", BirthYear = 1947 };
            var blindgren = new Author { FirstName = "Barbro", LastName = "Lindgren", BirthYear = 1937 };
            var gripe = new Author { FirstName = "Maria", LastName = "Gripe", BirthYear = 1923 };
            var olsson = new Author { FirstName = "Sören", LastName = "Olsson", BirthYear = 1964 };
            var jakobsson = new Author { FirstName = "Anders", LastName = "Jacobsson", BirthYear = 1963 };
            var westman = new Author { FirstName = "Lars", LastName = "Westman", BirthYear = 1934 };
            var hallberg = new Author { FirstName = "Lin", LastName = "Hallberg", BirthYear = 1956 };
            var genar = new Author { FirstName = "Katarina", LastName = "Genar", BirthYear = 1973 };
            var sparring = new Author { FirstName = "Anders", LastName = "Sparring", BirthYear = 1907 };

            // Skapa genrer
            var fantasy = new Genre { Name = "Fantasy", Description = "Magi, mytiska väsen och främmande eller förtrollade världar" };
            var adventure = new Genre { Name = "Äventyr", Description = "Fartfyllda resor, faror och modiga uppdrag" };
            var detective = new Genre { Name = "Deckare", Description = "Ledtrådar, brottsutredningar och kluriga mysterier som ska lösas" };
            var suspense = new Genre { Name = "Spänning", Description = "Kusliga situationer, högt tempo och nagelbitande ovisshet" };
            var graphicNovel = new Genre { Name = "Serieroman", Description = "Berättelser förmedlade genom en kombination av bildsekvenser och text" };
            var historicalFiction = new Genre { Name = "Historisk fiktion", Description = "Dramatiska berättelser som utspelar sig i svunna tider och historiska miljöer" };
            var everydayLife = new Genre { Name = "Vardagsberättelse", Description = "Igenkänning från skola, kompisrelationer och familjeliv" };
            var humour = new Genre { Name = "Humor", Description = "Roliga situationer, dråpliga missförstånd och skrattfyllda äventyr" };
            var urbanFantasy = new Genre { Name = "Urban fantasy", Description = "Magiska och mytologiska krafter som döljer sig mitt i vår moderna vardag" };
            var horror = new Genre { Name = "Skräck", Description = "Mörka hot, skrämmande upplevelser och ren kalla kårar" };
            var mystery = new Genre { Name = "Mysterium", Description = "Gåtor, hemligheter och märkliga händelser som kräver ett svar" };
            var feelings = new Genre { Name = "Känslor", Description = "Starka upplevelser av empati, sorg, glädje och vänskap" };
            var nonsense = new Genre { Name = "Nonsens", Description = "Skruvad logik, lekfull galenskap och gränslös fantasi" };
            var superNatural = new Genre { Name = "Övernaturligt", Description = "Oförklarliga fenomen, krafter och händelser bortom naturens lagar" };
            var diaryFiction = new Genre { Name = "Dagboksroman", Description = "Personliga reflektioner och hemligheter skrivna i jag-form dag för dag" };
            var animalFiction = new Genre { Name = "Djurbok", Description = "Berättelser med djur i fokus och det särskilda bandet mellan människa och djur" };
            var ghostStory = new Genre { Name = "Spökhistoria", Description = "Vandringssägner, hemsökta platser och rastlösa andar" };
            var crimeFiction = new Genre { Name = "Kriminalroman", Description = "Brott, utredningar och farliga intriger i verklighetstrogna miljöer" };


            // Skapa böcker och koppla relationer i C#
            var books = new List<Book>
            {
                new Book
                {
                    Title = "Bröderna Lejonhjärta",
                    Authors = new List<Author> { alindgren},
                    PublicationYear = 1973,
                    Genres = new List<Genre> { fantasy, adventure },
                    Age = "9-12",
                    CoverImage = "wwwroot/images/covers/lejonhjarta.jpg",
                    Isbn = "9789129688313",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "Diamantmysteriet",
                    Authors = new List<Author> { widmark },
                    PublicationYear = 2002,
                    Genres = new List<Genre> { detective, mystery },
                    Series = "LasseMajas Detektivbyrå",
                    SeriesOrder = 1,
                    Age = "9-12",
                    CoverImage = "wwwroot/images/covers/diamantmysteriet.jpg",
                    Isbn = "9789163820755",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "Glasbarnen",
                    Authors = new List<Author> { ohlsson },
                    PublicationYear = 2013,
                    Genres = new List<Genre> { suspense, mystery },
                    Series = "Glasbarnentrilogin",
                    SeriesOrder = 1,
                    Age = "9-12",
                    CoverImage = "wwwroot/images/covers/glasbarnen.jpg",
                    Isbn = "9789187027321",
                    TotalCopies = 1,
                    AvailableCopies = 1,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "Handbok för superhjältar: Handboken",
                    Authors = new List<Author> { vahlund },
                    PublicationYear = 2017,
                    Genres = new List<Genre> { adventure, graphicNovel },
                    Series = "Handbok för superhjältar",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/glasbarnen.jpg",
                    Isbn = "9789129701388",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "B"
                },
                new Book
                {
                    Title = "Mördarens apa",
                    Authors = new List<Author> { wegelius },
                    PublicationYear = 2014,
                    Genres = new List<Genre> { adventure, historicalFiction },
                    Series = "Sally Jones",
                    SeriesOrder = 2,
                    Age = "9–12",
                    CoverImage = "wwwroot/images/covers/mordarensapa.jpg",
                    Isbn = "9789163877384",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "Tsatsiki och Morsan",
                    Authors = new List<Author> { nilsson },
                    PublicationYear = 1995,
                    Genres = new List<Genre> { everydayLife, humour },
                    Series = "Tsatsiki",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/tsatsiki.jpg",
                    Isbn = "9789127057050",
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Shelf = "C"
                },
                new Book
                {
                    Title = "När Åkes mamma glömde bort",
                    Authors = new List<Author> { lindenbaum },
                    PublicationYear = 2005,
                    Genres = new List<Genre> { everydayLife, humour },
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/akesmamma.jpg",
                    Isbn = "9789129661019",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "B"
                },
                new Book
                {
                    Title = "Nidstången",
                    Authors = new List<Author> { korsell, larsson },
                    PublicationYear = 2014,
                    Genres = new List<Genre> { urbanFantasy, horror },
                    Series = "PAX",
                    SeriesOrder = 1,
                    Age = "9–12",
                    CoverImage = "wwwroot/images/covers/nidstangen.jpg",
                    Isbn = "9789163879135",
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "En mardröm i källaren",
                    Authors = new List<Author> { soderlund, gaines },
                    PublicationYear = 2021,
                    Genres = new List<Genre> { horror, mystery },
                    Series = "Spökhunden Buster",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/buster.jpg",
                    Isbn = "9789129730401",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "C"
                },
                new Book
                {
                    Title = "Mitt lyckliga liv",
                    Authors = new List<Author> { lagercrantz },
                    PublicationYear = 2010,
                    Genres = new List<Genre> { everydayLife, feelings },
                    Series = "Dunne",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/lyckligaliv.jpg",
                    Isbn = "9789163866302",
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "Loranga, Masarin och Dartanjang",
                    Authors = new List<Author> { blindgren },
                    PublicationYear = 1969,
                    Genres = new List<Genre> { humour, nonsense },
                    Series = "Loranga",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/loranga.jpg",
                    Isbn = "9789129654486",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "B"
                },
                new Book
                {
                    Title = "Tordyveln flyger i skymningen",
                    Authors = new List<Author> { gripe },
                    PublicationYear = 1978,
                    Genres = new List<Genre> { mystery, superNatural },
                    Series = null,
                    SeriesOrder = null,
                    Age = "9–12",
                    CoverImage = "wwwroot/images/covers/tordyveln.jpg",
                    Isbn = "9789148000486",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "C"
                },
                new Book
                {
                    Title = "Berts dagbok",
                    Authors = new List<Author> { jakobsson, olsson },
                    PublicationYear = 1987,
                    Genres = new List<Genre> { humour },
                    Series = "Bert",
                    SeriesOrder = 1,
                    Age = "9–12",
                    CoverImage = "wwwroot/images/covers/bert.jpg",
                    Isbn = "9789129628289",
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "Sune börjar skolan",
                    Authors = new List<Author> { olsson, jakobsson },
                    PublicationYear = 1999,
                    Genres = new List<Genre> { humour, everydayLife },
                    Series = "Sune",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/sune.jpg",
                    Isbn = "9789129646238",
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Shelf = "B"
                },
                new Book
                {
                    Title = "Alla älskar Sigge",
                    Authors = new List<Author> { hallberg },
                    PublicationYear = 2004,
                    Genres = new List<Genre> { animalFiction, everydayLife },
                    Series = "Sigge",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/sigge.jpg",
                    Isbn = "9789163827129",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "C"
                },
                new Book
                {
                    Title = "Svarta madam",
                    Authors = new List<Author> { genar },
                    PublicationYear = 2014,
                    Genres = new List<Genre> { mystery, ghostStory },
                    Series = "Mystiska skolan",
                    SeriesOrder = 1,
                    Age = "6–9",
                    Isbn = "9789163876592",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "A"
                },
                new Book
                {
                    Title = "Familjen Knyckertz och födelsedagskuppen",
                    Authors = new List<Author> { sparring },
                    PublicationYear = 2017,
                    Genres = new List<Genre> { humour, adventure },
                    Series = "Familjen Knyckertz",
                    SeriesOrder = 1,
                    Age = "6–9",
                    CoverImage = "wwwroot/images/covers/knyckertz.jpg",
                    Isbn = "9789127149267",
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Shelf = "C"
                },
                new Book
                {
                    Title = "Hedvig!",
                    Authors = new List<Author> { nilsson },
                    PublicationYear = 2005,
                    Genres = new List<Genre> { everydayLife, adventure },
                    Series = "Hedvig",
                    SeriesOrder = 1,
                    Age = "6–9",
                    Isbn = "9789127104600",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "A"
                }
            };

            // Skapa testanvändare
            var users = new List<User>
            {
                // Administratör / Bibliotekarie
                new User
                {
                    UserName = "karber1",
                    FirstName = "Karin",
                    LastName = "Bergström",
                    Role = UserRole.admin, // eller UserRole.Admin beroende på hur din enum är döpt
                    Grade = null,
                    ClassLetter = null,
                    PasswordHash = "admin123"
                },

                // Lärare
                new User
                {
                    UserName = "joheks1",
                    FirstName = "Johan",
                    LastName = "Ekström",
                    Role = UserRole.teacher, // eller vad du har för lärarroll i enumen
                    Grade = null,
                    ClassLetter = null,
                    PasswordHash = "larare123"
                },

                // Elever
                new User
                {
                    UserName = "annand4",
                    FirstName = "Anna",
                    LastName = "Andersson",
                    Role = UserRole.pupil,
                    Grade = 7,
                    ClassLetter = "A",
                    PasswordHash = "elev123"
                },
                new User
                {
                    UserName = "erilun1",
                    FirstName = "Erik",
                    LastName = "Lundin",
                    Role = UserRole.pupil,
                    Grade = 8,
                    ClassLetter = "B",
                    PasswordHash = "elev123"
                },
                new User
                {
                    UserName = "sarnil1",
                    FirstName = "Sara",
                    LastName = "Nilsson",
                    Role = UserRole.pupil,
                    Grade = 9,
                    ClassLetter = "A",
                    PasswordHash = "elev123"
                },
                new User
                {
                    UserName = "omahas1",
                    FirstName = "Omar",
                    LastName = "Hassan",
                    Role = UserRole.pupil,
                    Grade = 9,
                    ClassLetter = "C",
                    PasswordHash = "elev123"
                }
            };

            // Spara data till databasen
            await context.Books.AddRangeAsync(books);
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

        }
    }
}