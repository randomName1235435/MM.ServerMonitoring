namespace MM.ServerMonitoring.ActionExecutor.Interface;

public interface IMapper<in TIn, TOut>
{
    TOut Map(TIn input, Func<TOut> @default = null);
}