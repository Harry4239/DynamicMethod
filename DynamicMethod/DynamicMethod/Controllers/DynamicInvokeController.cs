using DynamicMethod.Extensions;
using DynamicMethod.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicMethod.Controllers;

[Route("api/[controller]")]
public class DynamicInvokeController : ControllerBase
{
    private readonly DynamicExtension _extension;
    public DynamicInvokeController(DynamicExtension extension)
    {
        this._extension = extension;
    }

    [HttpGet,Route("Invoke")]
    public object Invoke()
    {
        List<MethodParameter> list = new List<MethodParameter>()
        { 
            new MethodParameter()
            {
                ParameterName = "a",
                ParameterType = "System.Int32",
            },
            new MethodParameter()
            {
                ParameterName = "b",
                ParameterType = "System.Int32",
            }
        };
        var returnParameter = new MethodParameter()
        {
            ParameterType = "System.Int32"
        };
        string body = @"return a>b?a:b;";
        
        return _extension.Invoke(list,returnParameter,body,new object[]{1,2});
    }
}