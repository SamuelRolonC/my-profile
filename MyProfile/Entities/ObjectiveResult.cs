using System.Collections.Generic;

namespace SoftwareDevelopment
{
    public class ObjectiveResult
    {
        public bool ObjectiveAccomplished { get; set; }
        
        public List<PlanResult> PlanResultList { get; set; }

        public string Message { get; set; }
    }
}
