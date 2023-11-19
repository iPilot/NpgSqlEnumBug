namespace NpgSqlEnumBug
{
    public class TestEntity
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public TestEnum Enum { get; set; }

        public TestEnum2 Enum2 { get; set; }
    }
}