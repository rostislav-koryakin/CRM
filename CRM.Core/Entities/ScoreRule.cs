namespace CRM.Core.Entities
{
    public class ScoreRule : BaseEntity
    {
        public enum RuleCriteria
        {
            Industry,
            Size,
            Country
        }

        public RuleCriteria Criteria { get; set; }

        public enum ScoreRelationSymbol
        {
            Equals,
            IsLess,
            IsGreater
        }

        public ScoreRelationSymbol RelationSymbol { get; set; }

        public string Value { get; set; }

        public int Points { get; set; }
    }
}
