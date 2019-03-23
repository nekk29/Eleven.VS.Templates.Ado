using Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes.Base;
using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;
using System.Linq;

namespace Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes
{
    public class DomainEntityType_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
                values.AddRange(store.ElementDirectory.FindElements<DomainEntity>().Select(e => { return e.Name; }));

            return new StandardValuesCollection(values);
        }
    }
}
