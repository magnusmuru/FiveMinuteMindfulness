using System.Security.Claims;
using FiveMinuteMindfulness.Core.Enums;
using FiveMinuteMindfulness.Core.Models;
using FiveMinuteMindfulness.Core.Models.Application;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FiveMinuteMindfulness;

public class DataHelper
{
    private static readonly Guid DataSeedUser = Guid.Parse("bf3a5bc2-0e6e-4e77-a477-5445ad46c990");

    public static void SetupAppData(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        using var context = serviceScope
            .ServiceProvider.GetService<FiveMinutesContext>();

        if (context == null)
        {
            throw new ApplicationException("Problem in services. No db context.");
        }

        if (configuration.GetValue<bool>("DataInitialization:DropDatabase"))
        {
            context.Database.EnsureDeleted();
        }

        if (configuration.GetValue<bool>("DataInitialization:MigrateDatabase"))
        {
            context.Database.Migrate();
        }

        if (configuration.GetValue<bool>("DataInitialization:SeedIdentity"))
        {
            using var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
            using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();

            if (userManager == null || roleManager == null)
            {
                throw new NullReferenceException("UserManager or RoleManager cannot be null!");
            }

            var roles = new (string name, string displayName)[]
            {
                ("admin", "System administrator"),
                ("user", "Normal system user")
            };

            foreach (var roleInfo in roles)
            {
                var role = roleManager.FindByNameAsync(roleInfo.name).Result;
                if (role == null)
                {
                    var identityResult = roleManager.CreateAsync(new Role
                    {
                        Name = roleInfo.name,
                        DisplayName = roleInfo.displayName
                    }).Result;
                    if (!identityResult.Succeeded)
                    {
                        throw new ApplicationException("Role creation failed");
                    }
                }
            }

            var users = new (string username, string firstName, string lastName, string password, string roles)[]
            {
                ("test@test.com", "Admin", "Test", "Testing123!", "user,admin"),
                ("user@test.com", "User", "Test", "Testing123!", "user"),
                ("newuser@test.com", "User No Roles", "Test", "Testing123!", "")
            };

            foreach (var userInfo in users)
            {
                var user = userManager.FindByEmailAsync(userInfo.username).Result;
                if (user == null)
                {
                    user = new User
                    {
                        Email = userInfo.username,
                        FirstName = userInfo.firstName,
                        LastName = userInfo.lastName,
                        UserName = userInfo.username,
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };
                    var identityResult = userManager.CreateAsync(user, userInfo.password).Result;
                    identityResult = userManager.AddClaimAsync(user, new Claim("aspnet.firstname", user.FirstName))
                        .Result;
                    identityResult = userManager.AddClaimAsync(user, new Claim("aspnet.lastname", user.LastName))
                        .Result;

                    if (!identityResult.Succeeded)
                    {
                        throw new ApplicationException("Cannot create user!");
                    }
                }

                if (!string.IsNullOrWhiteSpace(userInfo.roles))
                {
                    var identityResultRole = userManager.AddToRolesAsync(user,
                        userInfo.roles.Split(",").Select(r => r.Trim())
                    ).Result;
                }
            }
        }

        if (configuration.GetValue<bool>("DataInitialization:SeedData"))
        {
            var introductionGuid = Guid.NewGuid();
            var mapGuid = Guid.NewGuid();
            var habitGuid = Guid.NewGuid();
            var audioGuid = Guid.NewGuid();
            var videoGuid = Guid.NewGuid();

            var sections = new List<Section>
            {
                new()
                {
                    Id = introductionGuid,
                    ChapterType = ChapterType.Text,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Introduction",
                        ["et-EE"] = "Sissejuhatus"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Introduction",
                        ["et-EE"] = "Sissejuhatus"
                    },
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    Id = mapGuid,
                    ChapterType = ChapterType.Text,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Building a map",
                        ["et-EE"] = "Sinu kaardi ehitamine"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Building a map",
                        ["et-EE"] = "Sinu kaardi ehitamine"
                    },
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    Id = habitGuid,
                    ChapterType = ChapterType.Text,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Building habits",
                        ["et-EE"] = "Harjumuste tekitamine"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Building habits",
                        ["et-EE"] = "Harjumuste tekitamine"
                    },
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    Id = audioGuid,
                    ChapterType = ChapterType.Audio,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Audio",
                        ["et-EE"] = "Heli"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Audio",
                        ["et-EE"] = "Heli"
                    },
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    Id = videoGuid,
                    ChapterType = ChapterType.Video,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Video",
                        ["et-EE"] = "Video"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Video",
                        ["et-EE"] = "Video"
                    },
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                }
            };

            context.Sections.AddRange(sections);
            context.SaveChanges();

            var crashId = Guid.NewGuid();
            var complexityId = Guid.NewGuid();
            var meditationId = Guid.NewGuid();
            var rainId = Guid.NewGuid();
            var leavesId = Guid.NewGuid();
            var flyId = Guid.NewGuid();

            var assignments = new List<Assignment>
            {
                new()
                {
                    Id = crashId,
                    SectionId = introductionGuid,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Crash Course",
                        ["et-EE"] = "Kiirkursus"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Intro to mindfulness",
                        ["et-EE"] = "Sissejuhatus mindfulnessi"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    Id = complexityId,
                    SectionId = mapGuid,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Simple complexity",
                        ["et-EE"] = "Lihtne keerukus"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Living fast and slow",
                        ["et-EE"] = "Elades kiiresti ja aeglaselt"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    Id = meditationId,
                    SectionId = habitGuid,
                    Title = new LanguageString
                    {
                        ["en-US"] = "What is meditation?",
                        ["et-EE"] = "Mis on meditatsioon?"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "And how to do it your way?",
                        ["et-EE"] = "Ja kuidas teha seda enda moodi?"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    Id = rainId,
                    SectionId = audioGuid,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Rain",
                        ["et-EE"] = "Vihm"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "",
                        ["et-EE"] = ""
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    Id = leavesId,
                    SectionId = audioGuid,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Wind and leaves",
                        ["et-EE"] = "Tuul ja lehed"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "",
                        ["et-EE"] = ""
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    Id = flyId,
                    SectionId = videoGuid,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Fly-by",
                        ["et-EE"] = "Möödalend"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = "Everything looks calmer up high",
                        ["et-EE"] = "Kõrgel paistab kõik rahulikum"
                    },
                    Author = "FiveMinuteMindfulness"
                }
            };

            context.Assignments.AddRange(assignments);
            context.SaveChanges();

            var chapters = new List<Chapter>()
            {
                new()
                {
                    AssignmentId = crashId,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Crash Course",
                        ["et-EE"] = "Kiirkursus"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = @"<p>
                    What even is mindfulness? Is it just a buzzword that means nothing or something more?
                    </p>
                    <p>
                    When was the last time <span class=""purple"">you</span> took yourself out of an everyday
                        situation and pondered how <span class = ""purple"">you</span> got
                        there? When was the last time <span class = ""purple"">you</span> went up to a wall in <span
                        class = ""purple"">your</span> house and just ran <span class = ""purple"">your</span> hand over
                        it? Go ahead and try it, we know it sounds stupid at first, but taking a moment just to do
                        something and being present is hard when <span class = ""purple"">you</span> are not used to it.
                        Observing, experiencing and
                        being present is foreign, yet we are conscious of our actions every day.
                        </p>
                        <p>
                        It is something we have all experienced as kids.As children, we are always present for the
                        things we experience since everything is novel - every occasion, every new thing, every feeling.
                        With age, we focus on our goals and ambitions.
                        </p>
                        <p> We are always present and listening to our actions and words.Some of <span
                        class = ""purple"">you</span> might even be mindful
                        without realizing that.In essence, that is mindfulness.Taking a step back and seeing yourself
                        in the moment.Taking in all the sensations, such in the way as a child.
                        This is <span class = ""purple"">your</span> first step.There are many who would say that <span
                        class = ""purple"">you</span> should do this and that – we
                        don’t believe in that.Mindfulness is extremely personal and there is no easy sure fire 5-step
                        plan that someone can take to show how <span class =
                        ""purple"">you</span> express it. Just come and
                        enjoy the journey.
                        </p>",
                        ["et-EE"] =
                            @"<p>
                    Mis üldse on tähelepanelikkus? Kas see on lihtsalt moesõna, mis ei tähenda midagi või midagi enamat?
                </p>
                <p>
                    Millal viimati <span class=""purple"">su</span> end argipäevast välja võtsid
                    olukorda ja mõtisklesid, kuidas <span class=""purple"">su</span> said
                    seal? Millal viimati <span class=""purple"">su</span> riigis <span seina äärde läksid
                        class=""purple"">sinu</span> maja ja andis lihtsalt <span class=""purple"">sinu</span> kätte
                    see? Proovige seda, me teame, et see kõlab alguses rumalalt, kuid selleks kulub hetk
                    midagi ja kohalolek on raske, kui <span class=""purple"">sa</span> pole sellega harjunud.
                    Vaatlemine, kogemine ja
                    kohalolek on võõras, ometi oleme oma tegudest iga päev teadlikud.

                </p>
                <p>
                    See on midagi, mida me kõik oleme lapsepõlves kogenud. Lastena oleme alati kohal
                    asjad, mida kogeme, kuna kõik on uudne – iga kord, iga uus asi, iga tunne.
                    Vanusega keskendume oma eesmärkidele ja ambitsioonidele.
                </p>
                <p> Oleme alati kohal ja kuulame oma tegusid ja sõnu. Mõned <span
                        class=""purple"">sa</span> võid isegi tähelepanelik olla
                    seda teadvustamata. Sisuliselt on see mindfulness. Astuge samm tagasi ja vaadake ennast
                    hetkel. Võttes sisse kõik aistingud, näiteks lapsepõlves.
                    See on <span class=""purple"">sinu</span> esimene samm. On palju neid, kes ütleksid, et <span
                            class=""purple"">sina</span> peaksid tegema seda ja seda – meie
                    ära usu sellesse. Mindfulness on äärmiselt isiklik ja 5-sammulist lihtsat kindlat tuld pole
                    plaan, mille abil keegi saab näidata, kuidas <span class=""purple"">sa</span> seda väljendad. Lihtsalt tule ja
                    naudi reisi.
                </p>"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    AssignmentId = complexityId,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Living fast and slow",
                        ["et-EE"] = "Elades kiiresti ja aeglaselt"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = @"<p>
                From traditional media to social platforms and new unseen virtual reality worlds that we are
                conjuring
                up today – we are living in a world that has pressed the pedal through the floor. While generally we
                have adjusted to most of the complexity, our evolution that has gradually led us to this point over
                tens
                of thousands of years, has not caught up. And this is only regarding the information we assess, not
                to
                mention every other aspect of our life.
            </p>

            <p>
                Even the most highly functioning people in our ever-complicating society have realized that <span
                    class=""purple"">you</span>
                cannot
                fight this fact – we need to take the time to slow down. This in essence is living fast and slow at
                the
                same time and creating a mindful schedule that considers these high fluctuations. Practicing
                mindfulness
                can help <span class=""purple"">you</span> understand how to better deal with the stress that arises and
                helps <span class=""purple"">you</span> wind it down to
                more manageable speed of life.
            </p>

            <p>
                Has <span class=""purple"">your</span> mind wandered off in the middle of something? Sure, it has and
                usually that’s because we
                are
                not present. While sometimes life gives us situations that we would rather be anywhere else, being
                present and mindful allows <span class=""purple"">you</span> to take a step back and assess in any kind of
                situation. Maybe things
                can
                be changed, maybe there are short- or long-term course corrections that can be taken to avoid these
                kinds of situations, maybe it just happened to be one of those days. There are a lot of maybes and
                allowing yourself a minute to take yourself out of our day-to-day and assess can lead to the right
                questions.
            </p>

            <p>
                And its by asking these questions about yourself and seeking the journey that brings <span
                    class=""purple"">you</span> closer to
                answers is the essence of mindfulness. Sometimes they strike <span class=""purple"">you</span> while <span
                    class=""purple"">you</span> are focusing on being
                mindful
                in peace and comfort, sometimes it strikes <span class=""purple"">you</span> in the middle of a class or
                meeting. Taking the time
                to
                assess in those situations and unpacking further afterwards allows <span class=""purple"">you</span>
                better to understand
                yourself.
            </p>",
                        ["et-EE"] = @"<p>
                Traditsioonilisest meediast sotsiaalplatvormide ja uute seninägematute virtuaalreaalsusmaailmadeni, mis me oleme
                loitsimine
                täna üleval – me elame maailmas, mis on pedaali läbi põranda vajutanud. Kuigi üldiselt me
                on kohanenud suurema osa keerukusest, meie arengust, mis on meid järk-järgult selle punktini viinud
                kümned
                tuhandete aastate jooksul, pole järele jõudnud. Ja see puudutab ainult meie poolt hinnatud teavet, mitte
                juurde
                mainida kõiki teisi meie elu aspekte.
            </p>

            <p>
                Isegi kõige paremini toimivad inimesed meie üha keerulisemaks muutuvas ühiskonnas on mõistnud, et <span
                    class=""purple"">sina</span>
                ei saa
                võidelda selle tõsiasjaga – peame võtma aega, et aeglustada. See on sisuliselt kiire ja aeglane elamine
                a
                samal ajal ja luues tähelepaneliku ajakava, mis arvestab neid suuri kõikumisi. Harjutamine
                tähelepanelikkus
                võib aidata <span class=""purple"">teil</span> mõista, kuidas tekkiva stressiga paremini toime tulla ja
                aitab <span class=""purple"">teil</span> selle maha võtta
                juhitavam elukiirus.
            </p>

            <p>
                Kas <span class=""purple"">teie</span> mõtted on millegi keskel eksinud? Muidugi, sellel on ja
                tavaliselt sellepärast, et meie
                on
                ei ole kohal. Kuigi mõnikord annab elu meile olukordi, mida tahaksime olla kusagil mujal, olles
                praegune ja tähelepanelik võimaldab <span class=""purple"">teil</span> astuda sammu tagasi ja hinnata mis tahes
                olukord. Võib-olla asju
                saab
                muuta, võib-olla on nende vältimiseks võimalik teha lühi- või pikaajalisi kursuse parandusi
                erinevaid olukordi, võib-olla juhtus see lihtsalt olema üks neist päevadest. Seal on palju võib-olla ja
                Kui annate endale minuti, et end meie igapäevasest tegevusest välja võtta ja hinnata, võib see viia õigele poole
                küsimused.
            </p>

            <p>
                Ja seda küsides enda kohta neid küsimusi ja otsides teekonda, mis toob <span
                    class=""purple"">teile</span> lähemale
                vastused on tähelepanelikkuse olemus. Mõnikord tabavad nad <span class=""purple"">teid</span>, kui <span
                    class=""purple"">sina</span> keskendud olemisele
                tähelepanelik
                rahus ja mugavuses, mõnikord tabab see <span class=""purple"">teid</span> keset tundi või
                koosolekul. Võttes aega
                juurde
                nendes olukordades hinnata ja hiljem lahti pakkimine võimaldab <span class=""purple"">teil</span>
                paremini mõista
                ise.
            </p>"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    AssignmentId = meditationId,
                    Title = new LanguageString
                    {
                        ["en-US"] = "What is meditation?",
                        ["et-EE"] = "Mis on meditatsioon?"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = @"<p>
                    When <span class=""purple"">you</span> picture meditation do <span class=""purple"">you</span>
                    imagine sitting cross-legged on the floor and following a
                    certain
                    rhythm? Do <span class=""purple"">you</span> imagine listening to a guided style of meditation
                    which tells <span class=""purple"">you</span> to slow down
                    and
                    breathe? Maybe some of these methods work for <span class=""purple"">you</span> and that is great,
                    but some of <span class=""purple"">you</span> might have
                    always imagined meditation to be only that.
                </p>

                <p>
                    Be it limited by time or by the matter <span class=""purple"">you</span> partake, it forces <span
                        class=""purple"">you</span> to focus in a certain way, and
                    perhaps that way does not work for <span class=""purple"">you</span>. Don’t get us wrong, there is
                    strong research that backs
                    the
                    tangible benefits of meditation and most of these have been measured in such controlled
                    environments.
                </p>

                <p>
                    But life is chaotic. There is school, work, <span class=""purple"">your</span> hobbies, family,
                    recreation and the list goes
                    on
                    and on and on… Sometimes finding that space to follow along is difficult and that makes a lot of
                    people give up if they can’t get it going on the first couple tries. As such, imagine having to
                    give
                    up as soon as <span class=""purple"">you</span> start since <span class=""purple"">you</span> hit
                    that mental roadblock.
                </p>

                <p>
                    A lot of us live our lives extremely goal oriented, since this is the way society grows most
                    people.
                    We forget the journey, not willingly but because it is so integral to out way of life. This
                    compounds the first failure that keeps people from exploring themselves internally, because like
                    many things it is hard at first. That is already a mental conundrum – how could it be hard to
                    know
                    yourself if <span class=""purple"">you</span> have been yourself <span class=""purple"">your</span>
                    own life? Yet, research shows the constant barrage of
                    information we face daily has made us forget who we are.
                </p>

                <p>
                    Therefore, the first goal of meditation shouldn’t be arriving at the goal as soon as possible,
                    but
                    instead creating the platform of meditation. For example, if <span class=""purple"">you</span>
                    listen to anyone who partakes
                    in
                    recreational sports, like jogging or yoga, they often compare this time they spend to
                    meditation.
                    Some people find their meditation in the faith they partake in, some go see the stars and the
                    moon,
                    others find a quiet spot and just walk around. There is no right answer to put in a book and
                    call it
                    a day.
                </p>
                <p>
                    So go out there and try different things, explore yourself and do not give up at the first of
                    failure. Go on a walk, go partake in a guided meditation, go look outside and just think with
                    yourself. 5-10 minutes a day can make a big difference from taking self-reflection and
                    meditation
                    from an unconscious thing we do every day into a mindful behavior that expands who <span
                        class=""purple"">you</span> are.
                </p>",
                        ["et-EE"] = @"<p>
                    Kui <span class=""purple"">te</span> pildimediteerite, teete <span class=""purple"">teie</span>
                    kujutage ette, et istute risti põrandal ja järgite a
                    teatud
                    rütm? Kujutage <span class=""purple"">te</span> ette, et kuulate juhendatud meditatsioonistiili
                    mis käsib <span class=""purple"">teil</span> aeglustada
                    ja
                    hingata? Võib-olla töötab mõni neist meetoditest <span class=""purple"">teie jaoks</span> ja see on suurepärane,
                    kuid mõnel <span class=""purple"">teist</span> võib see olla
                    kujutanud meditatsiooni alati ainult sellena ette.
                </p>

                <p>
                    Olgu see piiratud aja või ainega, <span class=""purple"">te</span> osalete, see sunnib <span
                        class=""purple"">teid</span>, et keskenduda teatud viisil ja
                    võib-olla see viis ei tööta <span class=""purple"">teie jaoks</span>. Ärge saage meist valesti aru, see on olemas
                    tugev uurimus, mis toetab
                    a
                    meditatsiooni käegakatsutavaid eeliseid ja enamikku neist on mõõdetud sellise kontrolli all
                    keskkondades.
                </p>

                <p>
                    Aga elu on kaootiline. Siin on kool, töö, <span class=""purple"">teie</span> hobid, pere,
                    puhkus ja nimekiri läheb
                    peal
                    ja edasi ja edasi… Mõnikord on selle jälgimisruumi leidmine keeruline ja see teeb palju
                    inimesed loobuvad, kui nad ei saa seda esimestel katsetel käima. Sellisena kujutage ette, et peate
                    anda
                    üles niipea, kui <span class=""purple"">te</span> alustate, kuna <span class=""purple"">te</span> tabasite
                    see vaimne teetõke.
                </p>

                <p>
                    Paljud meist elavad oma elu äärmiselt eesmärgipäraselt, sest nii kasvab ühiskond kõige rohkem
                    inimesed.
                    Me unustame reisi, mitte vabatahtlikult, vaid sellepärast, et see on eluviisi lahutamatu osa. See
                    ühendab esimese ebaõnnestumise, mis ei lase inimestel end sisemiselt uurida, sest nagu
                    paljud asjad on alguses rasked. See on juba vaimne mõistatus – kuidas see saabki raske olla
                    tean
                    ise, kui <span class=""purple"">sina</span> oled olnud sina <span class=""purple"">teie</span>
                    enda elu? Kuid uuringud näitavad pidevat tulva
                    teave, millega igapäevaselt silmitsi seisame, on pannud meid unustama, kes me oleme.
                </p>

                <p>
                    Seetõttu ei tohiks meditatsiooni esimene eesmärk olla eesmärgini jõudmine võimalikult kiiresti,
                    aga
                    selle asemel luua meditatsiooniplatvorm. Näiteks kui <span class=""purple"">teie</span>
                    kuulake kõiki, kes sellest osa võtavad
                    sisse
                    harrastussporti, nagu sörkjooks või jooga, võrdlevad nad sageli veedetud ajaga
                    meditatsioon.
                    Mõned inimesed leiavad oma meditatsiooni usust, millest nad osa saavad, mõned lähevad tähti vaatama
                    kuu,
                    teised leiavad vaikse koha ja jalutavad lihtsalt ringi. Pole õiget vastust, mida raamatusse panna ja
                    kutsu seda
                    päev.
                </p>
                <p>
                    Nii et minge välja ja proovige erinevaid asju, uurige ennast ja ärge andke kohe alla
                    ebaõnnestumine. Minge jalutama, osalege juhendatud meditatsioonis, minge vaadake välja ja lihtsalt mõelge kaasa
                    ise. 5-10 minutit päevas võib oluliselt muuta eneserefleksiooni ja
                    meditatsioon
                    alateadlikust asjast, mida me iga päev teeme, teadlikuks käitumiseks, mis avardab kes <span
                        class=""purple"">sina</span> oled.
                </p>"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    AssignmentId = rainId,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Rain",
                        ["et-EE"] = "Vihm"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = @"<p>
                    One of the most relaxing sounds in the world is just rain. The randomness of splattering and the
                    otherworldly calm that rain brings is mesmerizing to us all.
                </p>
                <p>
                    Pick your own speed and let it take you away.
                </p>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('windows')"">
                    🌧️ Rain against windows
                </p>

                <div id=""windows"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/mPZkdNFkNps""
                            title=""Rain Sound On Window with Thunder Sounds""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('gentle')"">
                    ☔ Gentle rain
                </p>

                <div id=""gentle"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/q76bMs-NwRk""
                            title=""Gentle Night Rain""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('waterfall')"">
                    🌊 Waterfall
                </p>

                <div id=""waterfall"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/HchoJcYNYlU""
                            title=""Gentle Night Rain""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>",
                        ["et-EE"] = @"<p>
                    Üks lõõgastavamaid helisid maailmas on lihtsalt vihm. Pritsimise juhuslikkus ja
                    ülemaailmne rahu, mida vihm toob, on meile kõigile hüpnotiseeriv.
                </p>
                <p>
                    Valige ise kiirus ja laske sellel end ära viia.
                </p>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('windows')"">
                    🌧️ Vihm vastu aknaid
                </p>

                <div id=""windows"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/mPZkdNFkNps""
                            title=""Rain Sound On Window with Thunder Sounds""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('gentle')"">
                    ☔ Õrn vihm
                </p>

                <div id=""gentle"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/q76bMs-NwRk""
                            title=""Gentle Night Rain""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('waterfall')"">
                    🌊 Kosk
                </p>

                <div id=""waterfall"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/HchoJcYNYlU""
                            title=""Gentle Night Rain""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    AssignmentId = flyId,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Fly-By",
                        ["et-EE"] = "Möödalend"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = @"<p>
                    Drones are amazing. They show us our world in a new light which makes us appreciate being here even
                    more. Sometimes understanding the world we live in is the key to understanding what is happening
                    within ourselves.
                </p>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('earth')"">
                    🗺️ Earth from above
                </p>

                <div id=""earth"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/lM02vNMRRB0""
                            title=""Earth from above""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('mountains')"">
                    🌄 Various Europe Mountains
                </p>

                <div id=""mountains"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/aIXb-RPb358""
                            title=""Various Europe Mountains""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('mountain-ranges')"">
                    🏔 Beautiful Czechia mountain ranges
                </p>

                <div id=""mountain-ranges"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/g3LHPzrKbtM""
                            title=""Beautiful Czechia mountain ranges""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>",
                        ["et-EE"] = @"<p>
                    Droonid on hämmastavad. Nad näitavad meile meie maailma uues valguses, mis paneb meid isegi siin olemist hindama
                    rohkem. Mõnikord on toimuva mõistmise võtmeks maailma mõistmine, milles me elame
                    meie sees.
                </p>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('earth')"">
                    🗺️ Maa ülalt
                </p>

                <div id=""earth"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/lM02vNMRRB0""
                            title=""Earth from above""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('mountains')"">
                    🌄 Erinevad Euroopa mäed
                </p>

                <div id=""mountains"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/aIXb-RPb358""
                            title=""Various Europe Mountains""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('mountain-ranges')"">
                    🏔 Kaunid Tšehhi mäeahelikud
                </p>

                <div id=""mountain-ranges"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                    <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/g3LHPzrKbtM""
                            title=""Beautiful Czechia mountain ranges""
                            allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                            allowfullscreen></iframe>
                </div>"
                    },
                    Author = "FiveMinuteMindfulness"
                },
                new()
                {
                    AssignmentId = leavesId,
                    Title = new LanguageString
                    {
                        ["en-US"] = "Wind and leaves",
                        ["et-EE"] = "Tuul ja lehed"
                    },
                    Description = new LanguageString
                    {
                        ["en-US"] = @"<p>
                    The summer breeze rolling over the trees. Brisk autumn breezes making leaves fall. Relaxing and
                    invigorating, calming yet random. Here is a selection which should help you get in the right
                    head-space.
                </p>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('breezes')"">
                        🍂 Autumn breezes
                        </p>

                        <div id=""breezes"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                        <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/SuSVNA21S2A""
                        title=""Autumn breezes""
                        allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                        allowfullscreen></iframe>
                        </div>

                        <p class=""content-link"" role=""button"" onclick=""showEmbedContent('forest')"">
                        🌳 Summer forest
                        </p>

                        <div id=""forest"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                        <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/4KzFe50RQkQ""
                        title=""Summer forest""
                        allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                        allowfullscreen></iframe>
                        </div>",
                        ["et-EE"] = @"<p>
                    Suvine tuul ukerdas üle puude. Korralikud sügistuuled panevad lehed langema. Lõõgastav ja
                    kosutav, rahustav, kuid juhuslik. Siin on valik, mis peaks aitama teil õiget valikut teha
                    pea-ruum.
                </p>

                <p class=""content-link"" role=""button"" onclick=""showEmbedContent('breezes')"">
                        🍂 Sügistuuled
                        </p>

                        <div id=""breezes"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                        <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/SuSVNA21S2A""
                        title=""Autumn breezes""
                        allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                        allowfullscreen></iframe>
                        </div>

                        <p class=""content-link"" role=""button"" onclick=""showEmbedContent('forest')"">
                        🌳 Suvine mets
                        </p>

                        <div id=""forest"" class=""embed-responsive embed-responsive-16by9"" style=""display: none"">
                        <iframe class=""embed-responsive-item"" src=""https://www.youtube.com/embed/4KzFe50RQkQ""
                        title=""Summer forest""
                        allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture""
                        allowfullscreen></iframe>
                        </div>"
                    },
                    Author = "FiveMinuteMindfulness"
                }
            };

            context.Chapters.AddRange(chapters);
            context.SaveChanges();

            var themes = new List<Theme>
            {
                new()
                {
                    AssignmentId = crashId,
                    Url = "https://source.unsplash.com/LpbyDENbQQg",
                    ColorPalette = "#9287ff80",
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    AssignmentId = meditationId,
                    Url = "https://source.unsplash.com/7jZNgIuJrCM",
                    ColorPalette = "#bcb59080",
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    AssignmentId = complexityId,
                    Url = "https://source.unsplash.com/nY14Fs8pxT8",
                    ColorPalette = "#323a3e80",
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    AssignmentId = rainId,
                    Url = "https://source.unsplash.com/ZxZQk7777R4",
                    ColorPalette = "#9287ff80",
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    AssignmentId = leavesId,
                    Url = "https://source.unsplash.com/3BlVILvh9hM",
                    ColorPalette = "#90b5bb80",
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                },
                new()
                {
                    AssignmentId = flyId,
                    Url = "https://source.unsplash.com/VBBGigIuaDY",
                    ColorPalette = "#6f9ed880",
                    CreatedBy = DataSeedUser,
                    UpdatedBy = DataSeedUser
                }
            };

            context.Themes.AddRange(themes);
            context.SaveChanges();
        }
    }
}