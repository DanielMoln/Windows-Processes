using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Extensions
{
    public static class Extensions
    {
        public static ProcessModel ConvertTo(this Process p)
        {
            ProcessModel model = new ProcessModel();
            model.Id = p.Id;
            model.Name = p.ProcessName;
            model.MemoryUsage = (long)p.VirtualMemorySize;
            try
            {
            model.StartTime = p.StartTime;
            model.ProcessFile = p.StartInfo.FileName;
            } catch (Exception e) { }
            return model;
        }

        public static IEnumerable<ProcessModel> ConvertToModelCollection(this IEnumerable<Process> models)
        {
            List<ProcessModel> results = new List<ProcessModel>();
            foreach (var pro in models)
            {
                results.Add(pro.ConvertTo());
            }
            return results;
        }
    }
}
