//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MM.ServerMonitoring.Repository.EntityFramework.Model.Dto;

public class Dashboard
{
    public int CountMonitor { get; set; }
    public int CountResults { get; set; }
    public int CountActions { get; set; }
    public int CountFailed { get; set; }
    public int CountSuccess { get; set; }
    public int CountFailedLastHour { get; set; }
    public int Placeholder1 { get; set; }
    public int Placeholder2 { get; set; }
    public int Placeholder3 { get; set; }
    public int Placeholder4 { get; set; }
}
//
//{
//    public class MonitorDto
//    {
//        public TargetDto Target { get; set; }
//        public ActionDto Action { get; set; }
//        public ParameterDto Parameter { get; set; }
//        public string Description { get; set; }
//        public Guid Id { get; init; }
//        public string Name { get; set; }
//    }

//    public class ParameterDto
//    {
//        public ParameterTypDto ParameterTyp { get; }
//        public string Value { get; }
//        public Guid Id { get; }
//    }

//    public class ParameterTypDto
//    {
//        public string Description { get; set; }
//        public Guid Id { get; set; }
//        public string Name { get; set; }
//    }

//    public class ActionDto
//    {

//        public string Description { get; set; }
//        public Guid Id { get; set; }
//        public string Name { get; set; }
//    }

//    public class TargetDto
//    {
//        public TargetTypDto TargetTyp { get; }
//        public Guid Id { get; }
//        public string Name { get; set; }
//    }

//    public class TargetTypDto
//    {
//        public string Description { get; set; }
//        public Guid Id { get; set; }
//        public string Name { get; set; }
//    }
//}