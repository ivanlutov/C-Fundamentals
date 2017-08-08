namespace _01.Stream_Progress
{
    public interface IProgressible
    {
        int Length { get; }

        int BytesSent { get; }
    }
}