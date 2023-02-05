namespace MM.ServerMonitoring.Provider.WebApi.Interface;

public interface IOneWayMapper<T1, T2>
{
    T1 Map(T2 input, Func<T1> @default = null);
}