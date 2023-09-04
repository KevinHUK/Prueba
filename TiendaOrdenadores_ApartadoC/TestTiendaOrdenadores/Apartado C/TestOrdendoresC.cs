using TiendaOrdenadores;
using TiendaOrdenadores.Componentes;
using TiendaOrdenadores.Factoria;
using TiendaOrdenadores.Factoria.Enumeradores;
using TiendaOrdenadores.Factoria.Interfaces;
using TiendaOrdenadores.Pedidos;

namespace TestTiendaOrdenadores.Apartado_C
{
    [TestClass]
    public class TestOrdendoresC
    {
        private readonly Ordenador _ordenadorMaria = new();
        private readonly Ordenador _ordenadorAndres = new();
        private readonly Ordenador _ordenadorTirburcioII = new();
        private readonly Ordenador _ordenadorAndresCF = new();
        private OrdenadorConAlmacenamientoPrimarioDecorator? _ordenadorTiburcioIICompleto;
        private OrdenadorConAlmacenamientoPrimarioDecorator? _ordenadorAndresCFCompleto;
        private readonly Pedido _pedidoA = new();
        private readonly Pedido _pedidoB = new();
        private readonly List<IComponente> _listaMemoriasExtraT = new();
        private readonly List<IComponente> _listaMemoriasExtraA = new();


        [TestInitialize]
        public void TestInitialize()
        {

            IComponenteFactoryMethod factoria = new FactoriaComponentes();



            var discoPrimarioT = factoria.DameComponente(TipoComponentes._789XX);
            var procesadorT = factoria.DameComponente(TipoComponentes._789XCS);
            var memoriaRam = factoria.DameComponente(TipoComponentes._879FH);
            var discoExt = factoria.DameComponente(TipoComponentes._1789XCS);
            var discoMecanico = factoria.DameComponente(TipoComponentes._788fg);

            if (discoPrimarioT != null && procesadorT != null && memoriaRam != null && discoExt != null && discoMecanico != null)
            {
                _ordenadorTirburcioII.Add(procesadorT);
                _ordenadorTirburcioII.Add(discoExt);
                _ordenadorTirburcioII.Add(memoriaRam);
                _listaMemoriasExtraT.Add(discoPrimarioT);
                _listaMemoriasExtraT.Add(discoMecanico);
            }




            var discoPrimarioA = factoria.DameComponente(TipoComponentes._788fg);
            var procesadorA = factoria.DameComponente(TipoComponentes._789XCS);
            var memoriaRamA = factoria.DameComponente(TipoComponentes._879FHT);
            var discoDuroA = factoria.DameComponente(TipoComponentes._789XX3);

            if (discoPrimarioA != null && procesadorA != null && memoriaRamA != null && discoDuroA != null)
            {
                _ordenadorAndresCF.Add(procesadorA);
                _ordenadorAndresCF.Add(memoriaRamA);
                _ordenadorAndresCF.Add(discoDuroA);
                _listaMemoriasExtraA.Add(discoPrimarioA);
            }





            var discoM = factoria.DameComponente(TipoComponentes._789XX);
            var procesadorM = factoria.DameComponente(TipoComponentes._789XCS);
            var memoriaM = factoria.DameComponente(TipoComponentes._879FH);

            if (discoM != null && procesadorM != null && memoriaM != null)
            {
                _ordenadorMaria.Add(discoM);
                _ordenadorMaria.Add(procesadorM);
                _ordenadorMaria.Add(memoriaM);
            }






            var disco = factoria.DameComponente(TipoComponentes._879FHT);
            var procesador = factoria.DameComponente(TipoComponentes._789XX3);
            var memoria = factoria.DameComponente(TipoComponentes._797X3);

            if (disco != null && procesador != null && memoria != null)
            {
                _ordenadorAndres.Add(disco);
                _ordenadorAndres.Add(procesador);
                _ordenadorAndres.Add(memoria);
            }


            _pedidoA.AddPedido(_ordenadorMaria);
            _pedidoA.AddPedido(_ordenadorAndres);

            _ordenadorTiburcioIICompleto = new(_ordenadorTirburcioII, _listaMemoriasExtraT);
            _ordenadorAndresCFCompleto = new(_ordenadorAndresCF, _listaMemoriasExtraA);

            _pedidoB.AddPedido(_ordenadorTiburcioIICompleto);
            _pedidoB.AddPedido(_ordenadorAndresCFCompleto);



        }

        [TestMethod]
        public void TestPedidoA()
        {
            Assert.IsNotNull(_pedidoA);
            Assert.AreEqual(153, _pedidoA.CalorTotalPedido());
            Assert.AreEqual(840, _pedidoA.PrecioTotalPedido());

        }


        [TestMethod]
        public void TestPedidoB()
        {

            Assert.IsNotNull(_pedidoB);
            Assert.AreEqual(183, _pedidoB.CalorTotalPedido());
            Assert.AreEqual(904, _pedidoB.PrecioTotalPedido());
        }


    }
}