namespace Task5;

public record ScholarshipCalculationData(IReadOnlyCollection<(int Mark, bool IsInTime)> MarksInfo, decimal A)
{
    public static ScholarshipCalculationData CreateFromStrings(
        IEnumerable<string>? marksInfoStr,
        string? AStr)
    {
        if (marksInfoStr is null || AStr is null)
        {
            throw new ArgumentNullException();
        }

        var marksInfoList = new List<(int, bool)>();

        foreach (var markInfo in marksInfoStr)
        {
            var markInfoParts = markInfo.Split(',');
            if (markInfoParts.Length != 2)
            {
                throw new ArgumentException("Invalid format for marksInfo");
            }

            if (!int.TryParse(markInfoParts[0], out var mark) || mark < 1 || mark > 10)
            {
                throw new ArgumentException("Invalid mark value");
            }

            if (!bool.TryParse(markInfoParts[1], out var isInTime))
            {
                throw new ArgumentException("Invalid isInTime value");
            }

            marksInfoList.Add((mark, isInTime));
        }

        if (!decimal.TryParse(AStr, out var A) || A < 0)
        {
            throw new ArgumentException("Invalid value for A");
        }

        return new ScholarshipCalculationData(marksInfoList, A);
    }
}