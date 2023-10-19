namespace DynamicMethod.Models;

public class MethodParameter
{
    public string ParameterType { set; get; }

    public string ParameterName { set; get; }
    
    public Type Type {
        get
        {
            return Type.GetType(ParameterType);
        }
    }
}