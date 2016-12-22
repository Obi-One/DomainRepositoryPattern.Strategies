using System;
using System.Collections.Generic;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure{
    /// <summary>
    /// Class ContainerExtensions.
    /// </summary>
    public static class ContainerExtensions
    {
        ///// <summary>
        ///// Itera sobre todas as propriedades da entidade da aplicação (origem) para encontrar os campos de usuário (U_*) para preencher o GeneralData (destino).
        ///// </summary>
        ///// <typeparam name="TAppEntity">O tipo (classe) da entidade da aplicação a ser iterada para preencher o GeneralData (origem).</typeparam>
        ///// <param name="aGeneralData">O objeto da entidade da DI-API que será preenchido (destino).</param>
        ///// <param name="aAppEntity">O objeto da entidade da aplicação que possui os dados (origem).</param>
        ///// <exception cref="System.ArgumentNullException">Thrown if the aGeneralData or aAppEntity parameter is null.</exception>
        ///// <exception cref="TypeMismatchException">Condition. </exception>
        //public static void SetValues<TAppEntity>( this GeneralData aGeneralData,  TAppEntity aAppEntity)
        //{
        //    if (aGeneralData == null) throw new ArgumentNullException(nameof(aGeneralData));
        //    if (aAppEntity == null) throw new ArgumentNullException(nameof(aAppEntity));

        //    var lUserfieldList = typeof(TAppEntity).GetProperties().Where(aProp => aProp.Name.StartsWith("U_") && aProp.PropertyType.GetInterfaces().All(aType => aType != typeof(IEntity<>)));
        //    foreach (var lUserField in lUserfieldList)
        //    {
        //        var lNewValue = lUserField.GetValue(aAppEntity, null);
        //        var lOldValue = aGeneralData.GetProperty(lUserField.Name);
                
        //        var lOldValueType = Type.GetTypeCode(lOldValue.GetType());
        //        var lColumnType = Type.GetTypeCode(lUserField.PropertyType);

        //        if (lNewValue != null){
        //            var lValueType = Type.GetTypeCode(lNewValue.GetType());
        //            if (lColumnType != lValueType){
        //                throw new InvalidCastException($"The column {lUserField.Name} is of {lColumnType} type has current value [{lOldValue}] of {lOldValueType} type and don't accept value [{lNewValue}] of {lValueType} type.");
        //            }
        //        }

        //        // O preenchimento da propriedade deve ser feito de acordo com o tipo dela e somente se teve alteração no valor
        //        // O tipo da propriedade é definido na entidade explicitamente ou pelo tipo do valor antigo
        //        switch (lColumnType)
        //        {
        //            case TypeCode.Boolean:
        //                // As propriedades Boolean são salvas no banco como smallint pelo SDK
        //                var lInt16Value = Convert.ToInt16(lNewValue);
        //                var lOldInt16Value = Convert.ToInt16(lOldValue);

        //                if (lInt16Value != lOldInt16Value){
        //                    aGeneralData.SetProperty(lUserField.Name, lInt16Value);
        //                }
        //                break;
        //            case TypeCode.Int16:
        //                var lShortValue = (short) (lNewValue ?? 0);
        //                lNewValue = new DateTime();
        //                lNewValue = ((DateTime) lNewValue).AddHours(Convert.ToInt32(lShortValue/100));
        //                lNewValue = ((DateTime) lNewValue).AddMinutes(lShortValue - (Convert.ToInt32(lShortValue/100)*100));

        //                if (((DateTime) lNewValue).Hour != ((DateTime) lOldValue).Hour || ((DateTime) lNewValue).Minute != ((DateTime) lOldValue).Minute){
        //                    aGeneralData.SetProperty(lUserField.Name, lNewValue);
        //                }
        //                break;

        //            case TypeCode.String:
        //                var lStringValue = Convert.ToString(lNewValue);
        //                var lOldStringValue = Convert.ToString(lOldValue);

        //                if (lStringValue != lOldStringValue){
        //                    aGeneralData.SetProperty(lUserField.Name, lStringValue);
        //                }
        //                break;

        //            default:
        //                if ((lNewValue != null && !lNewValue.Equals(lOldValue)) || (lOldValue != null && !lOldValue.Equals(lNewValue))){
        //                    aGeneralData.SetProperty(lUserField.Name, lNewValue);
        //                }
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// Define o campo de usuário informado do container corrente (destino) para o valor informado (origem).
        /// </summary>
        /// <typeparam name="TContainer">O tipo (classe) da entidade da DI-API que será preenchido (destino).</typeparam>
        /// <typeparam name="TSharedProperty">O tipo (classe) da propriedade compartilhada (origem e destino tem que ser do mesmo tipo).</typeparam>
        /// <param name="aContainer">O objeto da entidade da DI-API que será preenchido (destino).</param>
        /// <param name="aUserFieldName">O nome do campo de usuário de destino.</param>
        /// <param name="aValue">O valor de origem a ser atribuido ao destino.</param>
        /// <exception cref="System.ArgumentNullException">aUserFieldName</exception>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void SetValue<TContainer, TSharedProperty>(this TContainer aContainer, string aUserFieldName, TSharedProperty aValue)
        {
            if (string.IsNullOrWhiteSpace(aUserFieldName)) throw new ArgumentNullException(nameof(aUserFieldName));

            Field lField;
            try
            {
                lField = ((dynamic)aContainer).UserFields.Fields.Item(aUserFieldName);
            } catch (Exception lException)
            {                
                throw new KeyNotFoundException($"Tentativa de alterar o campo de usuário [{aUserFieldName}] falhou! Este campo não foi encontrado na base de dados.", lException);
            }            

            switch (lField.Type)
            {
                case BoFieldTypes.db_Alpha:
                    switch (lField.SubType)
                    {
                        case BoFldSubTypes.st_None:
                        case BoFldSubTypes.st_Address:
                        case BoFldSubTypes.st_Phone:
                        case BoFldSubTypes.st_Image:
                            if (Convert.ToString(lField.Value) != Convert.ToString(aValue)) lField.Value = Convert.ToString(aValue);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case BoFieldTypes.db_Memo:
                    switch (lField.SubType)
                    {
                        case BoFldSubTypes.st_None:
                        case BoFldSubTypes.st_Link:
                            if (Convert.ToString(lField.Value) != Convert.ToString(aValue)) lField.Value = Convert.ToString(aValue);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case BoFieldTypes.db_Numeric:
                    switch (lField.SubType)
                    {
                        case BoFldSubTypes.st_None:
                            if (Convert.ToInt32(lField.Value) != Convert.ToInt32(aValue)) lField.Value = aValue;
                            break;
                        case BoFldSubTypes.st_Time:
                            if (((DateTime)Convert.ToDateTime(lField.Value)).ToB1Time() != Convert.ToInt16(aValue)) ((DateTime)Convert.ToDateTime(lField.Value)).MergeB1Time(Convert.ToInt16(aValue));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case BoFieldTypes.db_Date:
                    switch (lField.SubType)
                    {
                        case BoFldSubTypes.st_None:
                        case BoFldSubTypes.st_Time:
                            if (DateTime.Compare(Convert.ToDateTime(lField.Value), Convert.ToDateTime(aValue)) != 0) lField.Value = aValue;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case BoFieldTypes.db_Float:
                    switch (lField.SubType)
                    {
                        case BoFldSubTypes.st_Rate:
                        case BoFldSubTypes.st_Sum:
                        case BoFldSubTypes.st_Price:
                        case BoFldSubTypes.st_Quantity:
                        case BoFldSubTypes.st_Percentage:
                        case BoFldSubTypes.st_Measurement:
                            if (Convert.ToDouble(lField.Value) != Convert.ToDouble(aValue)) lField.Value = aValue;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        ///// <summary>
        ///// Define o valor da propriedade informada em aProperty da entidade aAppEntity (origem) para a propriedade HOMÔNIMA do GeneralData (destino).
        ///// </summary>
        ///// <typeparam name="TAppEntity">O tipo (classe) da entidade da aplicação que possui os dados (origem).</typeparam>
        ///// <typeparam name="TSharedProperty">O tipo (classe) da propriedade compartilhada (origem e destino tem que ser do mesmo tipo).</typeparam>
        ///// <param name="aGeneralData">O objeto da entidade da DI-API que será preenchido (destino).</param>
        ///// <param name="aAppEntity">O objeto da entidade da aplicação que possui os dados (origem).</param>
        ///// <param name="aAppEntityProperty">A propriedade de origem que possui o valor a ser atribuído ao destino.</param>
        ///// <exception cref="System.ArgumentNullException">Thrown if the aGeneralData or aProperty parameter is null.</exception>
        ///// <exception cref="System.NotSupportedException">
        ///// </exception>
        ///// <exception cref="System.NotImplementedException"></exception>
        ///// <exception cref="System.ArgumentException"></exception>
        //public static void SetValue<TAppEntity, TSharedProperty>([NotNull] this GeneralData aGeneralData, TAppEntity aAppEntity, [NotNull] Expression<Func<TAppEntity, TSharedProperty>> aAppEntityProperty)
        //{
        //    if (aGeneralData == null) throw new ArgumentNullException(nameof(aGeneralData));
        //    if (aAppEntityProperty == null) throw new ArgumentNullException(nameof(aAppEntityProperty));

        //    var lMemberSelectorExpression = aAppEntityProperty.Body as MemberExpression;
        //    if (lMemberSelectorExpression == null) throw new NotSupportedException();

        //    var lProperty = lMemberSelectorExpression.Member as PropertyInfo;
        //    if (lProperty == null) throw new NotSupportedException();

        //    var lNewValue = aAppEntityProperty.Compile().Invoke(aAppEntity);

        //    #region Enumeration Replace
        //    var lEnumProperties = new Dictionary<string, char[]>
        //    {
        //        {
        //            "Handwrtten", DIAPIEnums<BoYesNoEnum>()
        //        },
        //        {
        //            "Canceled", DIAPIEnums<BoYesNoEnum>()
        //        },
        //        {
        //            "Transfered", DIAPIEnums<BoYesNoEnum>()
        //        },
        //        {
        //            "Status", DIAPIEnums<BoStatus>()
        //        },
        //        {
        //            "DataSource", new[]
        //            {
        //                'I',
        //                'O',
        //                'P',
        //                'U',
        //                'M',
        //                'A',
        //                'D',
        //                'N'
        //            }
        //        }
        //    };

        //    if (lEnumProperties.ContainsKey(lProperty.Name))
        //    {
        //        var lEnumProperty = lEnumProperties[lProperty.Name];

        //        var lNewValueChar = Convert.ToChar(lNewValue);

        //        var lIndex = lEnumProperty.ToList().Contains(lNewValueChar) ? lEnumProperty.ToList().IndexOf(lNewValueChar) : Convert.ToInt16(lNewValue);

        //        lNewValue = (TSharedProperty)lEnumProperty.GetValue(lIndex);
        //    } 
        //    #endregion

        //    bool lIsChanged;
        //    if (lProperty.PropertyType.IsEnum)
        //    {
        //        if ((lProperty.PropertyType != lNewValue.GetType())) throw new NotSupportedException();
        //        lIsChanged = true;
        //    }
        //    else
        //    {
        //        var lCurrentValue = aGeneralData.GetProperty(lProperty.Name);
        //        switch (typeof(TSharedProperty).FullName)
        //        {
        //            case "System.Char":
        //                lIsChanged = (Convert.ToChar(lCurrentValue) != Convert.ToChar(lNewValue));
        //                break;
        //            case "System.String":
        //                lIsChanged = (Convert.ToString(lCurrentValue) != Convert.ToString(lNewValue));
        //                break;
        //            case "System.Int16":
        //                lIsChanged = (Math.Abs(Convert.ToInt16(lCurrentValue) - Convert.ToInt16(lNewValue)) > 0);
        //                break;
        //            case "System.Int32":
        //                lIsChanged = (Math.Abs(Convert.ToInt32(lCurrentValue) - Convert.ToInt32(lNewValue)) > 0);
        //                break;
        //            case "System.Int64":
        //                lIsChanged = (Math.Abs(Convert.ToInt64(lCurrentValue) - Convert.ToInt64(lNewValue)) > 0);
        //                break;
        //            case "System.Double":
        //                lIsChanged = (Math.Abs(Convert.ToDouble(lCurrentValue) - Convert.ToDouble(lNewValue)) > 0);
        //                break;
        //            case "System.DateTime":
        //                lIsChanged = (DateTime.Compare(Convert.ToDateTime(lCurrentValue), Convert.ToDateTime(lNewValue)) != 0);
        //                break;
        //            default:
        //                throw new NotImplementedException();
        //        }
        //    }

        //    if (lIsChanged)
        //    {
        //        if (!lProperty.CanWrite) throw new ArgumentException(string.Format("Tentativa de alterar a propriedade [{0}] na classe [{1}] inválida! Esta propriedade é SOMENTE LEITURA!", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));

        //        aGeneralData.SetProperty(lProperty.Name, lNewValue);
        //    }
        //}

        ///// <summary>
        ///// Gets commom DI-API enummerators.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns>System.Char[].</returns>
        //[NotNull]
        //private static char[] DIAPIEnums<T>()
        //{
        //    var lEnumFullName = typeof (T).FullName;
        //    switch (lEnumFullName)
        //    {
        //        case "SAPbobsCOM.BoYesNoEnum":
        //            return new[] {'N', 'Y'};
        //        case "SAPbobsCOM.BoPaymentTypeEnum":
        //            return new[] {'I', 'O'};
        //        case "SAPbobsCOM.BoCardTypes":
        //            return new[] {'C', 'S', 'L'};
        //        case "SAPbobsCOM.BoAddressType":
        //            return new[] {'S', 'B'};
        //        case "SAPbobsCOM.BoStatus":
        //            return new[] {'O', 'C', 'P', 'D'};
        //        case "SAPbobsCOM.PrintStatusEnum":
        //            return new[] { 'N', 'Y', 'A' };
        //        case "SAPbobsCOM.BoSvcCallPriorities":
        //            return new[] { 'L', 'M', 'H' };
        //        default:
        //            throw new InvalidEnumArgumentException(string.Format("SAPbobsCOM Enum [{0}] not mapped yet.", lEnumFullName));
        //    }
        //}

        ///// <summary>
        ///// Define o valor de uma propriedade (DI-API Enum) de destino baseado no seu valor (char).
        ///// <remarks>Este método ao definir o valor irá realizar a "tradução" do valor [enum char banco de dados] para o valor [enum int DI-API].</remarks>
        ///// </summary>
        ///// <typeparam name="TContainer">O tipo (classe) da entidade da DI-API que será preenchido (destino).</typeparam>
        ///// <typeparam name="TContainerProperty">O tipo (classe) da propriedade a ser preenchida (destino).</typeparam>
        ///// <typeparam name="TAppEntityProperty">O tipo (classe) da propriedade de origem que possui o valor a ser atribuído ao destino.</typeparam>
        ///// <param name="aContainer">O objeto da entidade da DI-API que será preenchido (destino).</param>
        ///// <param name="aContainerProperty">A propriedade a ser preenchida (destino).</param>
        ///// <param name="aValue">O valor de origem a ser atribuido ao destino.</param>
        ///// <exception cref="System.ArgumentNullException">Thrown if the aMemberLamda parameter is null.</exception>
        ///// <exception cref="System.ArgumentException">
        ///// TProperty must be an enumerated type
        ///// or
        ///// TProperty must be an enumerated type
        ///// </exception>
        //public static void SetEnVal<TContainer, TContainerProperty, TAppEntityProperty>(this TContainer aContainer, [NotNull] Expression<Func<TContainer, TContainerProperty>> aContainerProperty, TAppEntityProperty aValue)
        //    where TContainerProperty : struct, IComparable, IConvertible, IFormattable
        //    where TAppEntityProperty : struct, IComparable, IConvertible, IFormattable
        //{
        //    if (aContainerProperty == null)
        //        throw new ArgumentNullException(nameof(aContainerProperty));
        //    if (!typeof(TContainerProperty).IsEnum)
        //        throw new ArgumentException("TProperty must be an enumerated type");
        //    if (!typeof(TAppEntityProperty).IsEnum)
        //        throw new ArgumentException("TProperty must be an enumerated type");

        //    var lChar = Convert.ToChar(Convert.ChangeType(aValue, aValue.GetTypeCode()));
        //    //var lChar = Convert.ToChar(aValue);

        //    aContainer.SetValue(aContainerProperty, lChar.ToEnum<TContainerProperty>());
        //}

        ///// <summary>
        ///// Define a propriedade do container (destino) com o valor informado (origem). 
        ///// </summary>
        ///// <typeparam name="TContainer">O tipo (classe) do container de destino.</typeparam>
        ///// <typeparam name="TSharedProperty">O tipo (classe) da propriedade a ser preenchida (o mesma para origem e destino).</typeparam>
        ///// <param name="aContainer">O objeto container de destino.</param>
        ///// <param name="aContainerProperty">A propriedade de destino a ser atribuída.</param>
        ///// <param name="aValue">O valor de origem a ser atribuido ao destino.</param>
        ///// <exception cref="ArgumentException"></exception>
        ///// <exception cref="System.ArgumentNullException">Thrown if the aProperty parameter is null.</exception>
        ///// <exception cref="System.NotSupportedException"></exception>
        ///// <exception cref="NHibernate.PropertyNotFoundException"></exception>
        ///// <exception cref="System.ComponentModel.InvalidEnumArgumentException"></exception>
        ///// <exception cref="System.NotImplementedException">If the type of the property is not expected.</exception>
        ///// <exception cref="InvalidCastException"><paramref name="aContainerProperty" /> does not implement the <see cref="T:System.IConvertible" /> interface.-or-The conversion of <paramref name="aContainerProperty" /> to a <see cref="T:System.Char" /> is not supported. </exception>
        ///// <exception cref="OverflowException"><paramref name="aContainerProperty" /> is less than <see cref="F:System.Char.MinValue" /> or greater than <see cref="F:System.Char.MaxValue" />.</exception>
        ///// <exception cref="ArgumentOutOfRangeException"> typeof (TSharedProperty). </exception>
        //public static void SetValue<TContainer, TSharedProperty>(this TContainer aContainer, [NotNull] Expression<Func<TContainer, TSharedProperty>> aContainerProperty, TSharedProperty aValue)
        //{
        //    if (aContainerProperty == null) throw new ArgumentNullException(nameof(aContainerProperty));

        //    // BUSCA A PROPRIEDADE A SER ALTERADA
        //    var lUnaryExpression = aContainerProperty.Body as UnaryExpression;
        //    var lMemberSelectorExpression = (lUnaryExpression != null ? lUnaryExpression.Operand : aContainerProperty.Body) as MemberExpression;
        //    if (lMemberSelectorExpression == null) throw new NotSupportedException();

        //    //var lMember = (((MemberExpression)((UnaryExpression)aContainerProperty.Body).Operand).Member);
        //    //throw new ArgumentException(string.Format("Tentativa de alterar a propriedade [{0}] na classe [{1}] inválida! Esta propriedade é SOMENTE LEITURA!.", lMember.Name, lMember.DeclaringType != null ? lMember.DeclaringType.FullName : "Classe não encontrada!"));

        //    var lProperty = lMemberSelectorExpression.Member as PropertyInfo;
        //    if (lProperty == null) throw new PropertyNotFoundException(typeof (TContainer), lMemberSelectorExpression.Member.Name);

        //    //

        //    bool lIsChanged;
        //    var lCurrentValue = lProperty.GetValue(aContainer, null);
        //    if (lProperty.PropertyType.IsEnum){
        //        if ((lProperty.PropertyType != aValue.GetType()))
        //            throw new InvalidEnumArgumentException();
        //        lIsChanged = !lCurrentValue.Equals(aValue);
        //    } else{
        //        var lDataType = typeof (TSharedProperty);
        //        if (lDataType.IsGenericType && lDataType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            lDataType = Nullable.GetUnderlyingType(lDataType);
        //        }
        //        switch (Type.GetTypeCode(lDataType)){
        //            case TypeCode.Empty:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.Empty] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Object:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.Object] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.DBNull:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.DBNull] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Boolean:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.Boolean] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Char:
        //                lIsChanged = (Convert.ToChar(lCurrentValue) != Convert.ToChar(aValue));
        //                break;
        //            case TypeCode.SByte:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.SByte] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Byte:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.Byte] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Int16:
        //                lIsChanged = (Math.Abs(Convert.ToInt16(lCurrentValue) - Convert.ToInt16(aValue)) > 0);
        //                break;
        //            case TypeCode.UInt16:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.UInt16] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Int32:
        //                lIsChanged = (Math.Abs(Convert.ToInt32(lCurrentValue) - Convert.ToInt32(aValue)) > 0);
        //                break;
        //            case TypeCode.UInt32:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.UInt32] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Int64:
        //                lIsChanged = (Math.Abs(Convert.ToInt64(lCurrentValue) - Convert.ToInt64(aValue)) > 0);
        //                break;
        //            case TypeCode.UInt64:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.UInt64] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Single:
        //                throw new ArgumentException(string.Format("Propriedade [{0}] na classe [{1}] do tipo [TypeCode.Single] não implementada.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));
        //            case TypeCode.Double:
        //                lIsChanged = (Math.Abs(Convert.ToDouble(lCurrentValue) - Convert.ToDouble(aValue)) > 0);
        //                break;
        //            case TypeCode.Decimal:
        //                lIsChanged = (Math.Abs(Convert.ToDecimal(lCurrentValue) - Convert.ToDecimal(aValue)) > 0);
        //                break;
        //            case TypeCode.DateTime:
        //                lIsChanged = (DateTime.Compare(Convert.ToDateTime(lCurrentValue), Convert.ToDateTime(aValue)) != 0);
        //                break;
        //            case TypeCode.String:
        //                lIsChanged = (Convert.ToString(lCurrentValue) != Convert.ToString(aValue));
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException();
        //        }
        //    }

        //    if (lIsChanged)
        //    {
        //        if (!lProperty.CanWrite) throw new ArgumentException(string.Format("Tentativa de alterar a propriedade [{0}] na classe [{1}] inválida! Esta propriedade é SOMENTE LEITURA!.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!"));

        //        try {
        //            lProperty.SetValue(aContainer, aValue, null);
        //        } catch (Exception lException) {
        //            throw new ArgumentException(string.Format("Tentativa de alterar a propriedade [{0}] na classe [{1}] inválida! {2}.", lProperty.Name, lProperty.DeclaringType != null ? lProperty.DeclaringType.FullName : "Classe não encontrada!", lException.InnerException.Message));
        //        }
        //    }
        //}

        //private static T ToEnum<T>(this char aChar)
        //{
        //    var lT = default(T);
        //    var lDIAPIEnums = DIAPIEnums<T>();

        //    for (var lCharIndex = 0; lCharIndex < lDIAPIEnums.Count(); lCharIndex++)
        //    {
        //        if (aChar == lDIAPIEnums[lCharIndex])
        //        {
        //            lT = (T) Enum.Parse(typeof (T), lCharIndex.ToString(CultureInfo.InvariantCulture));
        //            break;
        //        }
        //    }

        //    return lT;
        //}
    }
}