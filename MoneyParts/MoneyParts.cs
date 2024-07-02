namespace MoneyParts
{
    public class MoneyParts
    {

        private decimal[] cantidades = [0.05M, 0.1M, 0.2M, 0.5M, 1M, 2M, 5M, 10M, 20M, 50M, 100M, 200M];

        /// <summary>
        /// Recibe como parámetro una cadena con un monto en soles y devuelve todas las combinaciones posibles en un arreglo.
        /// </summary>
        /// <param name="montoEnSoles">Cadena de texto con un monto en soles</param>
        /// <returns>Arreglo de arreglos de todas las combinaciones posibles con las cantidades por defecto</returns>
        public decimal[][] Build(string montoEnSoles) {
            // convertir cadena a decimal
            var conversionExitosa = decimal.TryParse(montoEnSoles, out var monto);
            if (!conversionExitosa) throw new Exception("El monto de soles ingresado no es válido");

            // hallar las cantidades que sean menor o igual que el monto
            var cantidadesAUsar = cantidades.Where(c => c <= monto).ToList();

            List<List<decimal>> resultado = [];

            // crear combinaciones por cada de las cantidades a usar
            for (int i = 0; i < cantidadesAUsar.Count; i++)
            {
                var cantidad = cantidadesAUsar[i];
                var montoTotal = monto;

                // generamos las primera lista de cantidades
                var (listaDeCantidades, montoRestante) = GenerarListaDeCantidades(montoTotal, cantidad);

                // agregamos la lista de cantidades generadas
                resultado.Add(listaDeCantidades);

                // igualamos el monto total al resto
                montoTotal = montoRestante;

                // si el monto total se pudo completar con la lista de cantidades actual, continuamos con la siguiente cantidad a usar
                if (montoTotal <= 0.00M) continue;

                // si el monto total no se pudo completar, usaremos las cantidades menores buscando la adecuada para completarlo
                // almacenamos el index de la cantidad actual para recorrer todas las cantidades menores
                var cantidadIndex = i;
                
                while(cantidadIndex >= 0)
                {
                    // si el monto total llega a ser nulo, se romperá el loop
                    if (montoTotal <= 0.00M) break;

                    var cantidadMenor = cantidadesAUsar[cantidadIndex - 1];

                    // generamos lista de cantidades con la cantidad menor
                    var (listaDeCantidadesMenores, nuevoMontoRestante) = GenerarListaDeCantidades(montoTotal, cantidadMenor);

                    // agregamos las combinaciones generadas con la cantidad menor
                    resultado[i].AddRange(listaDeCantidadesMenores);

                    // igualamos el monto total al monto restante
                    montoTotal = nuevoMontoRestante;
                    
                    // reducimos el index para usar a una cantidad menor a la actual
                    cantidadIndex--;
                }
            }

            // convertir listas de resultado a array antes de retornarlo
            return resultado.Select((list) => list.ToArray()).ToArray();
        }


        /// <summary>
        /// Recibe como parámetro el monto total y la cantidad para hacer las combinaciones. Devuelve la lista de cantidades y el monto restante después de restar la cantidad total de la lista.
        /// </summary>
        /// <param name="montoTotal">El monto total para hacer la lista de cantidades</param>
        /// <param name="cantidad">El valor en soles de cada elemento dentro de la lista</param>
        /// <returns>Retorna la lista de cantidades realizadas y el monto restante después de restar la cantidad total de la lista.</returns>
        public (List<decimal> Combinaciones, decimal MontoRestante) GenerarListaDeCantidades(decimal montoTotal, decimal cantidad)
        {
            List<decimal> combinaciones = [];
            var montoRestante = montoTotal;

            while (montoRestante >= cantidad)
            {
                // restar la cantidad
                montoRestante -= cantidad;
                // agregar a la lista de combinaciones
                combinaciones.Add(cantidad);
            }

            return (combinaciones, montoRestante);
        }
    }
}
