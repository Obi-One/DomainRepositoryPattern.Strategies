using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities{
    public class ONNMBase : VanillaEFEntity<string>{
        public ONNMBase(){
        }

        public virtual string ObjectCode { get; set; }
        public virtual string DocSubType { get; set; }
        public virtual short DfltSeries { get; set; }
    }
}
