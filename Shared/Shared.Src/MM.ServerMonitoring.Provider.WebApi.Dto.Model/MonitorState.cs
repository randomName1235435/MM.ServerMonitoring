////using ValueOf;

////Repository.Model ist db!! or text or whatever
//namespace DtoModel.Update
//{
//    //public class NonEmptyGuiIdBase : ValueOf<Guid, NonEmptyGuiIdBase>
//    //{
//    //    protected override void Validate()
//    //    {
//    //        if (Value == Guid.Empty)
//    //            throw new ArgumentException("must be not empty", nameof(Value));

//    //        base.Validate();
//    //    }
//    //}
//    //public class MonitorActionResult
//    //{
//    //    public IAction<ITargetAdress> ExecutedAction { get; set; }
//    //    public MonitorActionId MonitorActionId { get; set; }
//    //    public DateTime Timestamp { get; set; }

//    //    public IResult Result { get; set; }
//    //    public MonitorActionResultId Id { get; set; }
//    //}
//    //public class MonitorActionResultId : NonEmptyGuiIdBase { }
//    //public class MonitorActionId : NonEmptyGuiIdBase { }
//    //public class IResult { }

//    //public class Passed : IResult { }
//    //public class Failed : IResult { }


//    //public class MonitorId : NonEmptyGuiIdBase { }
//    //public class Monitor
//    //{

//    //    public MonitorId Id { get; init; }
//    //    public IAction<ITargetAdress> Action { get; set; }
//    //}
//    //public interface ITargetAdress { }

//    //public interface IAction<TTargetAdress> where TTargetAdress : ITargetAdress
//    //{
//    //    public string Description { get; set; }
//    //    public string Name { get; set; }
//    //}


//    //public class PingTargetAdress : ITargetAdress
//    //{
//    //    public IP IP { get; set; }
//    //}
//    //public class HttpTargetAdress : ITargetAdress
//    //{
//    //    public Url Url { get; set; }
//    //}
//    //public class SnmpTargetAdress : ITargetAdress
//    //{
//    //    public Server Server { get; set; }
//    //}
//    //public class HttpHealthSiteTargetAdress : ITargetAdress
//    //{
//    //    public Url Url { get; set; }
//    //}
//    //public class SoapWsdlTargetAdress : ITargetAdress
//    //{
//    //    public SoapAdress MyProperty { get; set; }
//    //}
//}
//namespace DtoModel.Delete { }
//namespace DtoModel.Insert { }
//namespace DtoModel.Read
//{

//    namespace Ids
//    {
//        public class MonitorActionResultId : GuiIdBase { }
//        public class ActionId : GuiIdBase { }
//        public class MonitorActionExecutionId : GuiIdBase { }
//        public interface IIsId { }
//        public class GuiIdBase : ValueOf<Guid, GuiIdBase>, IIsId
//        {
//        }
//        public class MonitorId : GuiIdBase { }
//    }


//}

