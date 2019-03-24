using Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes.Base;
using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;

namespace Eleven.VS.Templates.Ado.Dsl.DomainTypes
{
    public class DomainEntityCollection_CollectionType_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.DomainEntityCollection_CollectionType_List);
                values.Add(Resources.TypeConverters.DomainEntityCollection_CollectionType_ICollection);
                values.Add(Resources.TypeConverters.DomainEntityCollection_CollectionType_Dictionary);
            }

            return new StandardValuesCollection(values);
        }
    }

    public class DomainEntityProperty_CollectionType_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.DomainEntityProperty_CollectionType_None);
                values.Add(Resources.TypeConverters.DomainEntityProperty_CollectionType_List);
                values.Add(Resources.TypeConverters.DomainEntityProperty_CollectionType_ICollection);
                values.Add(Resources.TypeConverters.DomainEntityProperty_CollectionType_Dictionary);
            }

            return new StandardValuesCollection(values);
        }
    }

    public class DomainPrimitiveProperty_CollectionType_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_CollectionType_None);
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_CollectionType_List);
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_CollectionType_ICollection);
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_CollectionType_Dictionary);
            }

            return new StandardValuesCollection(values);
        }
    }
}
