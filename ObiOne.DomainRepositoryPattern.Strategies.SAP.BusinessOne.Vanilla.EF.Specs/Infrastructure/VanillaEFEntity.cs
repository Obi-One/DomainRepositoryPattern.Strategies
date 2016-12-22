using System.ComponentModel.DataAnnotations.Schema;
using ObiOne.DomainRepositoryPattern.Specialized.EF.Model;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF.Specs.Infrastructure
{
    public abstract class VanillaEFEntity<TVanillaEFKey> : EFEntity<TVanillaEFKey>
    {
        [NotMapped]
        public override TVanillaEFKey Id { get; set; }
    }
}
