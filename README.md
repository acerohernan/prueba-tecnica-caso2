# Evaluación Técnica – Developer .NET - Caso 02

## Indicaciones

Usando C#, crear una clase llamada MoneyParts que tenga un método llamado build que
reciba como parámetro una cadena con un monto en soles y devuelva todas las
combinaciones posibles en un arreglo.

Indicaciones

- Crear la solución en un solo archivo llamado MoneyParts.cs
- El método build devuelve la salida del algoritmo
- Considerar las siguientes denominaciones (0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200)

Ejemplos

- Entrada:"0.1" salida: [[0.05, 0.05],[0.1]]
- Entrada:"0.5" salida: [[0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,
0.05], …… [0.1, 0.1, 0.1, 0.1, 0.1]]
- Entrada:"10.50" salida: [[0.05, 0.05, …. 0.05], …… [10.0,0.5]]

Los puntos suspensivos representan todas las combinaciones posibles para representar la
cantidad monetaria ingresada.

Al finalizar debe entregarse:

- Código en .zip o GIT

## Solución

### Entregable

El código fuente de la clase 'MoneyParts' solicitado se encuentra [aquí](https://github.com/acerohernan/prueba-tecnica-parte2/blob/master/MoneyParts/MoneyParts.cs).

### Descripción
Para resolver el desafío se usó la metodología TDD, creando una librería de clase para el código fuente de la solución y un proyecto de XUnit para validar los casos propuestos en las indicaciones.  

### Dependencias 
No se usaron dependencias externas para el código fuente

### Tests
Los tests creados se encuentran [aquí](https://github.com/acerohernan/prueba-tecnica-parte2/blob/master/MoneyParts.Tests/MoneyPartsTests.cs).

#### Método 'MoneyParts.GenerarListaDeCantidades'

1. Generación de lista de cantidades exactas (sin resto). 

2. Generación de lista de cantidades inexactas (con resto).

#### Método 'MoneyParts.Build'

1. Entrada:"0.1" salida: [[0.05, 0.05],[0.1]]. 

2. Entrada:"0.5" salida: [[0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,5.05], …… [0.1, 0.1, 0.1, 0.1, 0.1]].

3. Entrada:"10.50" salida: [[0.05, 0.05, …. 0.05], …… [10.0,0.5]].
