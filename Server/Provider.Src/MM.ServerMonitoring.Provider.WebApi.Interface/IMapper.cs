namespace MM.ServerMonitoring.Provider.WebApi.Interface;

public interface IMapper<T1, T2>
{
    T2 Map(T1 input, Func<T2> @default = null);
    T1 Map(T2 input, Func<T1> @default = null);
}