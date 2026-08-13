using System.Xml;
using System.Xml.Serialization;

namespace GameServer.Data.PlayerTemplateDataSlice;

public class PlayerTemplateData
{
    public List<PlayerTemplate> PlayerTemplates { get; private set; } = [];
    
    public void Load()
    {
        var path = AppDomain.CurrentDomain.BaseDirectory + @"\Data\Xml\Stats\Chars\BaseStats";

        var files = Directory.GetFiles(path);

        PlayerTemplates = new List<PlayerTemplate>(files.Length);

        foreach (var file in files)
        {
            var doc = new XmlDocument();
            doc.Load(file);

            var serializer = new XmlSerializer(typeof(PlayerTemplate));
            
            using var reader = new XmlNodeReader(doc);
            var test = (PlayerTemplate)serializer.Deserialize(reader)!;

            PlayerTemplates.Add(test);
        }
    }
}

[XmlRoot(ElementName = "node")]
public class Node
{
    [XmlAttribute(AttributeName = "x")]
    public int X;

    [XmlAttribute(AttributeName = "y")]
    public int Y;

    [XmlAttribute(AttributeName = "z")]
    public int Z;
}

[XmlRoot(ElementName = "creationPoints")]
public class CreationPoints
{
    [XmlElement(ElementName = "node")]
    public List<Node> Nodes = [];
}

[XmlRoot(ElementName = "basePDef")]
public class BasePDef
{
    [XmlElement(ElementName = "chest")]
    public int Chest;

    [XmlElement(ElementName = "gloves")]
    public int Gloves;

    [XmlElement(ElementName = "underwear")]
    public int Underwear;

    [XmlElement(ElementName = "cloak")]
    public int Cloak;

    [XmlElement(ElementName = "legs")]
    public int Legs;

    [XmlElement(ElementName = "head")]
    public int Head;

    [XmlElement(ElementName = "feet")]
    public int Feet;
}

[XmlRoot(ElementName = "baseMDef")]
public class BaseMDef
{
    [XmlElement(ElementName = "rear")]
    public int Rear;

    [XmlElement(ElementName = "lear")]
    public int Lear;

    [XmlElement(ElementName = "rfinger")]
    public int Rfinger;

    [XmlElement(ElementName = "lfinger")]
    public int Lfinger;

    [XmlElement(ElementName = "neck")]
    public int Neck;
}

[XmlRoot(ElementName = "baseDamRange")]
public class BaseDamRange
{
    [XmlElement(ElementName = "verticalDirection")]
    public int VerticalDirection;

    [XmlElement(ElementName = "horizontalDirection")]
    public int HorizontalDirection;

    [XmlElement(ElementName = "distance")]
    public int Distance;

    [XmlElement(ElementName = "width")]
    public int Width;
}

[XmlRoot(ElementName = "baseMoveSpd")]
public class BaseMoveSpeed
{
    [XmlElement(ElementName = "run")]
    public int Run;

    [XmlElement(ElementName = "slowSwim")]
    public int SlowSwim;

    [XmlElement(ElementName = "fastSwim")]
    public int FastSwim;

    [XmlElement(ElementName = "walk")]
    public int Walk;
}

[XmlRoot(ElementName = "collisionMale")]
public class CollisionMale
{
    [XmlElement(ElementName = "radius")]
    public double Radius;

    [XmlElement(ElementName = "height")]
    public double Height;
}

[XmlRoot(ElementName = "collisionFemale")]
public class CollisionFemale
{
    [XmlElement(ElementName = "radius")]
    public decimal Radius;

    [XmlElement(ElementName = "height")]
    public double Height;
}

[XmlRoot(ElementName = "staticData")]
public class StaticData
{
    [XmlElement(ElementName = "baseMAtk")]
    public int BaseMAtk;

    [XmlElement(ElementName = "baseMDef")]
    public required BaseMDef BaseMDef;

    [XmlElement(ElementName = "baseCanPenetrate")]
    public int BaseCanPenetrate;

    [XmlElement(ElementName = "baseAtkRange")]
    public int BaseAtkRange;

    [XmlElement(ElementName = "baseCritRate")]
    public int BaseCritRate;

    [XmlElement(ElementName = "baseMCritRate")]
    public int BaseMCritRate;

    [XmlElement(ElementName = "baseAtkType")]
    public required string BaseAtkType;

    [XmlElement(ElementName = "baseDamRange")]
    public required BaseDamRange BaseDamRange;

    [XmlElement(ElementName = "baseRndDam")]
    public int BaseRndDam;

    [XmlElement(ElementName = "baseMoveSpd")]
    public required BaseMoveSpeed BaseMoveSpeed;

    [XmlElement(ElementName = "baseBreath")]
    public int BaseBreath;

    [XmlElement(ElementName = "baseINT")]
    public int BaseInt;

    [XmlElement(ElementName = "baseSTR")]
    public int BaseStr;

    [XmlElement(ElementName = "baseCON")]
    public int BaseCon;

    [XmlElement(ElementName = "baseWIT")]
    public int BaseWit;

    [XmlElement(ElementName = "physicalAbnormalResist")]
    public int PhysicalAbnormalResist;

    [XmlElement(ElementName = "magicAbnormalResist")]
    public int MagicAbnormalResist;

    [XmlElement(ElementName = "creationPoints")]
    public required CreationPoints CreationPoints;

    [XmlElement(ElementName = "basePAtk")]
    public int BasePAtk;
    
    [XmlElement(ElementName = "baseMEN")]
    public int BaseMen;

    [XmlElement(ElementName = "baseDEX")]
    public int BaseDex;

    [XmlElement(ElementName = "baseMAtkSpd")]
    public int BaseMAtkSpd;

    [XmlElement(ElementName = "basePDef")]
    public required BasePDef BasePDef;

    [XmlElement(ElementName = "basePAtkSpd")]
    public int BasePAtkSpd;
    
    [XmlElement(ElementName = "baseSafeFall")]
    public int BaseSafeFall;
    
    [XmlElement(ElementName = "collisionMale")]
    public required CollisionMale CollisionMale;

    [XmlElement(ElementName = "collisionFemale")]
    public required CollisionFemale CollisionFemale;
}

[XmlRoot(ElementName = "level")]
public class Level
{
    [XmlElement(ElementName = "hp")]
    public double Hp;

    [XmlElement(ElementName = "mp")]
    public double Mp;

    [XmlElement(ElementName = "cp")]
    public double Cp;

    [XmlElement(ElementName = "hpRegen")]
    public double HpRegen;

    [XmlElement(ElementName = "mpRegen")]
    public double MpRegen;

    [XmlElement(ElementName = "cpRegen")]
    public double CpRegen;
    
    [XmlText]
    public required string Text;

    [XmlAttribute(AttributeName = "val")]
    public int Val;
}

[XmlRoot(ElementName = "lvlUpgainData")]
public class LvlUpGainData
{
    [XmlElement(ElementName = "level")]
    public required List<Level> Levels;
}

[XmlRoot(ElementName = "list")]
public class PlayerTemplate
{
    [XmlElement(ElementName = "classId")]
    public int ClassId;

    [XmlElement(ElementName = "staticData")]
    public required StaticData StaticData;

    [XmlElement(ElementName = "lvlUpgainData")]
    public required LvlUpGainData LvlUpGainData;
}