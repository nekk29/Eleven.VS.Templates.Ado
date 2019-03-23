using Eleven.VS.Templates.Ado.Util;
using Microsoft.VisualStudio.Modeling;

namespace Eleven.VS.Templates.Ado.Dsl.Util
{
    public class GlobalFunctions
    {
        public static string Get_StringId(int NumberId, int Size)
        {
            return NumberId.ToString().PadLeft(Size, char.Parse(GlobalConstants.ValorDefectoCero));
        }

        public static int Get_CountDomainEntityProperties_By_Type(DomainEntity domainEntity, string DomainEntityType, bool IsGeneratedCollection)
        {
            int Count = GlobalConstants.ValorCero;
            LinkedElementCollection<DomainEntityProperty> domainEntityPropertyList = domainEntity.DomainEntityProperties;

            foreach (DomainEntityProperty domainEntityProperty in domainEntityPropertyList)
                if (domainEntityProperty.DomainEntityType == DomainEntityType && domainEntityProperty.IsGeneratedCollection == IsGeneratedCollection)
                    Count += 1;

            return Count;
        }

        public static int Get_Max_IdDomainEntity(DomainEntityModel domainEntityModel)
        {
            int IdDomainEntity = GlobalConstants.ValorCero;
            int IdDomainEntityTst = GlobalConstants.ValorCero;
            int IdDomainEntityMax = GlobalConstants.ValorCero;

            if (domainEntityModel.DomainEntities != null)
            {
                foreach (DomainEntity domainEntity in domainEntityModel.DomainEntities)
                {
                    if (int.TryParse(domainEntity.IdDomainEntity, out IdDomainEntityTst))
                        IdDomainEntity = IdDomainEntityTst;
                    if (IdDomainEntity >= IdDomainEntityMax)
                        IdDomainEntityMax = IdDomainEntity;
                }
            }

            return IdDomainEntityMax;
        }

        public static int Get_Max_IdDomainEntityCollection(DomainEntityModel domainEntityModel)
        {
            int IdDomainEntityCollection = GlobalConstants.ValorCero;
            int IdDomainEntityCollectionTst = GlobalConstants.ValorCero;
            int IdDomainEntityCollectionMax = GlobalConstants.ValorCero;

            if (domainEntityModel.DomainEntities != null)
            {
                foreach (DomainEntityCollection domainEntityCollection in domainEntityModel.DomainEntityCollections)
                {
                    if (int.TryParse(domainEntityCollection.IdDomainEntityCollection, out IdDomainEntityCollectionTst))
                        IdDomainEntityCollection = IdDomainEntityCollectionTst;
                    if (IdDomainEntityCollection >= IdDomainEntityCollectionMax)
                        IdDomainEntityCollectionMax = IdDomainEntityCollection;
                }
            }

            return IdDomainEntityCollectionMax;
        }

        public static int Get_Max_IdDomainEntityProperty(DomainEntity domainEntity)
        {
            string IdDomainEntityPropertyStr;
            int IdDomainEntityProperty = GlobalConstants.ValorCero;
            int IdDomainEntityPropertyTst = GlobalConstants.ValorCero;
            int IdDomainEntityPropertyMax = GlobalConstants.ValorCero;

            if (domainEntity.DomainEntityProperties != null)
            {
                foreach (DomainEntityProperty domainEntityProperty in domainEntity.DomainEntityProperties)
                {
                    IdDomainEntityPropertyStr = domainEntityProperty.IdDomainEntityProperty;

                    if (int.TryParse(IdDomainEntityPropertyStr, out IdDomainEntityPropertyTst))
                        IdDomainEntityPropertyStr = IdDomainEntityPropertyStr.Substring(IdDomainEntityPropertyStr.Length - GlobalConstants.ValorCinco, GlobalConstants.ValorCinco);
                    else
                        IdDomainEntityPropertyStr = GlobalConstants.ValorDefectoCero;

                    if (int.TryParse(IdDomainEntityPropertyStr, out IdDomainEntityPropertyTst))
                        IdDomainEntityProperty = IdDomainEntityPropertyTst;

                    if (IdDomainEntityProperty >= IdDomainEntityPropertyMax)
                        IdDomainEntityPropertyMax = IdDomainEntityProperty;
                }
            }

            return IdDomainEntityPropertyMax;
        }
    }
}
