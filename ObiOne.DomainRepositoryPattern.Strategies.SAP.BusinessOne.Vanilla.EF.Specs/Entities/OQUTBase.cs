using System;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Entities
{
    public class OQUTBase : VanillaEFEntity<int>
    {
        public virtual int DocEntry { get; set; }
        public virtual string CardCode { get; set; }
        public virtual OCRDBase OCRDObj { get; set; }
        public virtual string NumAtCard { get; set; }
        public virtual DateTime DocDate { get; set; }
        public virtual DateTime DocDueDate { get; set; }
        public virtual decimal DocTotal { get; set; }
        public virtual string Comments { get; set; }
    }
}
