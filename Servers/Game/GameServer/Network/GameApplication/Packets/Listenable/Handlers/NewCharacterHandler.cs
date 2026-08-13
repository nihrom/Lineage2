using GameServer.Data.PlayerTemplateDataSlice;
using GameServer.Network.GameApplication.Packets.Listenable.Part3;
using GameServer.Network.GameApplication.Packets.Sent;

namespace GameServer.Network.GameApplication.Packets.Listenable.Handlers;

public class NewCharacterHandler 
    : BaseGameApplicationHandler, IGameApplicationHandler<NewCharacter>
{
    private readonly PlayerTemplateData  _playerTemplateData;

    public NewCharacterHandler(PlayerTemplateData playerTemplateData)
    {
        _playerTemplateData = playerTemplateData;
    }

    public async Task HandleAsync(
        NewCharacter request,
        CancellationToken ct)
    {
        List<int> ClassIds = [
        0, 10, 18, 25, 31, 38, 44, 49, 53, 123, 124, 182,184];

        var templates = _playerTemplateData.PlayerTemplates
            .Where(x => ClassIds.Contains(x.ClassId))
            .OrderBy(x => x.ClassId)
            .ToList();
        
        Dictionary<int, int> races = new Dictionary<int, int>()
        {
            {0, 0}, {10, 0}, {18, 1}, {25, 1}, {31, 2}, {38, 2}, {44, 3}, {49, 3}, {53, 4}, {123, 5}, {124, 5}, {182, 6}, {183, 6}
        };

        var characters = templates
            .Select(x => new NewCharacterSuccess.Character(
                races[x.ClassId],
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