using Microsoft.VisualStudio.Modeling;
using System.ComponentModel;

namespace Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes.Base
{
    public class BaseTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public Store GetStore(object gridSelection)
        {
            ModelElement currentElement = null;

            if (gridSelection is object[] objects && objects.Length > 0)
                currentElement = objects[0] as ModelElement;
            else
                currentElement = gridSelection as ModelElement;

            return currentElement?.Store;
        }
    }
}
