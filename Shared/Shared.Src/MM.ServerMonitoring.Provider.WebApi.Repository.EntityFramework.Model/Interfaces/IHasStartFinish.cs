namespace MM.ServerMonitoring.Repository.EntityFramework.Model.Interfaces;

public interface IHasStartFinish
{
    DateTime Start { get; }
    DateTime Finish { get; }
}