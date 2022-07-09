using System.Reflection;
using System.Text;

namespace EnvironmentVariables
{
    /// <summary>
    /// Automatically maps environment variables to public properties in a derived class
    /// </summary>
    public abstract class EnvironmentVariables
    {
        public virtual void Init()
        {
            Parse();
        }

        public override string ToString()
        {
            PropertyInfo[] envVars = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<string> list = new();
            foreach (var envVar in envVars)
            {
                list.Add($"{envVar.Name}={envVar.GetValue(this)}");
            }

            return string.Join(", ", list);
        }

        private void Parse()
        {
            PropertyInfo[] envVars = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var envVar in envVars)
            {
                string? value = Environment.GetEnvironmentVariable(envVar.Name);
                if (value is not null)
                {
                    envVar.SetValue(this, value);
                }
            }
        }
    }
}