using AventStack.ExtentReports;

namespace Common.Utilities.Converters
{
    public static class StatusConverter
    {
        public static Status Convert(int status) => status switch
        {
            0 => Status.Error,
            1 => Status.Skip,
            2 => Status.Pass,
            3 => Status.Warning,
            4 => Status.Fail,
            _ => Status.Warning,
        };
    }
}
