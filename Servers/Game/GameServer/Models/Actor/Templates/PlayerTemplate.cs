namespace GameServer.Models.Actor.Templates;

public class PlayerTemplate : CreatureTemplate
{
    //private ClassId _classId;
    
    private float[] _baseHp;
    private float[] _baseMp;
    private float[] _baseCp;
    
    private double[] _baseHpReg;
    private double[] _baseMpReg;
    private double[] _baseCpReg;
    
    private float _fCollisionHeightFemale;
    private float _fCollisionRadiusFemale;
    
    private int _baseSafeFallHeight;
    
    //private List<Location> _creationPoints;
    private Dictionary<int, int> _baseSlotDef;
}