using System;
using System.Linq;
using System.Reflection;

using LoggerExercise.Common;
using LoggerExercise.Models.Contracts;

namespace LoggerExercise.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {

        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(layoutTypeStr,
                StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException(GlobalConstants.InvalidLayoutType);
            }

            object[] ctorArgs = new object[] { };

            ILayout layout = (ILayout) Activator.CreateInstance(layoutType, ctorArgs);

            return layout;
        }
    }
}
