using DynamicMethod.Models;

namespace DynamicMethod.Extensions;

public class DynamicExtension
{
    Dictionary<string,Delegate> FuncCache = new Dictionary<string, Delegate>();
    public object? Invoke(List<MethodParameter> parameters,MethodParameter returnParameters,string body,object[] args)
    {
        var builder = FastMethodOperator.DefaultDomain();
        parameters.ForEach(item =>
        {
            builder.Param(item.Type, item.ParameterName);
        });
        builder.Return(returnParameters.Type);
        builder.Body(body);
        var func = builder.Compile();
        return func.DynamicInvoke(args);
    }

    public void ConfigClass()
    {
        
    }
}