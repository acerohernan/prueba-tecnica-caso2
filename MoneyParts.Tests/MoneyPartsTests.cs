using FluentAssertions;

namespace MoneyParts.Tests
{
    public class MoneyPartsTests
    {
        private MoneyParts moneyParts = new MoneyParts();

        /// <summary>
        /// Generar lista de cantidades sin monto restante
        /// </summary>
        [Fact]
        public void Generar_Lista_De_Cantidades_Sin_Resto()
        {
            decimal montoTotal = 0.5M;
            decimal cantidad = 0.1M;
            List<decimal> listaDeCantidadesEsperada = [0.1M, 0.1M, 0.1M, 0.1M, 0.1M];

            var (listaDeCantidades, montoRestante) = moneyParts.GenerarListaDeCantidades(montoTotal, cantidad);

            listaDeCantidades.Should().BeEquivalentTo(listaDeCantidadesEsperada);
            montoRestante.Should().Be(0);
        }

        /// <summary>
        /// Generar lista de cantidades  con monto restante
        /// </summary>
        [Fact]
        public void Generar_Lista_De_Cantidades_Con_Resto()
        {
            decimal montoTotal = 10.5M;
            decimal cantidad = 10M;
            List<decimal> listaDeCantidadesEsperada = [10M];
            decimal montoRestanteEsperado = 0.5M;

            var (listaDeCantidades, montoRestante) = moneyParts.GenerarListaDeCantidades(montoTotal, cantidad);

            listaDeCantidades.Should().BeEquivalentTo(listaDeCantidadesEsperada);
            montoRestante.Should().Be(montoRestanteEsperado);
        }

        /// <summary>
        /// 1.  Entrada:"0.1" salida:[[0.05, 0.05],[0.1]]
        /// </summary>
        [Fact]
        public void Primer_Caso_Propuesto()
        {
            string entrada = "0.1";
            
            decimal[][] resultadoEsperado = [
                [0.05M, 0.05M],
                [0.1M]
            ];
                
            var result = moneyParts.Build(entrada);

            result.Should().BeEquivalentTo(resultadoEsperado);
        }

        /// <summary>
        /// 2.  Entrada:"0.5" salida:[[0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05, 0.05], …… [0.1, 0.1, 0.1, 0.1, 0.1]]
        /// </summary>
        [Fact]
        public void Segundo_Caso_Propuesto()
        {   
            string entrada = "0.5";

            decimal[][] resultadoEsperado = [
                Enumerable.Repeat(0.05M, 10).ToArray(),
                Enumerable.Repeat(0.1M, 5).ToArray(),
                [0.2M, 0.2M, 0.1M],
                [0.5M]
            ];

            var result = moneyParts.Build(entrada);

            result.Should().BeEquivalentTo(resultadoEsperado);
        }

        /// <summary>
        /// 3.  Entrada:"10.50" salida:[[0.05, 0.05, …. 0.05], …… [10.0,0.5]]
        /// </summary>
        [Fact]
        public void Tercer_Caso_Propuesto()
        {
            string entrada = "10.5";

            decimal[][] resultadoEsperado = [
                Enumerable.Repeat(0.05M, 210).ToArray(),
                Enumerable.Repeat(0.1M, 105).ToArray(),
                Enumerable.Repeat(0.2M, 52).Concat([0.1M]).ToArray(),
                Enumerable.Repeat(0.5M, 21).ToArray(),
                Enumerable.Repeat(1M, 10).Concat([0.5M]).ToArray(),
                Enumerable.Repeat(2M, 5).Concat([0.5M]).ToArray(),
                [5M, 5M, 0.5M],
                [10M, 0.5M]
            ];

            var result = moneyParts.Build(entrada);

            result.Should().BeEquivalentTo(resultadoEsperado);
        }
    }
}