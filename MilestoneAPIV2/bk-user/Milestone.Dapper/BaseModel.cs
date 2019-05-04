using System;

namespace Milestone.Dapper
{
    public class BaseModel : IEntity<string>
    {
        public string Id { get; set; }
    }
}
