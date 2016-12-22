using System;
using System.Globalization;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure{
    /// <summary>
    /// Extension Methods para conversão de tipo de dados.
    /// </summary>
    public static class DataTypeConverter
    {
        /// <summary>
        /// A partir de um campo DateTime? contendo a data e a hora (padrão C#)
        /// remover a hora e retornar apenas a parte da data (padrão B1)
        /// </summary>
        /// <param name="aMySelf">A my self.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        /// <remarks>O campo DateTime? original NÃO é alterado!</remarks>
        public static DateTime? ToB1Date(this DateTime? aMySelf)
        {
            DateTime? lDate;
            if (aMySelf.HasValue)
            {
                lDate = aMySelf.Value.Date;
            }
            else
            {
                lDate = null;
            }

            return lDate;
        }

        /// <summary>
        /// A partir de um campo DateTime contendo a data e a hora (padrão C#)
        /// remover a hora e retornar apenas a parte da data (padrão B1)
        /// </summary>
        /// <param name="aMySelf">A my self.</param>
        /// <returns>DateTime.</returns>
        /// <remarks>O campo DateTime original NÃO é alterado!</remarks>
        public static DateTime ToB1Date(this DateTime aMySelf)
        {
            var lDate = aMySelf.Date;

            return lDate;
        }

        /// <summary>
        /// A partir de um campo DateTime? contendo a data e a hora (padrão C#)
        /// remover a data e retornar apenas a parte da hora (padrão B1)
        /// </summary>
        /// <param name="aMySelf">A my self.</param>
        /// <returns>System.Int16.</returns>
        /// <remarks>O campo DateTime? original NÃO é alterado!</remarks>
        public static short ToB1Time(this DateTime? aMySelf)
        {
            var lTime = aMySelf?.ToB1Time() ?? 0;

            return lTime;
        }

        /// <summary>
        /// A partir de um campo DateTime contendo a data e a hora (padrão C#)
        /// remover a data e retornar apenas a parte da hora (padrão B1)
        /// </summary>
        /// <param name="aMySelf">A my self.</param>
        /// <returns>System.Int16.</returns>
        /// <remarks>O campo DateTime original NÃO é alterado!</remarks>
        public static short ToB1Time(this DateTime aMySelf)
        {
            var lHour = aMySelf.Hour;
            var lMinute = aMySelf.Minute;
            var lTime = ((lHour * 100) + lMinute);

            return (short)lTime;
        }

        /// <summary>
        /// A partir de um campo DateTime? contendo somente a data (padrão B1)
        /// mesclar a hora informada em um campo smallint (padrão B1)
        /// </summary>
        /// <param name="aMySelf">A my self.</param>
        /// <param name="aTime">A time.</param>
        /// <returns>System.Nullable&lt;DateTime&gt;.</returns>
        /// <remarks>O campo DateTime? original NÃO é alterado!</remarks>
        public static DateTime? MergeB1Time(this DateTime? aMySelf, int? aTime)
        {
            DateTime? lDateTime;
            if (aMySelf.HasValue)
            {
                lDateTime = aTime.HasValue
                                ? aMySelf.Value.MergeB1Time(aTime.Value)
                                : aMySelf.Value;
            }
            else
            {
                lDateTime = null;
            }

            return lDateTime;
        }

        /// <summary>
        /// A partir de um campo DateTime contendo somente a data (padrão B1)
        /// mesclar a hora informada em um campo smallint (padrão B1)
        /// </summary>
        /// <param name="aMySelf">A my self.</param>
        /// <param name="aTime">A time.</param>
        /// <returns>DateTime.</returns>
        /// <remarks>O campo DateTime original NÃO é alterado!</remarks>
        public static DateTime MergeB1Time(this DateTime aMySelf, int aTime)
        {
            var lDateTime = aMySelf.Date;

            switch (aTime.ToString(CultureInfo.InvariantCulture).Length)
            {
                case 3:
                case 4:
                    var lHoras = (aTime / 100);
                    lDateTime = lDateTime.AddHours(lHoras);
                    lDateTime = lDateTime.AddMinutes(aTime - (lHoras * 100));
                    break;
                case 5:
                case 6:
                    lHoras = (aTime / 10000);
                    lDateTime = lDateTime.AddHours(lHoras);
                    var lMinutos = ((aTime - (lHoras * 10000)) / 100);
                    lDateTime = lDateTime.AddMinutes(lMinutos);
                    lDateTime = lDateTime.AddSeconds(aTime - (lHoras * 10000) - (lMinutos * 100));
                    break;
            }

            return lDateTime;
        }
    }
}