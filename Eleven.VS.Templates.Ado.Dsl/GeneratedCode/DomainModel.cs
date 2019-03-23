﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
namespace Eleven.VS.Templates.Ado.Dsl
{
	/// <summary>
	/// DomainModel ElevenEntityModelDomainModel
	/// Eleven n-layered domain-oriented architecture project template using DSL tools
	/// and Ado.Net
	/// </summary>
	[DslDesign::DisplayNameResource("Eleven.VS.Templates.Ado.Dsl.ElevenEntityModelDomainModel.DisplayName", typeof(global::Eleven.VS.Templates.Ado.Dsl.ElevenEntityModelDomainModel), "Eleven.VS.Templates.Ado.Dsl.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("Eleven.VS.Templates.Ado.Dsl.ElevenEntityModelDomainModel.Description", typeof(global::Eleven.VS.Templates.Ado.Dsl.ElevenEntityModelDomainModel), "Eleven.VS.Templates.Ado.Dsl.GeneratedCode.DomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.CoreDomainModel))]
	[DslModeling::DependsOnDomainModel(typeof(global::Microsoft.VisualStudio.Modeling.Diagrams.CoreDesignSurfaceDomainModel))]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]
	[DslModeling::DomainObjectId("faa5ea77-a030-43c7-ab71-3c73bfa5300b")]
	public partial class ElevenEntityModelDomainModel : DslModeling::DomainModel
	{
		#region Constructor, domain model Id
	
		/// <summary>
		/// ElevenEntityModelDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new global::System.Guid(0xfaa5ea77, 0xa030, 0x43c7, 0xab, 0x71, 0x3c, 0x73, 0xbf, 0xa5, 0x30, 0x0b);
	
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public ElevenEntityModelDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
			// Call the partial method to allow any required serialization setup to be done.
			this.InitializeSerialization(store);		
		}
		
	
		///<Summary>
		/// Defines a partial method that will be called from the constructor to
		/// allow any necessary serialization setup to be done.
		///</Summary>
		///<remarks>
		/// For a DSL created with the DSL Designer wizard, an implementation of this 
		/// method will be generated in the GeneratedCode\SerializationHelper.cs class.
		///</remarks>
		partial void InitializeSerialization(DslModeling::Store store);
	
	
		#endregion
		#region Domain model reflection
			
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(DomainEntityModel),
				typeof(DomainEntity),
				typeof(DomainEntityProperty),
				typeof(PrimitiveProperty),
				typeof(DomainEntityCollection),
				typeof(DomainEntityHasDomainEntityProperties),
				typeof(DomainEntityHasPrimitiveProperties),
				typeof(DomainEntityModelHasDomainEntities),
				typeof(DomainEntityModelHasDomainEntityCollections),
				typeof(DomainEntityReferencesTargetDomainEntities),
				typeof(DomainEntityReferencesDomainEntityCollections),
				typeof(ElevenEntityModelDiagram),
				typeof(EntityConnector),
				typeof(EntityCollectionConector),
				typeof(EntityCollectionShape),
				typeof(EntityCompartmentShape),
				typeof(global::Eleven.VS.Templates.Ado.Dsl.FixUpDiagram),
				typeof(global::Eleven.VS.Templates.Ado.Dsl.ConnectorRolePlayerChanged),
				typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemAddRule),
				typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemDeleteRule),
				typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemRolePlayerChangeRule),
				typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemRolePlayerPositionChangeRule),
				typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemChangeRule),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(DomainEntityModel), "ProjectImplementationDatabase", DomainEntityModel.ProjectImplementationDatabaseDomainPropertyId, typeof(DomainEntityModel.ProjectImplementationDatabasePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityModel), "ProjectImplementationDataAccess", DomainEntityModel.ProjectImplementationDataAccessDomainPropertyId, typeof(DomainEntityModel.ProjectImplementationDataAccessPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityModel), "ProjectImplementationEntity", DomainEntityModel.ProjectImplementationEntityDomainPropertyId, typeof(DomainEntityModel.ProjectImplementationEntityPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityModel), "ProjectImplementationDomain", DomainEntityModel.ProjectImplementationDomainDomainPropertyId, typeof(DomainEntityModel.ProjectImplementationDomainPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityModel), "ProjectImplementationDataAccessCore", DomainEntityModel.ProjectImplementationDataAccessCoreDomainPropertyId, typeof(DomainEntityModel.ProjectImplementationDataAccessCorePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityModel), "ProjectImplementationWeb", DomainEntityModel.ProjectImplementationWebDomainPropertyId, typeof(DomainEntityModel.ProjectImplementationWebPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntity), "Name", DomainEntity.NameDomainPropertyId, typeof(DomainEntity.NamePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntity), "AccessModifier", DomainEntity.AccessModifierDomainPropertyId, typeof(DomainEntity.AccessModifierPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntity), "DomainModule", DomainEntity.DomainModuleDomainPropertyId, typeof(DomainEntity.DomainModulePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntity), "IsDataAccessMapping", DomainEntity.IsDataAccessMappingDomainPropertyId, typeof(DomainEntity.IsDataAccessMappingPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntity), "DataAccessSchema", DomainEntity.DataAccessSchemaDomainPropertyId, typeof(DomainEntity.DataAccessSchemaPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntity), "DataAccessTable", DomainEntity.DataAccessTableDomainPropertyId, typeof(DomainEntity.DataAccessTablePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntity), "IdDomainEntity", DomainEntity.IdDomainEntityDomainPropertyId, typeof(DomainEntity.IdDomainEntityPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "DomainEntityType", DomainEntityProperty.DomainEntityTypeDomainPropertyId, typeof(DomainEntityProperty.DomainEntityTypePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "Name", DomainEntityProperty.NameDomainPropertyId, typeof(DomainEntityProperty.NamePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "CollectionType", DomainEntityProperty.CollectionTypeDomainPropertyId, typeof(DomainEntityProperty.CollectionTypePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "IsReadOnly", DomainEntityProperty.IsReadOnlyDomainPropertyId, typeof(DomainEntityProperty.IsReadOnlyPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "AccessModifier", DomainEntityProperty.AccessModifierDomainPropertyId, typeof(DomainEntityProperty.AccessModifierPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "IdDomainEntityProperty", DomainEntityProperty.IdDomainEntityPropertyDomainPropertyId, typeof(DomainEntityProperty.IdDomainEntityPropertyPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "IdDomainEntityReferencesTargetDomainEntities", DomainEntityProperty.IdDomainEntityReferencesTargetDomainEntitiesDomainPropertyId, typeof(DomainEntityProperty.IdDomainEntityReferencesTargetDomainEntitiesPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "IdDomainEntity", DomainEntityProperty.IdDomainEntityDomainPropertyId, typeof(DomainEntityProperty.IdDomainEntityPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "IsGeneratedCollection", DomainEntityProperty.IsGeneratedCollectionDomainPropertyId, typeof(DomainEntityProperty.IsGeneratedCollectionPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityProperty), "HasDomainType", DomainEntityProperty.HasDomainTypeDomainPropertyId, typeof(DomainEntityProperty.HasDomainTypePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "AccessModifier", PrimitiveProperty.AccessModifierDomainPropertyId, typeof(PrimitiveProperty.AccessModifierPropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "PrimitiveType", PrimitiveProperty.PrimitiveTypeDomainPropertyId, typeof(PrimitiveProperty.PrimitiveTypePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "Name", PrimitiveProperty.NameDomainPropertyId, typeof(PrimitiveProperty.NamePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "CollectionType", PrimitiveProperty.CollectionTypeDomainPropertyId, typeof(PrimitiveProperty.CollectionTypePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "IsReadOnly", PrimitiveProperty.IsReadOnlyDomainPropertyId, typeof(PrimitiveProperty.IsReadOnlyPropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "IsDataAccessMapping", PrimitiveProperty.IsDataAccessMappingDomainPropertyId, typeof(PrimitiveProperty.IsDataAccessMappingPropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "DataAccessColumn", PrimitiveProperty.DataAccessColumnDomainPropertyId, typeof(PrimitiveProperty.DataAccessColumnPropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "DataAccessType", PrimitiveProperty.DataAccessTypeDomainPropertyId, typeof(PrimitiveProperty.DataAccessTypePropertyHandler)),
				new DomainMemberInfo(typeof(PrimitiveProperty), "IsPrimaryKey", PrimitiveProperty.IsPrimaryKeyDomainPropertyId, typeof(PrimitiveProperty.IsPrimaryKeyPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityCollection), "DomainModule", DomainEntityCollection.DomainModuleDomainPropertyId, typeof(DomainEntityCollection.DomainModulePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityCollection), "AccessModifier", DomainEntityCollection.AccessModifierDomainPropertyId, typeof(DomainEntityCollection.AccessModifierPropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityCollection), "Name", DomainEntityCollection.NameDomainPropertyId, typeof(DomainEntityCollection.NamePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityCollection), "CollectionType", DomainEntityCollection.CollectionTypeDomainPropertyId, typeof(DomainEntityCollection.CollectionTypePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityCollection), "DomainEntityType", DomainEntityCollection.DomainEntityTypeDomainPropertyId, typeof(DomainEntityCollection.DomainEntityTypePropertyHandler)),
				new DomainMemberInfo(typeof(DomainEntityCollection), "IdDomainEntityCollection", DomainEntityCollection.IdDomainEntityCollectionDomainPropertyId, typeof(DomainEntityCollection.IdDomainEntityCollectionPropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(DomainEntityHasDomainEntityProperties), "DomainEntity", DomainEntityHasDomainEntityProperties.DomainEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityHasDomainEntityProperties), "DomainEntityProperty", DomainEntityHasDomainEntityProperties.DomainEntityPropertyDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityHasPrimitiveProperties), "DomainEntity", DomainEntityHasPrimitiveProperties.DomainEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityHasPrimitiveProperties), "PrimitiveProperty", DomainEntityHasPrimitiveProperties.PrimitivePropertyDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityModelHasDomainEntities), "DomainEntityModel", DomainEntityModelHasDomainEntities.DomainEntityModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityModelHasDomainEntities), "DomainEntity", DomainEntityModelHasDomainEntities.DomainEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityModelHasDomainEntityCollections), "DomainEntityModel", DomainEntityModelHasDomainEntityCollections.DomainEntityModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityModelHasDomainEntityCollections), "DomainEntityCollection", DomainEntityModelHasDomainEntityCollections.DomainEntityCollectionDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityReferencesTargetDomainEntities), "SourceDomainEntity", DomainEntityReferencesTargetDomainEntities.SourceDomainEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityReferencesTargetDomainEntities), "TargetDomainEntity", DomainEntityReferencesTargetDomainEntities.TargetDomainEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityReferencesDomainEntityCollections), "DomainEntity", DomainEntityReferencesDomainEntityCollections.DomainEntityDomainRoleId),
				new DomainRolePlayerInfo(typeof(DomainEntityReferencesDomainEntityCollections), "DomainEntityCollection", DomainEntityReferencesDomainEntityCollections.DomainEntityCollectionDomainRoleId),
			};
		}
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;
	
		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Generated code.")]	
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
	
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(10);
				createElementMap.Add(typeof(DomainEntityModel), 0);
				createElementMap.Add(typeof(DomainEntity), 1);
				createElementMap.Add(typeof(DomainEntityProperty), 2);
				createElementMap.Add(typeof(PrimitiveProperty), 3);
				createElementMap.Add(typeof(DomainEntityCollection), 4);
				createElementMap.Add(typeof(ElevenEntityModelDiagram), 5);
				createElementMap.Add(typeof(EntityConnector), 6);
				createElementMap.Add(typeof(EntityCollectionConector), 7);
				createElementMap.Add(typeof(EntityCollectionShape), 8);
				createElementMap.Add(typeof(EntityCompartmentShape), 9);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				// construct exception error message		
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Eleven.VS.Templates.Ado.Dsl.ElevenEntityModelDomainModel.SingletonResourceManager.GetString("UnrecognizedElementType"),
								elementType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementType");
			}
			switch (index)
			{
				case 0: return new DomainEntityModel(partition, propertyAssignments);
				case 1: return new DomainEntity(partition, propertyAssignments);
				case 2: return new DomainEntityProperty(partition, propertyAssignments);
				case 3: return new PrimitiveProperty(partition, propertyAssignments);
				case 4: return new DomainEntityCollection(partition, propertyAssignments);
				case 5: return new ElevenEntityModelDiagram(partition, propertyAssignments);
				case 6: return new EntityConnector(partition, propertyAssignments);
				case 7: return new EntityCollectionConector(partition, propertyAssignments);
				case 8: return new EntityCollectionShape(partition, propertyAssignments);
				case 9: return new EntityCompartmentShape(partition, propertyAssignments);
				default: return null;
			}
		}
	
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;
	
		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementLinkType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
	
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(6);
				createElementLinkMap.Add(typeof(DomainEntityHasDomainEntityProperties), 0);
				createElementLinkMap.Add(typeof(DomainEntityHasPrimitiveProperties), 1);
				createElementLinkMap.Add(typeof(DomainEntityModelHasDomainEntities), 2);
				createElementLinkMap.Add(typeof(DomainEntityModelHasDomainEntityCollections), 3);
				createElementLinkMap.Add(typeof(DomainEntityReferencesTargetDomainEntities), 4);
				createElementLinkMap.Add(typeof(DomainEntityReferencesDomainEntityCollections), 5);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				// construct exception error message
				string exceptionError = string.Format(
								global::System.Globalization.CultureInfo.CurrentCulture,
								global::Eleven.VS.Templates.Ado.Dsl.ElevenEntityModelDomainModel.SingletonResourceManager.GetString("UnrecognizedElementLinkType"),
								elementLinkType.Name);
				throw new global::System.ArgumentException(exceptionError, "elementLinkType");
			
			}
			switch (index)
			{
				case 0: return new DomainEntityHasDomainEntityProperties(partition, roleAssignments, propertyAssignments);
				case 1: return new DomainEntityHasPrimitiveProperties(partition, roleAssignments, propertyAssignments);
				case 2: return new DomainEntityModelHasDomainEntities(partition, roleAssignments, propertyAssignments);
				case 3: return new DomainEntityModelHasDomainEntityCollections(partition, roleAssignments, propertyAssignments);
				case 4: return new DomainEntityReferencesTargetDomainEntities(partition, roleAssignments, propertyAssignments);
				case 5: return new DomainEntityReferencesDomainEntityCollections(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion
		#region Resource manager
		
		private static global::System.Resources.ResourceManager resourceManager;
		
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Eleven.VS.Templates.Ado.Dsl.GeneratedCode.DomainModelResx";
		
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return ElevenEntityModelDomainModel.SingletonResourceManager;
			}
		}
	
		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (ElevenEntityModelDomainModel.resourceManager == null)
				{
					ElevenEntityModelDomainModel.resourceManager = new global::System.Resources.ResourceManager(ResourceBaseName, typeof(ElevenEntityModelDomainModel).Assembly);
				}
				return ElevenEntityModelDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return ElevenEntityModelDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return ElevenEntityModelDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (ElevenEntityModelDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new ElevenEntityModelCopyClosure());
					copyFilter.AddFilter(new DslModeling::CoreCopyClosure());
					copyFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceCopyClosure());
					
					ElevenEntityModelDomainModel.copyClosure = copyFilter;
				}
				return ElevenEntityModelDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (ElevenEntityModelDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new ElevenEntityModelDeleteClosure());
					removeFilter.AddFilter(new DslModeling::CoreDeleteClosure());
					removeFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceDeleteClosure());
		
					ElevenEntityModelDomainModel.removeClosure = removeFilter;
				}
				return ElevenEntityModelDomainModel.removeClosure;
			}
		}
		#endregion
		#region Diagram rule helpers
		/// <summary>
		/// Enables rules in this domain model related to diagram fixup for the given store.
		/// If diagram data will be loaded into the store, this method should be called first to ensure
		/// that the diagram behaves properly.
		/// </summary>
		public static void EnableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.EnableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.FixUpDiagram));
			ruleManager.EnableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.ConnectorRolePlayerChanged));
			ruleManager.EnableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemAddRule));
			ruleManager.EnableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemDeleteRule));
			ruleManager.EnableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemRolePlayerChangeRule));
			ruleManager.EnableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemRolePlayerPositionChangeRule));
			ruleManager.EnableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemChangeRule));
		}
		
		/// <summary>
		/// Disables rules in this domain model related to diagram fixup for the given store.
		/// </summary>
		public static void DisableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.DisableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.FixUpDiagram));
			ruleManager.DisableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.ConnectorRolePlayerChanged));
			ruleManager.DisableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemAddRule));
			ruleManager.DisableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemDeleteRule));
			ruleManager.DisableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemRolePlayerChangeRule));
			ruleManager.DisableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemRolePlayerPositionChangeRule));
			ruleManager.DisableRule(typeof(global::Eleven.VS.Templates.Ado.Dsl.CompartmentItemChangeRule));
		}
		#endregion
	}
		
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ElevenEntityModelDeleteClosure : ElevenEntityModelDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ElevenEntityModelDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ElevenEntityModelDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public ElevenEntityModelDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Eleven.VS.Templates.Ado.Dsl.DomainEntityHasDomainEntityProperties.DomainEntityPropertyDomainRoleId, true);
			DomainRoles.Add(global::Eleven.VS.Templates.Ado.Dsl.DomainEntityHasPrimitiveProperties.PrimitivePropertyDomainRoleId, true);
			DomainRoles.Add(global::Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntities.DomainEntityDomainRoleId, true);
			DomainRoles.Add(global::Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntityCollections.DomainEntityCollectionDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			if (targetDomainRole == null) throw new global::System.ArgumentNullException("targetDomainRole");
			return this.DomainRoles.Contains(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Specialized.HybridDictionary DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Specialized.HybridDictionary();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ElevenEntityModelCopyClosure : ElevenEntityModelCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ElevenEntityModelCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ElevenEntityModelCopyClosureBase : DslModeling::CopyClosureFilter, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ElevenEntityModelCopyClosureBase():base()
		{
		}
	}
	#endregion
		
}
