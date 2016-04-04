using System;

namespace Project.Presentation.Models
{
    public class Message
    {
        public const String TempDataKey = "TempDataAlerts";
        public String Style { get; set; }
        public String Content { get; set; }
        public bool IsDispensable { get; set; }
    }

    public static class Style
    {
        public const String Success = "success";
        public const String Information = "info";
        public const String Atention = "warning";
        public const String Error = "danger";
    }
}