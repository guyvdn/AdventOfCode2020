namespace AdventOfCode2020.Day16
{
    public class FieldMap
    {
        public FieldMap(string fieldName, int fieldIndex)
        {
            FieldName = fieldName;
            FieldIndex = fieldIndex;
        }

        public string FieldName { get; }
        public int FieldIndex { get; }
    }
}