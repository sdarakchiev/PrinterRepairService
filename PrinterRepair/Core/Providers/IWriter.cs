namespace PrinterRepairService.Providers
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
