using System;
using ObiOne.DomainRepositoryPattern.Specialized.EF.DataContext;
using ObiOne.DomainRepositoryPattern.Specialized.EF.Model;
using ObiOne.DomainRepositoryPattern.Specialized.EF.Repository;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.EF{
    public abstract class VanillaEFRepository<TVanillaEFEntity, TVanillaEFKey> : EFRepository<TVanillaEFEntity, TVanillaEFKey> where TVanillaEFEntity : EFEntity<TVanillaEFKey>{
        protected VanillaEFRepository(EFContext aEFContext) : base(aEFContext){
        }

        public override TVanillaEFEntity Insert(TVanillaEFEntity aEntity){
            throw new NotSupportedException();
        }

        public override TVanillaEFEntity Update(TVanillaEFEntity aEntity){
            throw new NotSupportedException();
        }

        public override void Delete(TVanillaEFKey aID){
            throw new NotSupportedException();
        }
    }
}
