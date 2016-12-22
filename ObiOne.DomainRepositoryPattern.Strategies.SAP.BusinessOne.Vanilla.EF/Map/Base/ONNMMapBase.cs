using System.Data.Entity.ModelConfiguration;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Map.Base
{
    public class ONNMMapBase<T> : EntityTypeConfiguration<T> where T : ONNMBase
    {
        public ONNMMapBase()
        {
            ToTable("ONNM");

            HasKey(aONNM => new { aONNM.ObjectCode, aONNM.DocSubType });
        }
    }
}
