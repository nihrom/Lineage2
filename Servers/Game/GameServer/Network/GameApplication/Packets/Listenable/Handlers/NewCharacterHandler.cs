using GameServer.Data.PlayerTemplateDataSlice;
using GameServer.Domain.Models;
using GameServer.Network.GameApplication.Packets.Listenable.Part3;
using GameServer.Network.GameApplication.Packets.Sent;

namespace GameServer.Network.GameApplication.Packets.Listenable.Handlers;

public class NewCharacterHandler 
    : BaseGameApplicationHandler, IGameApplicationHandler<NewCharacter>
{
    private readonly PlayerTemplateData  playerTemplateData;

    public NewCharacterHandler(PlayerTemplateData playerTemplateData)
    {
        this.playerTemplateData = playerTemplateData;
    }

    public async Task HandleAsync(
        NewCharacter request,
        CancellationToken ct)
    {
        var classIds = new List<L2Class>() {
            L2Class.Fighter,
            L2Class.Mage,
            L2Class.ElvenFighter,
            L2Class.ElvenMage,
            L2Class.DarkFighter,
            L2Class.DarkMage,
            L2Class.OrcFighter,
            L2Class.OrcMage,
            L2Class.DwarvenFighter,
            L2Class.MaleSoldier,
            L2Class.FemaleSoldier,
            L2Class.ErtheiaFighter,
            L2Class.ErtheiaWizard
        }.ToDictionary(c => c.Id, c => c);
        
        var templates = playerTemplateData.PlayerTemplates
            .Where(x => classIds.ContainsKey(x.ClassId))
            .OrderBy(x => x.ClassId)
            .ToList();

        var characters = templates
            .Select(x => new NewCharacterSuccess.Character(
                (int)classIds[x.ClassId].Race,
                x.ClassId,
                x.StaticData.BaseStr,
                x.StaticData.BaseDex,
                x.StaticData.BaseCon,
                x.StaticData.BaseInt,
                x.StaticData.BaseWit,
                x.StaticData.BaseMen))
            .ToList();
        
        await Avatar.SendAsync(new NewCharacterSuccess(characters), ct: ct);
    }
}