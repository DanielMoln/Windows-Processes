using System;
using System.Diagnostics;

namespace WebApplication1.Models
{
    public class ProcessModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime? StartTime { get; set; } = null;
        public long? MemoryUsage { get; set; } = null;
        public string? ProcessFile { get; set; } 
    }
}
