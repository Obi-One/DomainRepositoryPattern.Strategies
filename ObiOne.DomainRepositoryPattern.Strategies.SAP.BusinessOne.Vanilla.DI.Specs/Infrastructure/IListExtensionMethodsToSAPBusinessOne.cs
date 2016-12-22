using System;
using System.Collections.Generic;
using System.Linq;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure{
    public static class IListExtensionMethodsToSAPBusinessOne{
        public static void FromPersistable<TDIEntity, TDIKey>(this IList<TDIEntity> aThis, dynamic aBobsList, Func<TDIEntity, bool> aCompareWith) where TDIEntity : VanillaDIEntity<TDIKey>
        {
            for (var lChildIndex = 0; lChildIndex < aBobsList.Count; lChildIndex++)
            {
                aBobsList.SetCurrentLine(lChildIndex);

                // VERIFICA SE NO OBJETO CORRENTE JÁ EXISTE O ENDEREÇO CORRENTE OU SE PRECISA SER ADICIONADO
                var lInstance = aThis.SingleOrDefault(aCompareWith);

                if (lInstance == null)
                {
                    lInstance = Activator.CreateInstance<TDIEntity>();
                    aThis.Add(lInstance);
                }

                lInstance.FromPersistable(aBobsList);
            }
        }

        public static void ToPersistable<TDIEntity, TDIKey>(this IList<TDIEntity> aThis, dynamic aBobsList, Func<TDIEntity, bool> aCompareWith) where TDIEntity : VanillaDIEntity<TDIKey>{
            var lFirstRowUpdated = false;

            var lEntityList = aThis.ToList();

            // ITERA PRA DELETAR OS REMOVIDOS E ATUALIZAR OS MODIFICADOS
            for (var lIndex = 0; lIndex < aBobsList.Count; lIndex++)
            {
                aBobsList.SetCurrentLine(lIndex);

                var lEntity = lEntityList.SingleOrDefault(aCompareWith);

                if (lEntity == null)
                {
                    // FOI REMOVIDO
                    if (aBobsList.GetType().GetMethod("Delete") != null) aBobsList.Delete();
                }
                else
                {
                    // AINDA EXISTE (PODE OU NAO TER SIDO ALTERADO)
                    lEntity.ToPersistable(aBobsList);
                    lFirstRowUpdated = true;
                    // REMOVE DA LISTA TEMPORARIA OS ENDERECOS JA PROCESSADOS
                    lEntityList.Remove(lEntity);
                }
            }

            // VER OS ADICIONADOS
            foreach (var lEntity in lEntityList){
                if (lFirstRowUpdated)
                {
                    aBobsList.Add();
                    aBobsList.SetCurrentLine(aBobsList.Count - 1);
                }

                lEntity.ToPersistable(aBobsList);
                lFirstRowUpdated = true;
            }
        }
    }
}