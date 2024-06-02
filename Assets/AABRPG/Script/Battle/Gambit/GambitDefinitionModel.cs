using AARPG.Scriptable.Battle;
using static AARPG.Battle.Gambit.GambitConst;

namespace AARPG.Battle.Gambit
{
    public sealed class GambitDefinitionModel
    {
        public GambitDefinitionData GambitDefinitionData {  get; private set; }
        public string Description { get; private set; }
        public GambitDefinitionModel(
            GambitDefinitionData gambitDefinitionData,
            string description = null
            )
        {
            GambitDefinitionData = gambitDefinitionData;
            Description = description;
        }
    }
}


