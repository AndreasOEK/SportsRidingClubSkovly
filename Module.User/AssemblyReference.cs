using System.Reflection;

namespace Module.User
{
    public class AssemblyReference
    {
        public static Assembly Assembly { get; set; } = typeof(AssemblyReference).Assembly;
    }
}
