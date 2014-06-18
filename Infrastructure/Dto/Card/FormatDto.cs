using System.Diagnostics;

namespace Infrastructure.Dto.Card
{
    [DebuggerDisplay("{Name}  {Legality}")]
    public class FormatDto
    {
        public string Name { get; set; }
        public string Legality { get; set; }
    }
}
