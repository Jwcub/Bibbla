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
                    Description = "En tidlös berättelse om bröderna Jonatan och Karl 'Skorpan' Lejonhjärta och deras kamp mot tyrannen Tengil i sagolandet Nangijala.",
                    Authors = new List<Author> { alindgren },
                    PublicationYear = 1973,
                    Genres = new List<Genre> { fantasy, adventure },
                    Age = "9-12",
                    CoverImage = "/images/covers/lejonhjarta.jpg",
                    Isbn = "9789129688313",
                    TotalCopies = 1,
                    AvailableCopies = 1,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-1),
                },
                new Book
                {
                    Title = "Diamantmysteriet",
                    Description = "Någon stjäl diamanter från Muhammed Karats guldsmedsaffär i Valleby, och detektivbyrån Lasse och Maja tar sig an fallet.",
                    Authors = new List<Author> { widmark },
                    PublicationYear = 2002,
                    Genres = new List<Genre> { detective, mystery },
                    Series = "LasseMajas Detektivbyrå",
                    SeriesOrder = 1,
                    Age = "9-12",
                    CoverImage = "/images/covers/diamantmysteriet.jpg",
                    Isbn = "9789163820755",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-16),
                },
                new Book
                {
                    Title = "Glasbarnen",
                    Description = "Billie flyttar till ett gammalt hus i Åhus där märkliga saker börjar hända, och tillsammans med Aladdin och Simona försöker hon avslöja husets mörka historia.",
                    Authors = new List<Author> { ohlsson },
                    PublicationYear = 2013,
                    Genres = new List<Genre> { suspense, mystery },
                    Series = "Glasbarnentrilogin",
                    SeriesOrder = 1,
                    Age = "9-12",
                    CoverImage = "/images/covers/glasbarnen.jpg",
                    Isbn = "9789187027321",
                    TotalCopies = 1,
                    AvailableCopies = 1,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-2),
                },
                new Book
                {
                    Title = "Handbok för superhjältar: Handboken",
                    Description = "Lisa blir mobbad i skolan och flyr in på biblioteket, där hon hittar en hemlig bok som lär ut hur man blir en riktig superhjälte.",
                    Authors = new List<Author> { vahlund },
                    PublicationYear = 2017,
                    Genres = new List<Genre> { adventure, graphicNovel },
                    Series = "Handbok för superhjältar",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/handboken.jpg",
                    Isbn = "9789129701388",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "B",
                    AddedDate = DateTime.UtcNow.AddDays(-3),
                },
                new Book
                {
                    Title = "Mördarens apa",
                    Description = "Gorillan Sally Jones ger sig ut på en världsomspännande och farofylld resa för att rentvå sin bästa vän Henry Koskela från anklagelser om mord.",
                    Authors = new List<Author> { wegelius },
                    PublicationYear = 2014,
                    Genres = new List<Genre> { adventure, historicalFiction },
                    Series = "Sally Jones",
                    SeriesOrder = 2,
                    Age = "9-12",
                    CoverImage = "/images/covers/mordarensapa.jpg",
                    Isbn = "9789163877384",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-3),
                },
                new Book
                {
                    Title = "Tsatsiki och Morsan",
                    Description = "Tsatsiki bor i Stockholm tillsammans med sin coola morsa som spelar bas i ett rockband, samtidigt som han drömmer om att en dag träffa sin pappa bläckfiskfiskaren i Grekland.",
                    Authors = new List<Author> { nilsson },
                    PublicationYear = 1995,
                    Genres = new List<Genre> { everydayLife, humour },
                    Series = "Tsatsiki",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/tsatsiki.jpg",
                    Isbn = "9789127057050",
                    TotalCopies = 1,
                    AvailableCopies = 1,
                    Shelf = "C",
                    AddedDate = DateTime.UtcNow.AddDays(-10),
                },
                new Book
                {
                    Title = "När Åkes mamma glömde bort",
                    Description = "En varm och underfundig bilderbok om en helt vanlig morgon när Åkes mamma plötsligt beter sig som en drake i stället för som en vuxen.",
                    Authors = new List<Author> { lindenbaum },
                    PublicationYear = 2005,
                    Genres = new List<Genre> { everydayLife, humour },
                    Age = "6-9",
                    CoverImage = "/images/covers/akesmamma.jpg",
                    Isbn = "9789129661019",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "B",
                    AddedDate = DateTime.UtcNow.AddDays(-6),
                },
                new Book
                {
                    Title = "Nidstången",
                    Description = "Bröderna Alrik och Viggo flyttar till en fosterfamilj i Mariefred och dras in i en farlig kamp när mörka krafter hotar det hemliga underjordiska biblioteket.",
                    Authors = new List<Author> { korsell, larsson },
                    PublicationYear = 2014,
                    Genres = new List<Genre> { urbanFantasy, horror },
                    Series = "PAX",
                    SeriesOrder = 1,
                    Age = "9-12",
                    CoverImage = "/images/covers/nidstangen.jpg",
                    Isbn = "9789163879135",
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-4),
                },
                new Book
                {
                    Title = "En mardröm i källaren",
                    Description = "Frank och spökhunden Buster stöter på ett läskigt mysterium djupt nere i husets mörka källare där något verkar gömma sig i skuggorna.",
                    Authors = new List<Author> { soderlund, gaines },
                    PublicationYear = 2021,
                    Genres = new List<Genre> { horror, mystery },
                    Series = "Spökhunden Buster",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/buster.jpg",
                    Isbn = "9789129730401",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "C",
                    AddedDate = DateTime.UtcNow.AddDays(-8),
                },
                new Book
                {
                    Title = "Mitt lyckliga liv",
                    Description = "Dunne ska börja ettan och är spänd och förväntansfull, och i skolan möter hon Ella som blir hennes allra bästa vän.",
                    Authors = new List<Author> { lagercrantz },
                    PublicationYear = 2010,
                    Genres = new List<Genre> { everydayLife, feelings },
                    Series = "Dunne",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/lyckligaliv.jpg",
                    Isbn = "9789163866302",
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-8),
                },
                new Book
                {
                    Title = "Loranga, Masarin och Dartanjang",
                    Description = "En absurd och humoristisk skildring av den färgstarke Loranga som vägrar jobba, hans son Masarin och farfar Dartanjang som ständigt drabbas av nya sjukdomar.",
                    Authors = new List<Author> { blindgren },
                    PublicationYear = 1969,
                    Genres = new List<Genre> { humour, nonsense },
                    Series = "Loranga",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/loranga.jpg",
                    Isbn = "9789129654486",
                    TotalCopies = 0,
                    AvailableCopies = 0,
                    Shelf = "B",
                    AddedDate = DateTime.UtcNow.AddDays(-9),
                },
                new Book
                {
                    Title = "Tordyveln flyger i skymningen",
                    Description = "Under sommarlovet i småländska Ringaryd börjar tre ungdomar vattna blommor på Selanderska gården och nystar upp en trehundraårig gåta fylld av mystik.",
                    Authors = new List<Author> { gripe },
                    PublicationYear = 1978,
                    Genres = new List<Genre> { mystery, superNatural },
                    Series = null,
                    SeriesOrder = null,
                    Age = "9-12",
                    CoverImage = "/images/covers/tordyveln.jpg",
                    Isbn = "9789148000486",
                    TotalCopies = 2,
                    AvailableCopies = 2,
                    Shelf = "C",
                    AddedDate = DateTime.UtcNow.AddDays(-2),
                },
                new Book
                {
                    Title = "Berts dagbok",
                    Description = "Berts egna ocensurerade och komiska anteckningar om kärlek, tjejer, pinsamma föräldrar och vardagen som högstadiekille i Öreskoga.",
                    Authors = new List<Author> { jakobsson, olsson },
                    PublicationYear = 1987,
                    Genres = new List<Genre> { humour },
                    Series = "Bert",
                    SeriesOrder = 1,
                    Age = "9-12",
                    CoverImage = "/images/covers/bert.jpg",
                    Isbn = "9789129628289",
                    TotalCopies = 5,
                    AvailableCopies = 5,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-8),
                },
                new Book
                {
                    Title = "Sune börjar skolan",
                    Description = "Sune börjar i första klass och måste hantera både en ny fröken, skolans alla regler och framför allt sin stora passion för tjejer.",
                    Authors = new List<Author> { olsson, jakobsson },
                    PublicationYear = 1999,
                    Genres = new List<Genre> { humour, everydayLife },
                    Series = "Sune",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/sune.jpg",
                    Isbn = "9789129646238",
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Shelf = "B",
                    AddedDate = DateTime.UtcNow.AddDays(-12),
                },
                new Book
                {
                    Title = "Alla älskar Sigge",
                    Description = "Elina älskar ponnyn Sigge mer än allt annat i stallet och kämpar för att få rida honom trots att alla andra också vill det.",
                    Authors = new List<Author> { hallberg },
                    PublicationYear = 2004,
                    Genres = new List<Genre> { animalFiction, everydayLife },
                    Series = "Sigge",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/sigge.jpg",
                    Isbn = "9789163827129",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "C",
                    AddedDate = DateTime.UtcNow.AddDays(-6),
                },
                new Book
                {
                    Title = "Svarta madam",
                    Description = "Ett rykte sprider sig på skolan om att man kan locka fram Svarta madam framför spegeln på toaletten, vilket leder till en kuslig utmaning.",
                    Authors = new List<Author> { genar },
                    PublicationYear = 2014,
                    Genres = new List<Genre> { mystery, ghostStory },
                    Series = "Mystiska skolan",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/svartamadam.jpg",
                    Isbn = "9789163876592",
                    TotalCopies = 3,
                    AvailableCopies = 3,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-5),
                },
                new Book
                {
                    Title = "Familjen Knyckertz och födelsedagskuppen",
                    Description = "I en familj där alla är mästertjuvar råkar sonen Ture vilja vara helt hederlig, vilket ställer till det när det vankas födelsedagskupp.",
                    Authors = new List<Author> { sparring },
                    PublicationYear = 2017,
                    Genres = new List<Genre> { humour, adventure },
                    Series = "Familjen Knyckertz",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "/images/covers/knyckertz.jpg",
                    Isbn = "9789127149267",
                    TotalCopies = 4,
                    AvailableCopies = 4,
                    Shelf = "C",
                    AddedDate = DateTime.UtcNow.AddDays(-7),
                },
                new Book
                {
                    Title = "Hedvig!",
                    Description = "Hedvig bor ute på landet där det inte finns några andra barn, men när hon äntligen börjar skolan startar ett händelserikt och dramatiskt år.",
                    Authors = new List<Author> { nilsson },
                    PublicationYear = 2005,
                    Genres = new List<Genre> { everydayLife, adventure },
                    Series = "Hedvig",
                    SeriesOrder = 1,
                    Age = "6-9",
                    CoverImage = "",
                    Isbn = "9789127104600",
                    TotalCopies = 0,
                    AvailableCopies = 0,
                    Shelf = "A",
                    AddedDate = DateTime.UtcNow.AddDays(-9),
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
                    Role = UserRole.admin,
                    Grade = null,
                    ClassLetter = null,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123")
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
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("elev123")
                },
                new User
                {
                    UserName = "erilun1",
                    FirstName = "Erik",
                    LastName = "Lundin",
                    Role = UserRole.pupil,
                    Grade = 8,
                    ClassLetter = "B",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("elev456")
                }
            };

            // Spara böcker och användare
            context.Books.AddRange(books);
            context.Users.AddRange(users);
            context.SaveChanges(); 

            // 2. Skapa testlån
            var loans = new List<Loan>
            {
                new Loan
                {
                    UserId = users[1].UserId, 
                    BookId = books[0].BookId,
                    LoanDate = DateTime.UtcNow.AddDays(-5),
                    DueDate = DateTime.UtcNow.AddDays(25),
                    ReturnedDate = null
                },
                new Loan
                {
                    UserId = users[2].UserId, 
                    BookId = books[1].BookId,
                    LoanDate = DateTime.UtcNow.AddDays(-40),
                    DueDate = DateTime.UtcNow.AddDays(-10),
                    ReturnedDate = null
                },
                new Loan
                {
                    UserId = users[1].UserId, 
                    BookId = books[2].BookId, 
                    LoanDate = DateTime.UtcNow.AddDays(-30),
                    DueDate = DateTime.UtcNow,
                    ReturnedDate = DateTime.UtcNow.AddDays(-2)
                }
            };
            context.Loans.AddRange(loans);

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    UserId = users[2].UserId,
                    BookId = books[10].BookId,
                    ResDate = DateTime.UtcNow.AddDays(-2)
                }
            };
            context.Reservations.AddRange(reservations); 

            // Spara lånen och reservationen till databasen
            context.SaveChanges();
        }
    }
}