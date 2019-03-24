using Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes.Base;
using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;

namespace Eleven.VS.Templates.Ado.Dsl.DomainTypes
{
    public class PrimitivePropertySystemType_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Boolean);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Byte);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Char);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_DateTime);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Decimal);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Double);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Guid);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Int16);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Int32);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Int64);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_SByte);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_Single);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_String);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_UInt16);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_UInt32);
                values.Add(Resources.TypeConverters.PrimitivePropertySystemType_UInt64);
            }

            return new StandardValuesCollection(values);
        }
    }
}
