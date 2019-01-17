using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Tokenizer.Tests
{
    public class Tokenize_PositiveScenarios
    {
        public static IEnumerable<object[]> Tokenize_PositiveScenarios_TestData =new []
        {
           new object[]{ @"Share this article
Good morning, Europe. Here are some of the key stories we're following today:
Romania in the spotlight: Brussels chiefs are in Romania on Friday to mark the country taking on the rotating presidency of the EU Council. It comes after tension between Brussels and Bucharest over anti-corruption legislation and judicial reforms.
Brexit vote looms: MPs continue a five-day debate that will culminate next Tuesday with a vote on Theresa's May Brexit deal.
Shutdown continues: US President Donald Trump has threatened to use emergency powers to bypass Congress and get billions of dollars to pay for a border wall on the US-Mexico border. The issue is fuelling a partial government shutdown that has been going on for three weeks.
Police ask for Ronaldo's DNA in sexual assault inquiry: Nevada police have asked Italian authorities if they could obtain them a DNA sample from Portuguese football star Ronaldo in the investigation of accusations that he raped a woman in Las Vegas a decade ago. 
Follow our live updates, below:" },
           new object[]{ @"Diesen Artikel teilen
K-Pop - koreanische Popmusik - ist stark im Kommen und ""Momoland"" ist die koreanische Girlgroup, die Dubai bei ihrem ersten Besuch im Sturm eroberte:
""Wir kannten Dubai nur aus dem Fernsehen und haben dar�ber gelesen. Aber es ist wirklich faszinierend hier, alles ist so sch�n, besonders die Architektur"", erz�hlt Daisy von ""Momoland"".
Euronews-Reporterin Jane Witherspoon: _""K-Pop ist ein riesiges Gesch�ft im Wert von �ber viereinhalb Milliarden Euro weltweit und Momoland ist die erste Girlgroup, die mit Platin f�r �ber hundert Millionen Streams von 'Bboom Bboom' ausgezeichnet wurde. K-Pop ist in Dubai stark im Kommen.""_
Im asiatischen Raum ist K-Pop sehr verbreitet.  Fans sch�tzen das harte Training und die komplexen Tanzschritte der K�nstler und bewundern den Charakter und das Aussehen ihrer Stars:
""K-Pop ist einzigartig und K-Pop-K�nstler haben keine Scheu, ihre Kreativit�t zu zeigen: mit ihrer Kleidung, ihrem Stil, ihrer Musik, ihren Melodien - deshalb haben sie Erfolg"", sagt Bloggerin Fatima.
In Dubai wurde die Girlgroup von Hunderten von Fans erwartet: ""Das sind so tolle Leute, die uns immer herzlich begr��en und unsere Musik so sehr lieben, wie wir sie lieben"", so Nancy von ""Momoland"".
Die Fans freuen sich, ihre Idole vor Ort erleben zu k�nnen:
""Wir sind wirklich ein Fan von ihnen, seit sie ihren Song 'Bboom Bboom' im vergangenen Jahr ver�ffentlicht haben. Es ist toll, dass sie gerade in Dubai sind"", meint ein junger Mann.
""Ich hoffe, dass sie wieder kommen und mehr Bands mitbringen und mehr Spa� haben und in Zukunft noch mehr tolle Songs spielen"", sagt eine junge Frau.
Laut der euronews-Reporterin gelten die M�dchen auch als starke Vorbilder f�r Frauen, was im Nahen Osten sehr gesch�tzt werde. Neben der F�rderung des Tourismus tragen Auftritte wie die von Momoland auch zum kulturellen Austausch zwischen verschiedenen Bev�lkerungsgruppen in Dubai bei:
""In den Vereinigten Arabischen Emiraten gibt es viele Koreaner, sie f�hlen sich heimisch, wenn sie ihre Kultur hier erleben k�nnen, au�erdem feiern wir das Jahr der Toleranz"", sagt Humaid Alhammadi, Pr�sident der VAE-Korea Freundschaftsgesellschaft.  " },
           new object[]{ @"Internal political conflicts and an absence of priorities could end up defining Romania�s leadership of the Council of the European Union, writes a political scientist in Bucharest. 
On the 1st of January, Romania for the first time took the rotating presidency of the EU Council. Much has already been said on the subject, but without ever addressing the heart of the problem. Firstly, let�s note that the assumption of this role does not guarantee a country�s improved status at the cultural level. It�s true that the country will organise many meetings for ministers, as well as experts, but cultural events in Brussels will hardly lead to more awareness of Romania as a country.
Unfortunately, even if we don�t know the precise program of Romania�s presidency, it seems that this form of promotion is indeed what is planned. It would be far more effective to focus more on the content of ministerial discussions taking place in Romania. Holding a council summit in Sibiu is an excellent decision, insofar as promoting the country is concerned. But it�s entirely possible that such a meeting will be boycotted by the current government due to political differences with president Klaus Iohannis.
The summit organised in Salzburg during the Austrian presidency, dedicated exclusively to Brexit, was an organisational disaster. The same goes for those organised by Slovakia and Bulgaria. And the press will be no more forgiving of organisational errors on the part of Bucharest. But the press may turn its focus to another level, given that hopes are hardly high: indeed, it�s incredibly difficult to organise summits within the framework of the presidency, and this is well known in Brussels.
The main problem rather lies with the priorities of the Romanian presidency. From the beginning, this presidency was going to be, is and will be, defined by an absence of priorities. It would perhaps be preferable to present this vice as a virtue (�we don�t have priorities, our only priority is Europe�), instead of vaguely formulating priorities in perfectly incomprehensible jargon. Malta�s priorities were migrants in the Mediterranean and resolving the conflict in Libya. Bulgaria focused on the western Balkans. Romania could have prioritised the EU�s relationship with the Eastern Partnership, with special emphasis on Moldova. Or it could have focused on EU enlargement in the western Balkans.
The Romanian foreign affairs minister�s recent visit to Belgrade indicates a step in that direction, and deserves praise as such � but it seems to have come too late, and lacks substance. Romania could have publicly insisted on pursuing EU enlargement after the May elections, and on the creation of a dedicated role for the topic at the level of the European Commission. In reality, this role is entirely absent from Bucharest�s diplomatic vocabulary. But above all, Romania could have established as an absolute priority the consolidation of democratic mechanisms, the rule of law and the protection of human rights at the European level.
There exist numerous projects working in this direction, but coordination at the European level is sorely lacking. This failure can only be added to the Romanian presidency�s already long list of missed opportunities. Clearly, in a context where the Romanian government itself is undermining rule of law, such a prospect is difficult to imagine. This absence of priorities puts Romania in a complicated position during its six-month presidency. The situation with Poland and Hungary, where the application of mechanisms to protect rule of law are underway, is certain to be brought up during the meetings of ministers of justice and internal affairs.
Romania has not taken a clear position with regard to these countries� non-respect of the rule of law. Concerning Hungary, there is no position � this is likely due to the position of UDMR (Democratic Alliance of Hungarians in Romania) within the current coalition government, even if a stronger position on this issue wouldn�t necessarily incite much negative reaction. With regard to Poland, there is only the position of principle expressed by the minister for foreign affairs, as well as president Iohannis � according to which there is no need for sanctions but that it is indeed good to respect the rule of law. Thus, Romanian ministers will have no clear agenda when they meet with their European counterparts.
For the six months in which Romania will hold the presidency, Brexit will be the main problem facing the EU. The prospect of a no-deal Brexit becomes more likely with each passing day. The United Kingdom cannot renegotiate the foundations of an agreement except by holding a second referendum. This is the only door left open in Brussels for new negotiations after March 29th. The summit in Sibiu on May 9th will be crucial: either recognise a no-deal Brexit, or agree on a new course of action if London decides on another referendum. Unfortunately, Romania has no clear vision regarding a no-deal Brexit and cannot be expected to lead debates on the issue.
During these six months, there will also be parliamentary elections in Moldova (on February 24th). European institutions are already mobilised on the question of faltering democracy in this former soviet republic: besides the recommendations of the Council of Europe�s Venice Commission, a joint action with the OCSE, the president of the European Council and the High Representative for foreign policy have already made their positions clear, as has the European Parliament. The problem concerns how Romania will respond to the possible condemnation of elections in Moldova. The outlook is bleak: Romania officially supports the Chisinau government, lead by Vladimir Plahotniuc. Romania should demand the respect of democratic principles during the elections, but it can�t, due to the close relationship between Romania�s social-democratic party (PSD, currently in power) and the oligarchic regime in Chisinau.
Following this line of argument, what will happen if the EU decides on personal sanctions against Plahotniuc and those who support him, following the model of sanctions imposed on Russian officials? It is not unlikely at all that, after the vote and the non-respect of recommendations from the European Commission and the Venice Commission, Brussels will decide to freeze Plahotniuc�s assets held in EU banks. The problem is that Plahotniuc, who is also a Romanian citizen, possesses many assets in Romania too. How will Romania react if such sanctions are on the agenda during meetings at which it presides? After all, no presidency has yet been spared from political crises or the difficulty of speaking objectively on a given subject.
The biggest challenge facing the Romanian presidency is of course the European elections. For a long time already, Romania should have pursued a strategy of negotiation in order to occupy key positions within European institutions following the elections. With the PSD not even trying to hide its hostility towards the Socialists and Democrats� (S&D) official candidate for the European Commission presidency (Frans Timmermans); with another party (ALDE, liberals) whose membership in the Liberal parliamentary group after the election is still in question; and with a European commissioner (Corina Cre�u) at odds with the Romanian government, the chances of taking advantage of this presidency are minimal, as is the possibility of finding key positions within the institutions. Indeed, this is already a wasted opportunity.
Another significant handicap for the Romanian presidency is the way in which the western press writes about it. Simply highlighting certain truths, such as the fact that prime minister Viorica D�ncil� is a puppet of the PSD leader, Liviu Dragnea, as controversial as he is popular � trying his best to avoid a prison sentence � undermines all discussion of Romania during the presidency. No communication strategy can mask the political reality of the country. The only ray of light for the Romanian presidency is provided by the team who will manage things at the technical level. In Bucharest, there is a professional team in the Ministry of European Affairs, well connected to the Ministry of Foreign Affairs. In Brussels, Lumini�a Odobescu (Permanent Representative of Romania in the EU) remains highly regarded, as are many members of her team.
The problem is not knowing whether or not Romania is prepared for this presidency. The fundamental problem is knowing whether Romania can deal with EU issues from a European perspective, rather than a national one, and whether it can maximise all the opportunities which may arise from its current position to achieve national objectives. From this point of view, discussion has yet to begin, and it�s all too possible that it never will.

									Translated from the Romanian by Alexandra Spanu, Ciaran Lawless							
Factual or translation error? Tell us.
" },
           new object[]{ @"Vom politischen Blickwinkel aus betrachtet war 2018 ein recht turbulentes Jahr. 2019 k�nnte mindestens genauso st�rmisch werden. In den ersten Monaten werden die Unsicherheiten um den Brexit dominieren, und ein Gro�teil der Aufmerksamkeit dem Ergebnis der Europawahl gelten: Populistische Parteien sollen an Terrain gewinnen, und bestimmen, ob die EU auch weiterhin f�hig sein wird, mit dem �blichen �deutsch-franz�sischen Motor� zu laufen, meint der Politikwissenschaftler Cas Mudde. 
F�r alle, die sich eine Pause in der hektischen Politik der letzten Jahre erhofft haben: 2019 wird es diese nicht geben. Das kommende Jahr ist ein bedeutendes Wahljahr in Europa: Parlamentswahlen in sieben EU-Mitgliedstaaten (sowie in der Schweiz), Pr�sidentschaftswahlen in sechs L�nder (sowie in Mazedonien und der Ukraine). Und nat�rlich die wichtigste von allen: Die Europawahl im Mai. Und das sind nur die geplanten Wahlen. Folglich ist es also fast unm�glich, klare Prognosen f�r 2019 abzugeben, insbesondere in einem so kurzen Text wie diesem. Lassen Sie mich es trotzdem einmal versuchen.
Erstens, ob wir es wollen oder nicht � und die meisten von uns wollen es seit Monaten nicht mehr: Der Brexit wird die ersten Monate des Jahres 2019 beherrschen. Wird es eine neue Parlamentswahl geben? Eine �Volksabstimmung� (d.h. ein zweites Referendum)? Ein Deal oder kein Brexit-Deal? Oder gar kein Brexit? Ihre Vermutung ist ebenso gut wie meine. Sicher ist aber, dass uns das alles noch mindestens ein paar Monate besch�ftigen wird. Das gilt ebenfalls f�r die politischen Auswirkungen einer (Nicht-)Entscheidung, vor allem im Vereinigten K�nigreich selbst, aber auch f�r die EU und ihre Mitgliedstaaten, insbesondere die Republik Irland.
Zweitens wird der so genannte �Aufstieg des Populismus� wieder einmal einen Gro�teil der Medienberichterstattung �ber die verschiedenen Wahlen im Jahr 2019 beherrschen. Zwar werden die populistischen Parteien insgesamt ein paar bescheidene Siege erzielen, jedoch werden diese sehr ungleichartig sein, und zwar haupts�chlich im rechten Fl�gel. Von den derzeit in den Regierungen sitzenden Parteien wird erwartet, dass sie gro�e Verluste erleiden, d.h. die Wahren Finnen in Finnland sowie Syriza und die Unabh�ngigenGriechen in Griechenland. Selbst die D�nische Volkspartei, welche die liberale Minderheitsregierung unterst�tzt, soll einen (geringen) Verlust einstecken m�ssen. Gleichzeitig wird von mehreren populistischen Oppositionsparteien des rechtsextremen Fl�gels erwartet, dass sie sehr gut abschneiden, beispielsweise die Partei Fl�mische Interessen in Belgien und insbesondere die am meisten ignorierte rechtsextreme Partei in Europa: Die Estnische Konservative Volkspartei, f�r die derzeit �ber 15 Prozent stimmen wollen.
Die wichtigste Ausnahme von diesem allgemeinen Trend ist Recht und Gerechtigkeit (PiS) in Polen � die drittwichtigste politische Geschichte des Jahres 2019. Trotz innenpolitischer Opposition und internationaler Kritik, sowie einer relativ heftigen EU-Opposition � insbesondere im Vergleich zu den samtenen EU-Handschuhen ihres Vorbilds � Viktor Orb�ns Ungarischer B�rgerbund (Fidesz) � hat die zunehmend populistische und rechtsradikale PiS-Regierung ihre Beliebtheit gesteigert. Anders als in Ungarn steht der PiS jedoch eine einigerma�en gut organisierte liberal-demokratische Opposition gegen�ber � die B�rgerplattform (PO). Ferner kann sie nicht von einem ausgesprochen unverh�ltnism��igen Wahlsystem profitieren. Die Wahlen 2019 werden dar�ber entscheiden, ob die PiS � mit der (stillschweigenden) Unterst�tzung der Kukiz-Bewegung (Kukiz'15) � eine verfassungsm��ige Mehrheit erreichen� und damit das illiberale �Budapester Modell� wirklich �bernehmen kann �, oder ob sie ihre illiberale Agenda auch weiterhin ohne demokratisches Mandat durchsetzen muss. In diesem Zusammenhang wird sie die EU zwingen, mit offenen Karten zu spielen: Wird sie bereit und f�hig sein, Polen zu bestrafen? Oder wird die EU alle illiberalen Demokraten in ihren Kreisen mit Samthandschuhen anfassen?
Die vierte und offensichtlich bedeutendste Geschichte des Jahres 2019 wird die Europawahl im Mai sein. Hier geht es nicht einmal so sehr um die Wahlergebnisse der verschiedenen Fraktionen und ihrer einzelnen Mitgliedsparteien, sondern um ihre Zusammensetzung. Ohne die Briten stehen vermutlich viele politische Gruppen vor grundlegenden Herausforderungen. Bei den �weichen euroskeptischen� Europ�ischen Konservativen und Reformer (EKR) dominieren die Tories der Konservativen und Unionistischen Partei, w�hrend das �harte euroskeptische� Europa der Freiheit und der direkten Demokratie (EFDD oder EFD) von der britischen Partei f�r die Unabh�ngigkeit des Vereinigten K�nigreichs (UKIP) beherrscht wird. Sollte die EFDD wie erwartet kollabieren, k�nnte die ECR viele seiner Mitglieder aufnehmen und sich weiter in Richtung der radikalen Rechten bewegen, was eine Art Zusammenarbeit oder vielleicht sogar Fusion mit dem Europa der Nationen und der Freiheit (ENF) von Marine Le Pen erm�glichen k�nnte.
Zur gleichen Zeit wird die Europ�ische Volkspartei (EVP) voraussichtlich ein paar W�hler verlieren, aber wahrscheinlich auch ihren (relativen) Vorsprung gegen�ber der Progressiven Allianz der Sozialdemokraten (S&D) ausbauen. Noch wichtiger ist, dass sich die EVP mit der Wahl von Manfred Weber als Spitzenkandidat gegen�ber Alex Stubbs voll und ganz einem rechtsgerichteten politischen Kurs verschrieben hat, der das �zentristische� B�ndnis EVP-S&D-ALDE, das bisher das Europ�ische Parlament dominiert hat, weiterhin schw�cht. W�hrend es wahrscheinlich auch in Zukunft mindestens zwei harte euroskeptische Rechtsgruppen geben wird, von denen eine im Hinblick auf die offizielle Koalitionspolitik vermutlich au�erhalb des �Bereichs des Seri�sen� (d.h. ENF) bleiben wird, k�nnten euroskeptische Kr�fte innerhalb der EVP sie nutzen, um eine gewisse Vetomacht zu erreichen. Dies w�rde eine deutliche europ�ische Integration k�nftig problematischer und unwahrscheinlicher machen.
Letzten Endes h�ngt jedoch viel von einem Mann ab � und damit der f�nften und letzten Geschichte: Der franz�sische Staatspr�sident Emmanuel Macron. W�hrend er auf den Stra�en von den sogenannten Gilets Jaunes (Gelbwesten) herausgefordert wird, k�mpft seine Partei En Marche(Die Republik in Bewegung!) gegen dramatische (Un)Popularit�ts-Ergebnisse an. �Daran l�sst sich erkennen, dass er sowohl in Frankreich als auch in Europa an Dynamik verloren hat. Allerdings hat Macron die Menschen schon einmal �berrascht, und die franz�sische Politik ist heutzutage �u�erst unbest�ndig. So stimmt es zwar, dass Macron im Augenblick ziemlich nebens�chlich aussieht, mit einem guten Ergebnis bei der Europawahl k�nnte er seine Macht in Paris aber wiederherstellen, und in Br�ssel erneut als K�nigsmacher fungieren. Dar�ber hinaus besteht auch die M�glichkeit einer Wiederauferstehung des deutsch-franz�sischen Motors, insbesondere seit der j�ngsten Wahl einer Frankreich freundlich gesinnten neuen Vorsitzenden der CDU � und damit der Spitzenkandidatin f�r die n�chste deutsche Bundeskanzlerwahl.

									Translated by Julia Heinemann							
Factual or translation error? Tell us." },
        };

        private readonly ITestOutputHelper _output;

        public Tokenize_PositiveScenarios(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [MemberData(nameof(Tokenize_PositiveScenarios_TestData))]
        public void Tokenize_ProperData_ProperTokenization(string data)
        {
            var tokenizer = new Tokenizer(data);

            var tokens = tokenizer.Tokenize().ToList();

            tokens.Should().NotBeNullOrEmpty();
            tokens.Should().HaveCountGreaterThan(20);

            var tokensToPrint = string.Join('|', tokens.GetRange(0, 10));
            _output.WriteLine("First 10 tokens joined with '|' character:\n{0}", tokensToPrint);

        }
    }
}
