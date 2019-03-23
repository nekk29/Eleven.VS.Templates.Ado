using Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes.Base;
using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;

namespace Eleven.VS.Templates.Ado.Dsl.CustomCode.DomainTypes
{
    public class DomainEntity_AccessModifier_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.DomainEntity_AccessModifier_public);
                values.Add(Resources.TypeConverters.DomainEntity_AccessModifier_private);
                values.Add(Resources.TypeConverters.DomainEntity_AccessModifier_protected);
                values.Add(Resources.TypeConverters.DomainEntity_AccessModifier_internal);
                values.Add(Resources.TypeConverters.DomainEntity_AccessModifier_protected_internal);
            }

            return new StandardValuesCollection(values);
        }
    }

    public class DomainEntityCollection_AccessModifier_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.DomainEntityCollection_AccessModifier_public);
                values.Add(Resources.TypeConverters.DomainEntityCollection_AccessModifier_private);
                values.Add(Resources.TypeConverters.DomainEntityCollection_AccessModifier_protected);
                values.Add(Resources.TypeConverters.DomainEntityCollection_AccessModifier_internal);
                values.Add(Resources.TypeConverters.DomainEntityCollection_AccessModifier_protected_internal);
            }

            return new StandardValuesCollection(values);
        }
    }

    public class DomainEntityProperty_AccessModifier_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.DomainEntityProperty_AccessModifier_public);
                values.Add(Resources.TypeConverters.DomainEntityProperty_AccessModifier_private);
                values.Add(Resources.TypeConverters.DomainEntityProperty_AccessModifier_protected);
                values.Add(Resources.TypeConverters.DomainEntityProperty_AccessModifier_internal);
            }

            return new StandardValuesCollection(values);
        }
    }

    public class DomainPrimitiveProperty_AccessModifier_TypeConverter : BaseTypeConverter
    {
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {
            List<string> values = new List<string>();
            Store store = GetStore(context.Instance);

            if (store != null)
            {
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_AccessModifier_public);
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_AccessModifier_private);
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_AccessModifier_protected);
                values.Add(Resources.TypeConverters.DomainPrimitiveProperty_AccessModifier_internal);
            }

            return new StandardValuesCollection(values);
        }
    }
}
