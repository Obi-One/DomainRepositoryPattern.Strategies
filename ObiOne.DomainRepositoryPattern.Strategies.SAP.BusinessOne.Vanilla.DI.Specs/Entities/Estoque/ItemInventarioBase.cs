using ObiOne.DomainRepositoryPattern.Specialized.DI.Model;
using ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Infrastructure;
using SAPbobsCOM;

namespace ObiOne.DomainRepositoryPattern.Strategies.SAP.BusinessOne.Vanilla.DI.Specs.Entities.Estoque{
    public class ItemInventarioBase : VanillaDIEntity<string>{
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public ItemInventarioBase(){
            Series = 1; // 1 = MANUAL (NATIVO)
            Ativo = true;
        }

        public ItemInventarioBase(string aCodigoSAP, string aNome) : this(){
            Id = aCodigoSAP;
            Nome = aNome;
        }

        public ItemInventarioBase(int aSeries, string aNome) : this(){
            Series = aSeries; // PASSANDO UMA SÉRIE O SAP DETERMINA O ITEMCODE
            Nome = aNome;
        }

        //public string CodigoSAP { get; set; }
        public string Nome { get; set; }
        public int Series { get; set; }
        public bool Ativo { get; set; }
        public string Observacoes { get; set; }
        public string CodigoBarras { get; set; }
        public EnClassificacaoItem ClassificacaoItem { get; set; }
        public bool ItemEstoque { get; set; }
        public bool ItemVenda { get; set; }
        public bool ItemCompra { get; set; }
        public string ImagemFilename { get; set; }
        public string UnidedadeMedidaEmbalagem { get; set; }
        public string UnidadeMedidaVenda { get; set; }
        public int CodigoServicoPrestado { get; set; }

        public override DIEntity<string> FromPersistable(dynamic aBusinessObject){
            var lItems = (Items) aBusinessObject;

            Series = lItems.Series;
            Id = lItems.ItemCode;
            Nome = lItems.ItemName;
            CodigoBarras = lItems.BarCode;
            Ativo = lItems.Valid == BoYesNoEnum.tYES;
            ItemEstoque = lItems.InventoryItem == BoYesNoEnum.tYES;
            ItemVenda = lItems.SalesItem == BoYesNoEnum.tYES;
            ItemCompra = lItems.PurchaseItem == BoYesNoEnum.tYES;
            ImagemFilename = lItems.Picture;
            ClassificacaoItem = (EnClassificacaoItem) lItems.ItemClass;
            UnidadeMedidaVenda = lItems.SalesUnit;
            UnidedadeMedidaEmbalagem = lItems.SalesPackagingUnit;
            CodigoServicoPrestado = lItems.OutgoingServiceCode;
            Observacoes = lItems.User_Text;

            return this;
        }

        public override dynamic ToPersistable(dynamic aBusinessObject){
            var lItems = (Items) aBusinessObject;

            lItems.Series = Series;
            lItems.ItemCode = Id;
            lItems.ItemName = Nome;
            lItems.BarCode = CodigoBarras;
            lItems.Valid = Ativo ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            lItems.InventoryItem = ItemEstoque ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            lItems.SalesItem = ItemVenda ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            lItems.PurchaseItem = ItemCompra ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            lItems.Picture = ImagemFilename;
            lItems.ItemClass = (ItemClassEnum) ClassificacaoItem;
            lItems.SalesUnit = UnidadeMedidaVenda;
            lItems.SalesPackagingUnit = UnidedadeMedidaEmbalagem;
            lItems.OutgoingServiceCode = CodigoServicoPrestado;
            lItems.User_Text = Observacoes;

            return lItems;
        }
    }
}
