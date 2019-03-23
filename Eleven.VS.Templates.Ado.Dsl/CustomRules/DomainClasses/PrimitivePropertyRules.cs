using Microsoft.VisualStudio.Modeling;

namespace Eleven.VS.Templates.Ado.Dsl.CustomRules.DomainClasses
{
    [RuleOn(typeof(PrimitiveProperty))]
    public class PrimitivePropertyChangeRule : ChangeRule
    {
        private const string PrimitiveProperty_Name = "Name";

        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            switch (e.DomainProperty.Name)
            {
                case PrimitiveProperty_Name:
                    ElementPropertyChanged_Name(e);
                    break;
            }
        }

        public void ElementPropertyChanged_Name(ElementPropertyChangedEventArgs e)
        {
            base.ElementPropertyChanged(e);
            PrimitiveProperty primitiveProperty = e.ModelElement as PrimitiveProperty;
            primitiveProperty.DataAccessColumn = primitiveProperty.Name;
        }
    }
}
