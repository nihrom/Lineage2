using GameServer.Domain.Enums;
// ReSharper disable MemberCanBePrivate.Global

namespace GameServer.Domain.Models;

public class L2Class
{
    public static readonly L2Class Fighter = new() { Id = 0, IsMage = false, Race = Race.Human };
    public static readonly L2Class Warrior = new() { Id = 1, IsMage = false, Race = Race.Human, Parent = Fighter };
    public static readonly L2Class Gladiator = new() { Id = 2, IsMage = false, Race = Race.Human, Parent = Warrior };
    public static readonly L2Class Warlord = new() { Id = 3, IsMage = false, Race = Race.Human, Parent = Warrior };
    public static readonly L2Class Knight = new() { Id = 4, IsMage = false, Race = Race.Human, Parent = Fighter };
    public static readonly L2Class Paladin = new() { Id = 5, IsMage = false, Race = Race.Human, Parent = Knight };
    public static readonly L2Class DarkAvenger = new() { Id = 6, IsMage = false, Race = Race.Human, Parent = Knight };
    public static readonly L2Class Rogue = new() { Id = 7, IsMage = false, Race = Race.Human, Parent = Fighter };
    public static readonly L2Class TreasureHunter = new() { Id = 8, IsMage = false, Race = Race.Human, Parent = Rogue };
    public static readonly L2Class Hawkeye = new() { Id = 9, IsMage = false, Race = Race.Human, Parent = Rogue };

    public static readonly L2Class Mage = new() { Id = 10, IsMage = true, Race = Race.Human };
    public static readonly L2Class Wizard = new() { Id = 11, IsMage = true, Race = Race.Human, Parent = Mage };
    public static readonly L2Class Sorcerer = new() { Id = 12, IsMage = true, Race = Race.Human, Parent = Wizard };
    public static readonly L2Class Necromancer = new() { Id = 13, IsMage = true, Race = Race.Human, Parent = Wizard };
    public static readonly L2Class Warlock = new() { Id = 14, IsMage = true, IsSummoner = true, Race = Race.Human, Parent = Wizard };
    public static readonly L2Class Cleric = new() { Id = 15, IsMage = true, Race = Race.Human, Parent = Mage };
    public static readonly L2Class Bishop = new() { Id = 16, IsMage = true, Race = Race.Human, Parent = Cleric };
    public static readonly L2Class Prophet = new() { Id = 17, IsMage = true, Race = Race.Human, Parent = Cleric };

    public static readonly L2Class ElvenFighter = new() { Id = 18, IsMage = false, Race = Race.Elf };
    public static readonly L2Class ElvenKnight = new() { Id = 19, IsMage = false, Race = Race.Elf, Parent = ElvenFighter };
    public static readonly L2Class TempleKnight = new() { Id = 20, IsMage = false, Race = Race.Elf, Parent = ElvenKnight };
    public static readonly L2Class SwordSinger = new() { Id = 21, IsMage = false, Race = Race.Elf, Parent = ElvenKnight };
    public static readonly L2Class ElvenScout = new() { Id = 22, IsMage = false, Race = Race.Elf, Parent = ElvenFighter };
    public static readonly L2Class PlainsWalker = new() { Id = 23, IsMage = false, Race = Race.Elf, Parent = ElvenScout };
    public static readonly L2Class SilverRanger = new() { Id = 24, IsMage = false, Race = Race.Elf, Parent = ElvenScout };

    public static readonly L2Class ElvenMage = new() { Id = 25, IsMage = true, Race = Race.Elf };
    public static readonly L2Class ElvenWizard = new() { Id = 26, IsMage = true, Race = Race.Elf, Parent = ElvenMage };
    public static readonly L2Class SpellSinger = new() { Id = 27, IsMage = true, Race = Race.Elf, Parent = ElvenWizard };
    public static readonly L2Class ElementalSummoner = new() { Id = 28, IsMage = true, IsSummoner = true, Race = Race.Elf, Parent = ElvenWizard };
    public static readonly L2Class Oracle = new() { Id = 29, IsMage = true, Race = Race.Elf, Parent = ElvenMage };
    public static readonly L2Class Elder = new() { Id = 30, IsMage = true, Race = Race.Elf, Parent = Oracle };

    public static readonly L2Class DarkFighter = new() { Id = 31, IsMage = false, Race = Race.DarkElf };
    public static readonly L2Class PalusKnight = new() { Id = 32, IsMage = false, Race = Race.DarkElf, Parent = DarkFighter };
    public static readonly L2Class ShillienKnight = new() { Id = 33, IsMage = false, Race = Race.DarkElf, Parent = PalusKnight };
    public static readonly L2Class BladeDancer = new() { Id = 34, IsMage = false, Race = Race.DarkElf, Parent = PalusKnight };
    public static readonly L2Class Assassin = new() { Id = 35, IsMage = false, Race = Race.DarkElf, Parent = DarkFighter };
    public static readonly L2Class AbyssWalker = new() { Id = 36, IsMage = false, Race = Race.DarkElf, Parent = Assassin };
    public static readonly L2Class PhantomRanger = new() { Id = 37, IsMage = false, Race = Race.DarkElf, Parent = Assassin };

    public static readonly L2Class DarkMage = new() { Id = 38, IsMage = true, Race = Race.DarkElf };
    public static readonly L2Class DarkWizard = new() { Id = 39, IsMage = true, Race = Race.DarkElf, Parent = DarkMage };
    public static readonly L2Class Spellhowler = new() { Id = 40, IsMage = true, Race = Race.DarkElf, Parent = DarkWizard };
    public static readonly L2Class PhantomSummoner = new() { Id = 41, IsMage = true, IsSummoner = true, Race = Race.DarkElf, Parent = DarkWizard };
    public static readonly L2Class ShillienOracle = new() { Id = 42, IsMage = true, Race = Race.DarkElf, Parent = DarkMage };
    public static readonly L2Class ShillienElder = new() { Id = 43, IsMage = true, Race = Race.DarkElf, Parent = ShillienOracle };

    public static readonly L2Class OrcFighter = new() { Id = 44, IsMage = false, Race = Race.Orc };
    public static readonly L2Class OrcRaider = new() { Id = 45, IsMage = false, Race = Race.Orc, Parent = OrcFighter };
    public static readonly L2Class Destroyer = new() { Id = 46, IsMage = false, Race = Race.Orc, Parent = OrcRaider };
    public static readonly L2Class OrcMonk = new() { Id = 47, IsMage = false, Race = Race.Orc, Parent = OrcFighter };
    public static readonly L2Class Tyrant = new() { Id = 48, IsMage = false, Race = Race.Orc, Parent = OrcMonk };

    public static readonly L2Class OrcMage = new() { Id = 49, IsMage = true, Race = Race.Orc };
    public static readonly L2Class OrcShaman = new() { Id = 50, IsMage = true, Race = Race.Orc, Parent = OrcMage };
    public static readonly L2Class Overlord = new() { Id = 51, IsMage = true, Race = Race.Orc, Parent = OrcShaman };
    public static readonly L2Class Warcryer = new() { Id = 52, IsMage = true, Race = Race.Orc, Parent = OrcShaman };

    public static readonly L2Class DwarvenFighter = new() { Id = 53, IsMage = false, Race = Race.Dwarf };
    public static readonly L2Class Scavenger = new() { Id = 54, IsMage = false, Race = Race.Dwarf, Parent = DwarvenFighter };
    public static readonly L2Class BountyHunter = new() { Id = 55, IsMage = false, Race = Race.Dwarf, Parent = Scavenger };
    public static readonly L2Class Artisan = new() { Id = 56, IsMage = false, Race = Race.Dwarf, Parent = DwarvenFighter };
    public static readonly L2Class WarSmith = new() { Id = 57, IsMage = false, Race = Race.Dwarf, Parent = Artisan };

    public static readonly L2Class Duelist = new() { Id = 88, IsMage = false, Race = Race.Human, Parent = Gladiator };
    public static readonly L2Class Dreadnought = new() { Id = 89, IsMage = false, Race = Race.Human, Parent = Warlord };
    public static readonly L2Class PhoenixKnight = new() { Id = 90, IsMage = false, Race = Race.Human, Parent = Paladin };
    public static readonly L2Class HellKnight = new() { Id = 91, IsMage = false, Race = Race.Human, Parent = DarkAvenger };
    public static readonly L2Class Sagittarius = new() { Id = 92, IsMage = false, Race = Race.Human, Parent = Hawkeye };
    public static readonly L2Class Adventurer = new() { Id = 93, IsMage = false, Race = Race.Human, Parent = TreasureHunter };
    public static readonly L2Class Archmage = new() { Id = 94, IsMage = true, Race = Race.Human, Parent = Sorcerer };
    public static readonly L2Class SoulTaker = new() { Id = 95, IsMage = true, Race = Race.Human, Parent = Necromancer };
    public static readonly L2Class ArcanaLord = new() { Id = 96, IsMage = true, IsSummoner = true, Race = Race.Human, Parent = Warlock };
    public static readonly L2Class Cardinal = new() { Id = 97, IsMage = true, Race = Race.Human, Parent = Bishop };
    public static readonly L2Class Hierophant = new() { Id = 98, IsMage = true, Race = Race.Human, Parent = Prophet };

    public static readonly L2Class EvaTemplar = new() { Id = 99, IsMage = false, Race = Race.Elf, Parent = TempleKnight };
    public static readonly L2Class SwordMuse = new() { Id = 100, IsMage = false, Race = Race.Elf, Parent = SwordSinger };
    public static readonly L2Class WindRider = new() { Id = 101, IsMage = false, Race = Race.Elf, Parent = PlainsWalker };
    public static readonly L2Class MoonlightSentinel = new() { Id = 102, IsMage = false, Race = Race.Elf, Parent = SilverRanger };
    public static readonly L2Class MysticMuse = new() { Id = 103, IsMage = true, Race = Race.Elf, Parent = SpellSinger };
    public static readonly L2Class ElementalMaster = new() { Id = 104, IsMage = true, IsSummoner = true, Race = Race.Elf, Parent = ElementalSummoner };
    public static readonly L2Class EvaSaint = new() { Id = 105, IsMage = true, Race = Race.Elf, Parent = Elder };

    public static readonly L2Class ShillienTemplar = new() { Id = 106, IsMage = false, Race = Race.DarkElf, Parent = ShillienKnight };
    public static readonly L2Class SpectralDancer = new() { Id = 107, IsMage = false, Race = Race.DarkElf, Parent = BladeDancer };
    public static readonly L2Class GhostHunter = new() { Id = 108, IsMage = false, Race = Race.DarkElf, Parent = AbyssWalker };
    public static readonly L2Class GhostSentinel = new() { Id = 109, IsMage = false, Race = Race.DarkElf, Parent = PhantomRanger };
    public static readonly L2Class StormScreamer = new() { Id = 110, IsMage = true, Race = Race.DarkElf, Parent = Spellhowler };
    public static readonly L2Class SpectralMaster = new() { Id = 111, IsMage = true, IsSummoner = true, Race = Race.DarkElf, Parent = PhantomSummoner };
    public static readonly L2Class ShillienSaint = new() { Id = 112, IsMage = true, Race = Race.DarkElf, Parent = ShillienElder };

    public static readonly L2Class Titan = new() { Id = 113, IsMage = false, Race = Race.Orc, Parent = Destroyer };
    public static readonly L2Class GrandKhavatari = new() { Id = 114, IsMage = false, Race = Race.Orc, Parent = Tyrant };
    public static readonly L2Class Dominator = new() { Id = 115, IsMage = true, Race = Race.Orc, Parent = Overlord };
    public static readonly L2Class Doomcryer = new() { Id = 116, IsMage = true, Race = Race.Orc, Parent = Warcryer };

    public static readonly L2Class FortuneSeeker = new() { Id = 117, IsMage = false, Race = Race.Dwarf, Parent = BountyHunter };
    public static readonly L2Class Maestro = new() { Id = 118, IsMage = false, Race = Race.Dwarf, Parent = WarSmith };

    public static readonly L2Class MaleSoldier = new() { Id = 123, IsMage = false, Race = Race.Kamael };
    public static readonly L2Class FemaleSoldier = new() { Id = 124, IsMage = false, Race = Race.Kamael };
    public static readonly L2Class Trooper = new() { Id = 125, IsMage = false, Race = Race.Kamael, Parent = MaleSoldier };
    public static readonly L2Class Warder = new() { Id = 126, IsMage = false, Race = Race.Kamael, Parent = FemaleSoldier };
    public static readonly L2Class Berserker = new() { Id = 127, IsMage = false, Race = Race.Kamael, Parent = Trooper };
    public static readonly L2Class MaleSoulBreaker = new() { Id = 128, IsMage = false, Race = Race.Kamael, Parent = Trooper };
    public static readonly L2Class FemaleSoulBreaker = new() { Id = 129, IsMage = false, Race = Race.Kamael, Parent = Warder };
    public static readonly L2Class Arbalester = new() { Id = 130, IsMage = false, Race = Race.Kamael, Parent = Warder };
    public static readonly L2Class DoomBringer = new() { Id = 131, IsMage = false, Race = Race.Kamael, Parent = Berserker };
    public static readonly L2Class MaleSoulHound = new() { Id = 132, IsMage = false, Race = Race.Kamael, Parent = MaleSoulBreaker };
    public static readonly L2Class FemaleSoulHound = new() { Id = 133, IsMage = false, Race = Race.Kamael, Parent = FemaleSoulBreaker };
    public static readonly L2Class Trickster = new() { Id = 134, IsMage = false, Race = Race.Kamael, Parent = Arbalester };
    public static readonly L2Class Inspector = new() { Id = 135, IsMage = false, Race = Race.Kamael, Parent = Warder };
    public static readonly L2Class Judicator = new() { Id = 136, IsMage = false, Race = Race.Kamael, Parent = Inspector };

    public static readonly L2Class SigelKnight = new() { Id = 139, IsMage = false, Race = Race.Null };
    public static readonly L2Class TyrrWarrior = new() { Id = 140, IsMage = false, Race = Race.Null };
    public static readonly L2Class OthellRogue = new() { Id = 141, IsMage = false, Race = Race.Null };
    public static readonly L2Class YulArcher = new() { Id = 142, IsMage = false, Race = Race.Null };
    public static readonly L2Class FeohWizard = new() { Id = 143, IsMage = false, Race = Race.Null };
    public static readonly L2Class IssEnchanter = new() { Id = 144, IsMage = false, Race = Race.Null };
    public static readonly L2Class WynnSummoner = new() { Id = 145, IsMage = false, Race = Race.Null };
    public static readonly L2Class AeoreHealer = new() { Id = 146, IsMage = false, Race = Race.Null };

    public static readonly L2Class SigelPhoenixKnight = new() { Id = 148, IsMage = false, Race = Race.Human, Parent = PhoenixKnight };
    public static readonly L2Class SigelHellKnight = new() { Id = 149, IsMage = false, Race = Race.Human, Parent = HellKnight };
    public static readonly L2Class SigelEvaTemplar = new() { Id = 150, IsMage = false, Race = Race.Elf, Parent = EvaTemplar };
    public static readonly L2Class SigelShillienTemplar = new() { Id = 151, IsMage = false, Race = Race.DarkElf, Parent = ShillienTemplar };
    public static readonly L2Class TyrrDuelist = new() { Id = 152, IsMage = false, Race = Race.Human, Parent = Duelist };
    public static readonly L2Class TyrrDreadnought = new() { Id = 153, IsMage = false, Race = Race.Human, Parent = Dreadnought };
    public static readonly L2Class TyrrTitan = new() { Id = 154, IsMage = false, Race = Race.Orc, Parent = Titan };
    public static readonly L2Class TyrrGrandKhavatari = new() { Id = 155, IsMage = false, Race = Race.Orc, Parent = GrandKhavatari };
    public static readonly L2Class TyrrMaestro = new() { Id = 156, IsMage = false, Race = Race.Dwarf, Parent = Maestro };
    public static readonly L2Class TyrrDoombringer = new() { Id = 157, IsMage = false, Race = Race.Kamael, Parent = DoomBringer };
    public static readonly L2Class OthellAdventurer = new() { Id = 158, IsMage = false, Race = Race.Human, Parent = Adventurer };
    public static readonly L2Class OthellWindRider = new() { Id = 159, IsMage = false, Race = Race.Elf, Parent = WindRider };
    public static readonly L2Class OthellGhostHunter = new() { Id = 160, IsMage = false, Race = Race.DarkElf, Parent = GhostHunter };
    public static readonly L2Class OthellFortuneSeeker = new() { Id = 161, IsMage = false, Race = Race.Dwarf, Parent = FortuneSeeker };
    public static readonly L2Class YulSagittarius = new() { Id = 162, IsMage = false, Race = Race.Human, Parent = Sagittarius };
    public static readonly L2Class YulMoonlightSentinel = new() { Id = 163, IsMage = false, Race = Race.Elf, Parent = MoonlightSentinel };
    public static readonly L2Class YulGhostSentinel = new() { Id = 164, IsMage = false, Race = Race.DarkElf, Parent = GhostSentinel };
    public static readonly L2Class YulTrickster = new() { Id = 165, IsMage = false, Race = Race.Kamael, Parent = Trickster };
    public static readonly L2Class FeohArchmage = new() { Id = 166, IsMage = true, Race = Race.Human, Parent = Archmage };
    public static readonly L2Class FeohSoultaker = new() { Id = 167, IsMage = true, Race = Race.Human, Parent = SoulTaker };
    public static readonly L2Class FeohMysticMuse = new() { Id = 168, IsMage = true, Race = Race.Elf, Parent = MysticMuse };
    public static readonly L2Class FeohStormScreamer = new() { Id = 169, IsMage = true, Race = Race.DarkElf, Parent = StormScreamer };
    public static readonly L2Class FeohSoulHound = new() { Id = 170, IsMage = true, Race = Race.Kamael, Parent = MaleSoulHound };
    public static readonly L2Class IssHierophant = new() { Id = 171, IsMage = true, Race = Race.Human, Parent = Hierophant };
    public static readonly L2Class IssSwordMuse = new() { Id = 172, IsMage = false, Race = Race.Elf, Parent = SwordMuse };
    public static readonly L2Class IssSpectralDancer = new() { Id = 173, IsMage = false, Race = Race.DarkElf, Parent = SpectralDancer };
    public static readonly L2Class IssDominator = new() { Id = 174, IsMage = true, Race = Race.Orc, Parent = Dominator };
    public static readonly L2Class IssDoomcryer = new() { Id = 175, IsMage = true, Race = Race.Orc, Parent = Doomcryer };
    public static readonly L2Class WynnArcanaLord = new() { Id = 176, IsMage = true, IsSummoner = true, Race = Race.Human, Parent = ArcanaLord };
    public static readonly L2Class WynnElementalMaster = new() { Id = 177, IsMage = true, IsSummoner = true, Race = Race.Elf, Parent = ElementalMaster };
    public static readonly L2Class WynnSpectralMaster = new() { Id = 178, IsMage = true, IsSummoner = true, Race = Race.DarkElf, Parent = SpectralMaster };
    public static readonly L2Class AeoreCardinal = new() { Id = 179, IsMage = true, Race = Race.Human, Parent = Cardinal };
    public static readonly L2Class AeoreEvaSaint = new() { Id = 180, IsMage = true, Race = Race.Elf, Parent = EvaSaint };
    public static readonly L2Class AeoreShillienSaint = new() { Id = 181, IsMage = true, Race = Race.DarkElf, Parent = ShillienSaint };
    
    public static readonly L2Class ErtheiaFighter = new() { Id = 182, IsMage = false, Race = Race.Ertheia };
    public static readonly L2Class ErtheiaWizard = new() { Id = 183, IsMage = true, Race = Race.Ertheia };
    
    public static readonly L2Class Marauder = new() { Id = 184, IsMage = false, Race = Race.Ertheia, Parent = ErtheiaFighter };
    public static readonly L2Class CloudBreaker = new() { Id = 185, IsMage = true, Race = Race.Ertheia, Parent = ErtheiaWizard };
    
    public static readonly L2Class Ripper = new() { Id = 186, IsMage = false, Race = Race.Ertheia, Parent = Marauder };
    public static readonly L2Class Stratomancer = new() { Id = 187, IsMage = true, Race = Race.Ertheia, Parent = CloudBreaker };
    
    public static readonly L2Class Eviscerator = new() { Id = 188, IsMage = false, Race = Race.Ertheia, Parent = Ripper };
    public static readonly L2Class SayhaSeer = new() { Id = 189, IsMage = true, Race = Race.Ertheia, Parent = Stratomancer };

    /// <summary>
    /// Идентификатор класса
    /// </summary>
    public int Id { get; init; }
    
    /// <summary>
    /// Является ли класс магическим
    /// </summary>
    public bool IsMage { get; init; }
    
    /// <summary>
    /// Является ли класс суммонером
    /// </summary>
    public bool IsSummoner { get; init; }
    
    /// <summary>
    /// Какой расы класс
    /// </summary>
    public required Race Race { get; init; }
    
    /// <summary>
    /// Класс родитель в древе классов
    /// </summary>
    public L2Class? Parent { get; init; }
}