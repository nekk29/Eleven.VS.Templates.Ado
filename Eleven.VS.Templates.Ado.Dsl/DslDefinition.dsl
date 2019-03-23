<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="faa5ea77-a030-43c7-ab71-3c73bfa5300b" Description="Eleven n-layered domain-oriented architecture project template using DSL tools and Ado.Net" Name="ElevenEntityModel" DisplayName="Eleven.VS.Templates.Ado.Package" Namespace="Eleven.VS.Templates.Ado.Dsl" ProductName="Eleven Entity Model" CompanyName="Eleven" PackageGuid="1fd0aa89-51da-4597-8e90-29b3e14673d2" PackageNamespace="Eleven.VS.Templates.Ado.Dsl" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="a3819a4d-3730-41cc-9ad8-a80ef0abcbf5" Description="Root element for entity model." Name="DomainEntityModel" DisplayName="Domain Entity Model" Namespace="Eleven.VS.Templates.Ado.Dsl">
      <Properties>
        <DomainProperty Id="9a369c21-3a99-4e38-9cf6-e9d8abd3719a" Description="Especify the project to implement the database model." Name="ProjectImplementationDatabase" DisplayName="Project Implementation Database" Category="Database">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.ProjectImplementation_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b6cbba90-90c0-4d28-a027-d5cfbc2d25af" Description="Especify the project to implement the data access objects." Name="ProjectImplementationDataAccess" DisplayName="Project Implementation Data Access" Category="Repository &amp; Data Access">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.ProjectImplementation_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="4d690601-4bfd-4fc7-ae22-f3bb5888415f" Description="Especify the project to implement the entity objects." Name="ProjectImplementationEntity" DisplayName="Project Implementation Entity" Category="Domain">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.ProjectImplementation_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c8619d45-43a7-4932-8ab2-c3ea33d70dc1" Description="Especify the project to implement the domain core objects." Name="ProjectImplementationDomain" DisplayName="Project Implementation Domain" Category="Domain">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.ProjectImplementation_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="69430aa1-bd66-4871-bbbd-b814d0d5a17a" Description="Especify the project to implement the cross cutting objects." Name="ProjectImplementationDataAccessCore" DisplayName="Project Implementation Data Access Core" Category="Repository &amp; Data Access">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.ProjectImplementation_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="47d2c66f-8f65-4a92-973d-61d56fbd1be4" Description="Especify the project to implement the web objects." Name="ProjectImplementationWeb" DisplayName="Project Implementation Web" Category="Presentation">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.ProjectImplementation_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainEntity" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainEntityModelHasDomainEntities.DomainEntities</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainEntityCollection" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainEntityModelHasDomainEntityCollections.DomainEntityCollections</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="296a1f38-1bb6-49bc-87d9-f6610808f0de" Description="Represents a entity of the model." Name="DomainEntity" DisplayName="Domain Entity" Namespace="Eleven.VS.Templates.Ado.Dsl">
      <Properties>
        <DomainProperty Id="813b9efe-841d-4577-aca8-8f7ef501ea83" Description="Name of the domain entity." Name="Name" DisplayName="Name" DefaultValue="" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="e5962f0d-5d0c-46b1-b3c1-55324accc4f6" Description="Access modifier of the domain entity." Name="AccessModifier" DisplayName="Access Modifier" DefaultValue="public" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainEntity_AccessModifier_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ebfed910-f1a8-490e-89c2-e00cf21473d1" Description="Domain module name of the domain entity." Name="DomainModule" DisplayName="Domain Module" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7bd9f3e6-6b13-4f07-80ae-9c81b5dd9afb" Description="Especify if the domain entity is mapping with a table in the database." Name="IsDataAccessMapping" DisplayName="Is Data Access Mapping" DefaultValue="true" Category="Data Access">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b0a185ce-2ffd-459a-9f31-2926340cf86b" Description="Name of the mapping table schema for the domain entity in the database." Name="DataAccessSchema" DisplayName="Data Access Schema" DefaultValue="dbo" Category="Data Access">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="3c244946-70e0-40a8-9959-9eeb1352c2a5" Description="Name of the mapping table for domain entity in the database." Name="DataAccessTable" DisplayName="Data Access Table" Category="Data Access" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="317a8bf7-25f4-4415-9cd0-328dd08f966d" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntity.Id Domain Entity" Name="IdDomainEntity" DisplayName="Id Domain Entity" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="DomainEntityProperty" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainEntityHasDomainEntityProperties.DomainEntityProperties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="PrimitiveProperty" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>DomainEntityHasPrimitiveProperties.PrimitiveProperties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="68b8fe18-3969-42a2-90c3-07be2a271782" Description="Represents a domain entity property in the domain entity." Name="DomainEntityProperty" DisplayName="Domain Entity Property" Namespace="Eleven.VS.Templates.Ado.Dsl">
      <Properties>
        <DomainProperty Id="c8fe25a7-31b2-4705-92b3-0ee249bf45fa" Description="Domain entity type of the domain entity property." Name="DomainEntityType" DisplayName="Domain Entity Type" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainEntityType_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="7f22b108-ae3c-4cd3-bef0-7025678e44b4" Description="Name of the domain entity property." Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d527fcd9-9808-4aad-814f-8d3aa7a6b9c2" Description="Collection type of the domain entity property." Name="CollectionType" DisplayName="Collection Type" DefaultValue="(none)" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainEntityProperty_CollectionType_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="db7750ac-1971-4714-9e44-ae5ee49df373" Description="Especify if the domain entity property is read only." Name="IsReadOnly" DisplayName="Is Read Only" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="b9698e0c-4116-4ae9-9a21-174c78a42a7d" Description="Access modifier of the domain entity property." Name="AccessModifier" DisplayName="Access Modifier" DefaultValue="public" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainEntityProperty_AccessModifier_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2e2af013-e662-40ea-9788-0f9d5c605993" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityProperty.Id Domain Entity Property" Name="IdDomainEntityProperty" DisplayName="Id Domain Entity Property" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="06103cf2-8372-4a2e-af0f-c927b57269dc" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityProperty.Id Domain Entity References Target Domain Entities" Name="IdDomainEntityReferencesTargetDomainEntities" DisplayName="Id Domain Entity References Target Domain Entities" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="47b89539-1f02-4e2c-ae63-7c5af5e46fcc" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityProperty.Id Domain Entity" Name="IdDomainEntity" DisplayName="Id Domain Entity" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="44f856f6-855b-4061-a0b4-20c887ac1033" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityProperty.Is Generated Collection" Name="IsGeneratedCollection" DisplayName="Is Generated Collection" DefaultValue="false" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="c2315ba7-ca91-4731-83e0-ec7925f4522f" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityProperty.Has Domain Type" Name="HasDomainType" DisplayName="Has Domain Type" DefaultValue="false" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="81166c75-9748-4996-a799-cf945b3321d8" Description="Represents a primitive property in the domain entity." Name="PrimitiveProperty" DisplayName="Primitive Property" Namespace="Eleven.VS.Templates.Ado.Dsl">
      <Properties>
        <DomainProperty Id="2930964e-acbb-4577-8378-121f40071d1d" Description="Access modifier of the primitive property." Name="AccessModifier" DisplayName="Access Modifier" DefaultValue="public" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainPrimitiveProperty_AccessModifier_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="2c35e8c4-9590-467e-a430-97e2081b2e19" Description="The primitive type of the primitive property." Name="PrimitiveType" DisplayName="Primitive Type" DefaultValue="System.String" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.PrimitivePropertySystemType_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="586740d9-771d-491f-89fd-a5b8135beff3" Description="Name of the primitive property." Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="06801040-1196-42c7-84e6-69a3e9021105" Description="Collection type of the primitive property." Name="CollectionType" DisplayName="Collection Type" DefaultValue="(none)" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainPrimitiveProperty_CollectionType_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="ff3f60bd-ea60-4788-8453-d1f502dc4439" Description="Especify if the primitive property is read only." Name="IsReadOnly" DisplayName="Is Read Only" DefaultValue="false" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="827e37b6-5576-4d58-8b1a-9aae862e6d21" Description="Especify if the primitive property is mapping with a column table in the database." Name="IsDataAccessMapping" DisplayName="Is Data Access Mapping" DefaultValue="true" Category="Data Access">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d8768b98-550a-424e-a695-bd416f059577" Description="Name of the mapping column table for the primitive property in the database." Name="DataAccessColumn" DisplayName="Data Access Column" Category="Data Access" IsUIReadOnly="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="afe6f0cd-f088-48c2-bcca-6b3036292a83" Description="Data type of the mapping column table for the primitive property in the database." Name="DataAccessType" DisplayName="Data Access Type" DefaultValue="varchar(25)" Category="Data Access">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="23d2d6a9-7ace-4275-8316-00c5ca868539" Description="Indicate if the the mapping column table for the primitive property in the database is the primary key." Name="IsPrimaryKey" DisplayName="Is Primary Key" DefaultValue="false" Category="Data Access">
          <Type>
            <ExternalTypeMoniker Name="/System/Boolean" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
    <DomainClass Id="055df133-310d-49c1-add5-1a9f01013fac" Description="Represents a entity collection in the model." Name="DomainEntityCollection" DisplayName="Domain Entity Collection" Namespace="Eleven.VS.Templates.Ado.Dsl">
      <Properties>
        <DomainProperty Id="cf10e872-f458-4760-a884-a3e10ea51750" Description="Domain module name of the entity collection." Name="DomainModule" DisplayName="Domain Module" Category="Definition">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d9510a5f-11d0-45bf-ac04-2c059a6f7698" Description="Access modifier of the domain entity collection." Name="AccessModifier" DisplayName="Access Modifier" DefaultValue="public" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainEntityCollection_AccessModifier_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="0d7a178a-c9cb-4dac-a501-b5d492479c5f" Description="Name of the domain entity collection." Name="Name" DisplayName="Name" Category="Definition" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="21cd8b6a-768b-4eb3-a1ce-9c41c5039814" Description="Collection type of the domain entity collection." Name="CollectionType" DisplayName="Collection Type" DefaultValue="System.Collections.Generic.List&lt;T&gt;" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainEntityCollection_CollectionType_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d0c21d4a-d742-43d2-bf4f-a5d063afaf2e" Description="Domain entity type of the domain entity collection." Name="DomainEntityType" DisplayName="Domain Entity Type" Category="Definition">
          <Attributes>
            <ClrAttribute Name="System.ComponentModel.TypeConverter">
              <Parameters>
                <AttributeParameter Value="&quot;Eleven.VS.Templates.Ado.Dsl.DomainTypes.DomainEntityType_TypeConverter&quot;" />
              </Parameters>
            </ClrAttribute>
          </Attributes>
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="389c93d2-0f00-440e-b577-4346dbe1bffb" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityCollection.Id Domain Entity Collection" Name="IdDomainEntityCollection" DisplayName="Id Domain Entity Collection" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="d4da731a-9e2d-41ce-8fe6-bb5ab76812cf" Description="Embedding relationship between the Entity and EntityProperty" Name="DomainEntityHasDomainEntityProperties" DisplayName="Domain Entity Has Domain Entity Properties" Namespace="Eleven.VS.Templates.Ado.Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="dc6d2856-32c6-4607-be05-d21bf32b7640" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityHasDomainEntityProperties.DomainEntity" Name="DomainEntity" DisplayName="Domain Entity" PropertyName="DomainEntityProperties" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Domain Entity Properties">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4a823774-301f-455e-9d87-6a4b31d94dd1" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityHasDomainEntityProperties.DomainEntityProperty" Name="DomainEntityProperty" DisplayName="Domain Entity Property" PropertyName="DomainEntity" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Domain Entity">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntityProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="184a183b-3a27-4fac-9390-8331728e889f" Description="Embedding relationship between the Entity and PrimitiveProperty" Name="DomainEntityHasPrimitiveProperties" DisplayName="Domain Entity Has Primitive Properties" Namespace="Eleven.VS.Templates.Ado.Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="06a98e73-be7a-4ced-bb50-4a05484d7087" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityHasPrimitiveProperties.DomainEntity" Name="DomainEntity" DisplayName="Domain Entity" PropertyName="PrimitiveProperties" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Primitive Properties">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="90d3a0c5-4edc-43e4-b859-bb2a487c765b" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityHasPrimitiveProperties.PrimitiveProperty" Name="PrimitiveProperty" DisplayName="Primitive Property" PropertyName="DomainEntity" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Domain Entity">
          <RolePlayer>
            <DomainClassMoniker Name="PrimitiveProperty" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="76ba6679-27e3-4f6a-9e94-a2dc8bbc6f08" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntities" Name="DomainEntityModelHasDomainEntities" DisplayName="Domain Entity Model Has Domain Entities" Namespace="Eleven.VS.Templates.Ado.Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="0ecbca83-ec96-45da-93c5-7697415244b1" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntities.DomainEntityModel" Name="DomainEntityModel" DisplayName="Domain Entity Model" PropertyName="DomainEntities" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Domain Entities">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntityModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="49d808ae-04e5-431f-8dab-7899db7999b3" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntities.DomainEntity" Name="DomainEntity" DisplayName="Domain Entity" PropertyName="DomainEntityModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Domain Entity Model">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="ee0dd9de-3cfc-4e67-8a9c-aca01fdec3dc" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntityCollections" Name="DomainEntityModelHasDomainEntityCollections" DisplayName="Domain Entity Model Has Domain Entity Collections" Namespace="Eleven.VS.Templates.Ado.Dsl" IsEmbedding="true">
      <Source>
        <DomainRole Id="ff61d8a9-637e-482f-b105-a0f2b9d19673" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntityCollections.DomainEntityModel" Name="DomainEntityModel" DisplayName="Domain Entity Model" PropertyName="DomainEntityCollections" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Domain Entity Collections">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntityModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="9ef35a72-0fe3-4139-8d34-533f42564c3a" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityModelHasDomainEntityCollections.DomainEntityCollection" Name="DomainEntityCollection" DisplayName="Domain Entity Collection" PropertyName="DomainEntityModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Domain Entity Model">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntityCollection" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="8b8ef15d-4284-446f-a59c-d32cf4d20468" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityReferencesTargetDomainEntities" Name="DomainEntityReferencesTargetDomainEntities" DisplayName="Domain Entity References Target Domain Entities" Namespace="Eleven.VS.Templates.Ado.Dsl" AllowsDuplicates="true">
      <Source>
        <DomainRole Id="3ae311de-9737-422e-bc71-3b74fcc86ccd" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityReferencesTargetDomainEntities.SourceDomainEntity" Name="SourceDomainEntity" DisplayName="Source Domain Entity" PropertyName="TargetDomainEntities" PropertyDisplayName="Target Domain Entities">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="51296278-b4d7-4579-b22f-e542a515ee94" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityReferencesTargetDomainEntities.TargetDomainEntity" Name="TargetDomainEntity" DisplayName="Target Domain Entity" PropertyName="SourceDomainEntities" PropertyDisplayName="Source Domain Entities">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="29f6c5a3-5f83-4661-8437-fab3825d8d7f" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityReferencesDomainEntityCollections" Name="DomainEntityReferencesDomainEntityCollections" DisplayName="Domain Entity References Domain Entity Collections" Namespace="Eleven.VS.Templates.Ado.Dsl">
      <Source>
        <DomainRole Id="43a50fc8-6f50-4ec3-8636-3d2d3aaa0582" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityReferencesDomainEntityCollections.DomainEntity" Name="DomainEntity" DisplayName="Domain Entity" PropertyName="DomainEntityCollections" PropertyDisplayName="Domain Entity Collections">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="c90a317e-af12-4017-bacc-a2f02f35190d" Description="Description for Eleven.VS.Templates.Ado.Dsl.DomainEntityReferencesDomainEntityCollections.DomainEntityCollection" Name="DomainEntityCollection" DisplayName="Domain Entity Collection" PropertyName="DomainEntity" Multiplicity="One" IsPropertyBrowsable="false" PropertyDisplayName="Domain Entity">
          <RolePlayer>
            <DomainClassMoniker Name="DomainEntityCollection" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
  </Types>
  <Shapes>
    <CompartmentShape Id="86854d02-4f4f-4e7c-baa0-799cdc228934" Description="Description for Eleven.VS.Templates.Ado.Dsl.EntityCompartmentShape" Name="EntityCompartmentShape" DisplayName="Entity Compartment Shape" Namespace="Eleven.VS.Templates.Ado.Dsl" FixedTooltipText="Entity Compartment Shape" FillColor="206, 236, 245" OutlineColor="4, 95, 180" InitialWidth="2" InitialHeight="0.3" OutlineThickness="0.01" FillGradientMode="Vertical" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="IconDecorator" DisplayName="Icon Decorator" DefaultIcon="Resources\Images\DomainEntity.bmp" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="TextDecorator" DisplayName="Text Decorator" DefaultText="TextDecorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapseDecorator" DisplayName="Expand Collapse Decorator" />
      </ShapeHasDecorators>
      <Compartment FillColor="206, 236, 245" TitleFillColor="186, 216, 225" Name="PrimitiveProperties" Title="Primitive Properties" />
      <Compartment FillColor="206, 236, 245" TitleFillColor="186, 216, 225" Name="EntityProperties" Title="Entity Properties" />
    </CompartmentShape>
    <GeometryShape Id="a31ed8e3-82f2-4226-b623-31a35821491f" Description="Description for Eleven.VS.Templates.Ado.Dsl.EntityCollectionShape" Name="EntityCollectionShape" DisplayName="Entity Collection Shape" Namespace="Eleven.VS.Templates.Ado.Dsl" FixedTooltipText="Entity Collection Shape" FillColor="206, 236, 245" OutlineColor="4, 95, 180" InitialWidth="2" InitialHeight="0.5" OutlineThickness="0.01" FillGradientMode="Vertical" Geometry="Rectangle">
      <ShapeHasDecorators Position="InnerTopLeft" HorizontalOffset="0" VerticalOffset="0">
        <IconDecorator Name="IconDecorator" DisplayName="Icon Decorator" DefaultIcon="Resources\Images\DomainEntityCollection.bmp" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="TextDecorator" DisplayName="Text Decorator" DefaultText="TextDecorator" />
      </ShapeHasDecorators>
    </GeometryShape>
  </Shapes>
  <Connectors>
    <Connector Id="f98be959-188e-43e7-8ca1-bc7464f7c645" Description="Connector between the ExampleShapes. Represents ExampleRelationships on the Diagram." Name="EntityConnector" DisplayName="Entity Connector" Namespace="Eleven.VS.Templates.Ado.Dsl" FixedTooltipText="Entity Connector" Color="4, 95, 180" TargetEndStyle="EmptyDiamond" Thickness="0.01" />
    <Connector Id="94947cd4-a947-4176-abbe-cdbf9adc1486" Description="Description for Eleven.VS.Templates.Ado.Dsl.EntityCollectionConector" Name="EntityCollectionConector" DisplayName="Entity Collection Conector" Namespace="Eleven.VS.Templates.Ado.Dsl" FixedTooltipText="Entity Collection Conector" Color="4, 95, 180" TargetEndStyle="EmptyArrow" Thickness="0.01" />
  </Connectors>
  <XmlSerializationBehavior Name="ElevenEntityModelSerializationBehavior" Namespace="Eleven.VS.Templates.Ado.Dsl">
    <ClassData>
      <XmlClassData TypeName="DomainEntityModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityModelMoniker" ElementName="domainEntityModel" MonikerTypeName="DomainEntityModelMoniker">
        <DomainClassMoniker Name="DomainEntityModel" />
        <ElementData>
          <XmlPropertyData XmlName="projectImplementationDatabase">
            <DomainPropertyMoniker Name="DomainEntityModel/ProjectImplementationDatabase" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="projectImplementationDataAccess">
            <DomainPropertyMoniker Name="DomainEntityModel/ProjectImplementationDataAccess" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="projectImplementationEntity">
            <DomainPropertyMoniker Name="DomainEntityModel/ProjectImplementationEntity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="projectImplementationDomain">
            <DomainPropertyMoniker Name="DomainEntityModel/ProjectImplementationDomain" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="projectImplementationDataAccessCore">
            <DomainPropertyMoniker Name="DomainEntityModel/ProjectImplementationDataAccessCore" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="projectImplementationWeb">
            <DomainPropertyMoniker Name="DomainEntityModel/ProjectImplementationWeb" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainEntities">
            <DomainRelationshipMoniker Name="DomainEntityModelHasDomainEntities" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainEntityCollections">
            <DomainRelationshipMoniker Name="DomainEntityModelHasDomainEntityCollections" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainEntity" MonikerAttributeName="name" SerializeId="true" MonikerElementName="domainEntityMoniker" ElementName="domainEntity" MonikerTypeName="DomainEntityMoniker">
        <DomainClassMoniker Name="DomainEntity" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="DomainEntity/Name" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainEntityProperties">
            <DomainRelationshipMoniker Name="DomainEntityHasDomainEntityProperties" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="primitiveProperties">
            <DomainRelationshipMoniker Name="DomainEntityHasPrimitiveProperties" />
          </XmlRelationshipData>
          <XmlPropertyData XmlName="accessModifier">
            <DomainPropertyMoniker Name="DomainEntity/AccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="domainModule">
            <DomainPropertyMoniker Name="DomainEntity/DomainModule" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isDataAccessMapping">
            <DomainPropertyMoniker Name="DomainEntity/IsDataAccessMapping" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dataAccessSchema">
            <DomainPropertyMoniker Name="DomainEntity/DataAccessSchema" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dataAccessTable">
            <DomainPropertyMoniker Name="DomainEntity/DataAccessTable" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="idDomainEntity">
            <DomainPropertyMoniker Name="DomainEntity/IdDomainEntity" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="targetDomainEntities">
            <DomainRelationshipMoniker Name="DomainEntityReferencesTargetDomainEntities" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="domainEntityCollections">
            <DomainRelationshipMoniker Name="DomainEntityReferencesDomainEntityCollections" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EntityConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityConnectorMoniker" ElementName="entityConnector" MonikerTypeName="EntityConnectorMoniker">
        <ConnectorMoniker Name="EntityConnector" />
      </XmlClassData>
      <XmlClassData TypeName="ElevenEntityModelDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="ElevenEntityModelDiagramMoniker" ElementName="ElevenEntityModelDiagram" MonikerTypeName="ElevenEntityModelDiagramMoniker">
        <DiagramMoniker Name="ElevenEntityModelDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityPropertyMoniker" ElementName="domainEntityProperty" MonikerTypeName="DomainEntityPropertyMoniker">
        <DomainClassMoniker Name="DomainEntityProperty" />
        <ElementData>
          <XmlPropertyData XmlName="domainEntityType">
            <DomainPropertyMoniker Name="DomainEntityProperty/DomainEntityType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="DomainEntityProperty/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="collectionType">
            <DomainPropertyMoniker Name="DomainEntityProperty/CollectionType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isReadOnly">
            <DomainPropertyMoniker Name="DomainEntityProperty/IsReadOnly" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="accessModifier">
            <DomainPropertyMoniker Name="DomainEntityProperty/AccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="idDomainEntityProperty">
            <DomainPropertyMoniker Name="DomainEntityProperty/IdDomainEntityProperty" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="idDomainEntityReferencesTargetDomainEntities">
            <DomainPropertyMoniker Name="DomainEntityProperty/IdDomainEntityReferencesTargetDomainEntities" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="idDomainEntity">
            <DomainPropertyMoniker Name="DomainEntityProperty/IdDomainEntity" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isGeneratedCollection">
            <DomainPropertyMoniker Name="DomainEntityProperty/IsGeneratedCollection" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="hasDomainType">
            <DomainPropertyMoniker Name="DomainEntityProperty/HasDomainType" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="PrimitiveProperty" MonikerAttributeName="" SerializeId="true" MonikerElementName="primitivePropertyMoniker" ElementName="primitiveProperty" MonikerTypeName="PrimitivePropertyMoniker">
        <DomainClassMoniker Name="PrimitiveProperty" />
        <ElementData>
          <XmlPropertyData XmlName="accessModifier">
            <DomainPropertyMoniker Name="PrimitiveProperty/AccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="primitiveType">
            <DomainPropertyMoniker Name="PrimitiveProperty/PrimitiveType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="PrimitiveProperty/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="collectionType">
            <DomainPropertyMoniker Name="PrimitiveProperty/CollectionType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isReadOnly">
            <DomainPropertyMoniker Name="PrimitiveProperty/IsReadOnly" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isDataAccessMapping">
            <DomainPropertyMoniker Name="PrimitiveProperty/IsDataAccessMapping" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dataAccessColumn">
            <DomainPropertyMoniker Name="PrimitiveProperty/DataAccessColumn" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="dataAccessType">
            <DomainPropertyMoniker Name="PrimitiveProperty/DataAccessType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="isPrimaryKey">
            <DomainPropertyMoniker Name="PrimitiveProperty/IsPrimaryKey" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityHasDomainEntityProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityHasDomainEntityPropertiesMoniker" ElementName="domainEntityHasDomainEntityProperties" MonikerTypeName="DomainEntityHasDomainEntityPropertiesMoniker">
        <DomainRelationshipMoniker Name="DomainEntityHasDomainEntityProperties" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityHasPrimitiveProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityHasPrimitivePropertiesMoniker" ElementName="domainEntityHasPrimitiveProperties" MonikerTypeName="DomainEntityHasPrimitivePropertiesMoniker">
        <DomainRelationshipMoniker Name="DomainEntityHasPrimitiveProperties" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityCollection" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityCollectionMoniker" ElementName="domainEntityCollection" MonikerTypeName="DomainEntityCollectionMoniker">
        <DomainClassMoniker Name="DomainEntityCollection" />
        <ElementData>
          <XmlPropertyData XmlName="domainModule">
            <DomainPropertyMoniker Name="DomainEntityCollection/DomainModule" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="accessModifier">
            <DomainPropertyMoniker Name="DomainEntityCollection/AccessModifier" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="name">
            <DomainPropertyMoniker Name="DomainEntityCollection/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="collectionType">
            <DomainPropertyMoniker Name="DomainEntityCollection/CollectionType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="domainEntityType">
            <DomainPropertyMoniker Name="DomainEntityCollection/DomainEntityType" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="idDomainEntityCollection">
            <DomainPropertyMoniker Name="DomainEntityCollection/IdDomainEntityCollection" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="EntityCompartmentShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityCompartmentShapeMoniker" ElementName="entityCompartmentShape" MonikerTypeName="EntityCompartmentShapeMoniker">
        <CompartmentShapeMoniker Name="EntityCompartmentShape" />
      </XmlClassData>
      <XmlClassData TypeName="EntityCollectionConector" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityCollectionConectorMoniker" ElementName="entityCollectionConector" MonikerTypeName="EntityCollectionConectorMoniker">
        <ConnectorMoniker Name="EntityCollectionConector" />
      </XmlClassData>
      <XmlClassData TypeName="EntityCollectionShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityCollectionShapeMoniker" ElementName="entityCollectionShape" MonikerTypeName="EntityCollectionShapeMoniker">
        <GeometryShapeMoniker Name="EntityCollectionShape" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityModelHasDomainEntities" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityModelHasDomainEntitiesMoniker" ElementName="domainEntityModelHasDomainEntities" MonikerTypeName="DomainEntityModelHasDomainEntitiesMoniker">
        <DomainRelationshipMoniker Name="DomainEntityModelHasDomainEntities" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityModelHasDomainEntityCollections" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityModelHasDomainEntityCollectionsMoniker" ElementName="domainEntityModelHasDomainEntityCollections" MonikerTypeName="DomainEntityModelHasDomainEntityCollectionsMoniker">
        <DomainRelationshipMoniker Name="DomainEntityModelHasDomainEntityCollections" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityReferencesTargetDomainEntities" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityReferencesTargetDomainEntitiesMoniker" ElementName="domainEntityReferencesTargetDomainEntities" MonikerTypeName="DomainEntityReferencesTargetDomainEntitiesMoniker">
        <DomainRelationshipMoniker Name="DomainEntityReferencesTargetDomainEntities" />
      </XmlClassData>
      <XmlClassData TypeName="DomainEntityReferencesDomainEntityCollections" MonikerAttributeName="" SerializeId="true" MonikerElementName="domainEntityReferencesDomainEntityCollectionsMoniker" ElementName="domainEntityReferencesDomainEntityCollections" MonikerTypeName="DomainEntityReferencesDomainEntityCollectionsMoniker">
        <DomainRelationshipMoniker Name="DomainEntityReferencesDomainEntityCollections" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="ElevenEntityModelExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="DomainEntityReferencesTargetDomainEntitiesBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainEntityReferencesTargetDomainEntities" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainEntity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainEntity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
    <ConnectionBuilder Name="DomainEntityReferencesDomainEntityCollectionsBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="DomainEntityReferencesDomainEntityCollections" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainEntity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="DomainEntityCollection" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="20178041-9c35-4dde-9e84-a01077d31666" Description="Description for Eleven.VS.Templates.Ado.Dsl.ElevenEntityModelDiagram" Name="ElevenEntityModelDiagram" DisplayName="Minimal Language Diagram" Namespace="Eleven.VS.Templates.Ado.Dsl" FillColor="206, 236, 245">
    <Class>
      <DomainClassMoniker Name="DomainEntityModel" />
    </Class>
    <ShapeMaps>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="DomainEntity" />
        <ParentElementPath>
          <DomainPath>DomainEntityModelHasDomainEntities.DomainEntityModel/!DomainEntityModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="EntityCompartmentShape/TextDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="DomainEntity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="EntityCompartmentShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="EntityCompartmentShape/PrimitiveProperties" />
          <ElementsDisplayed>
            <DomainPath>DomainEntityHasPrimitiveProperties.PrimitiveProperties/!PrimitiveProperty</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="PrimitiveProperty/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
        <CompartmentMap>
          <CompartmentMoniker Name="EntityCompartmentShape/EntityProperties" />
          <ElementsDisplayed>
            <DomainPath>DomainEntityHasDomainEntityProperties.DomainEntityProperties/!DomainEntityProperty</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="DomainEntityProperty/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
      <ShapeMap>
        <DomainClassMoniker Name="DomainEntityCollection" />
        <ParentElementPath>
          <DomainPath>DomainEntityModelHasDomainEntityCollections.DomainEntityModel/!DomainEntityModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="EntityCollectionShape/TextDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="DomainEntityCollection/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <GeometryShapeMoniker Name="EntityCollectionShape" />
      </ShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="EntityConnector" />
        <DomainRelationshipMoniker Name="DomainEntityReferencesTargetDomainEntities" />
      </ConnectorMap>
      <ConnectorMap>
        <ConnectorMoniker Name="EntityCollectionConector" />
        <DomainRelationshipMoniker Name="DomainEntityReferencesDomainEntityCollections" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="elevenentitymodel" EditorGuid="d0f144bd-1aac-4163-8875-48f048a358c3">
    <RootClass>
      <DomainClassMoniker Name="DomainEntityModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="ElevenEntityModelSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="Eleven Entity Model">
      <ElementTool Name="EntityTool" ToolboxIcon="Resources\Images\DomainEntity.bmp" Caption="Entity Shape" Tooltip="Create a entity shape" HelpKeyword="EntityShapeClassF1Keyword">
        <DomainClassMoniker Name="DomainEntity" />
      </ElementTool>
      <ConnectionTool Name="EntityConnectorTool" ToolboxIcon="Resources\Images\DomainEntityConnector.bmp" Caption="Entity Connector" Tooltip="Drag between entities" HelpKeyword="EntityConnectorClassF1Keyword">
        <ConnectionBuilderMoniker Name="ElevenEntityModel/DomainEntityReferencesTargetDomainEntitiesBuilder" />
      </ConnectionTool>
      <ConnectionTool Name="EntityCollectionConnectorTool" ToolboxIcon="Resources\Images\DomainEntityCollectionConnector.bmp" Caption="Entity Collection Connector" Tooltip="Drag between entity collection and entity" HelpKeyword="EntityCollectionConnectorClassF1Keyword">
        <ConnectionBuilderMoniker Name="ElevenEntityModel/DomainEntityReferencesDomainEntityCollectionsBuilder" />
      </ConnectionTool>
      <ElementTool Name="EntityCollectionTool" ToolboxIcon="Resources\Images\DomainEntityCollection.bmp" Caption="Entity Collection Shape" Tooltip="Create a entity collection shape" HelpKeyword="EntityCollectionShapeClassF1Keyword">
        <DomainClassMoniker Name="DomainEntityCollection" />
      </ElementTool>
    </ToolboxTab>
    <Validation UsesMenu="false" UsesOpen="false" UsesSave="false" UsesLoad="false" />
    <DiagramMoniker Name="ElevenEntityModelDiagram" />
  </Designer>
  <Explorer ExplorerGuid="7be6c107-ae92-4e8a-9537-618e4186d78c" Title="Eleven Entity Model Explorer">
    <ExplorerBehaviorMoniker Name="ElevenEntityModel/ElevenEntityModelExplorer" />
  </Explorer>
</Dsl>