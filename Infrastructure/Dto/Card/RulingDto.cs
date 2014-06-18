using System;
using System.Diagnostics;

namespace Infrastructure.Dto.Card
{
    [DebuggerDisplay("{ReleasedAt} : {Rule}")]
    public class RulingDto
    {
        public string Rule { get; set; }
        public DateTime ReleasedAt { get; set; }
    }
}
