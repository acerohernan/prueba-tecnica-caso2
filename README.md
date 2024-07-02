# Evaluaci�n T�cnica � Developer .NET - Parte 02

## Indicaciones

Usando C#, crear una clase llamada MoneyParts que tenga un m�todo llamado build que
reciba como par�metro una cadena con un monto en soles y devuelva todas las
combinaciones posibles en un arreglo.

Indicaciones

- Crear la soluci�n en un solo archivo llamado MoneyParts.cs
- El m�todo build devuelve la salida del algoritmo
- Considerar las siguientes denominaciones (0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200)

Ejemplos

- Entrada:"0.1" salida: [[0.05, 0.05],[0.1]]
- Entrada:"0.5" salida: [[0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,
0.05], �� [0.1, 0.1, 0.1, 0.1, 0.1]]
- Entrada:"10.50" salida: [[0.05, 0.05, �. 0.05], �� [10.0,0.5]]

Los puntos suspensivos representan todas las combinaciones posibles para representar la
cantidad monetaria ingresada.

Al finalizar debe entregarse:

- C�digo en .zip o GIT

## Soluci�n

### Entregable

El c�digo fuente de la clase 'MoneyParts' solicitado se encuentra [aqu�](https://github.com/acerohernan/prueba-tecnica-parte2/blob/master/MoneyParts/MoneyParts.cs).

### Descripci�n
Para resolver el desaf�o se us� la metodolog�a TDD, creando una librer�a de clase para el c�digo fuente de la soluci�n y un proyecto de XUnit para validar los casos propuestos en las indicaciones.  

### Dependencias 
No se usaron dependencias externas para el c�digo fuente

### Tests
Los tests creados se encuentran [aqu�](https://github.com/acerohernan/prueba-tecnica-parte2/blob/master/MoneyParts.Tests/MoneyPartsTests.cs).

#### M�todo 'MoneyParts.GenerarListaDeCantidades'

1. Generaci�n de lista de cantidades exactas (sin resto). 

2. Generaci�n de lista de cantidades inexactas (con resto). M�todo 'MoneyParts.GenerarListaDeCantidades'

#### M�todo 'MoneyParts.Build'

1. Entrada:"0.1" salida: [[0.05, 0.05],[0.1]]. 

2. Entrada:"0.5" salida: [[0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,
5.05], �� [0.1, 0.1, 0.1, 0.1, 0.1]]. M�todo 'MoneyParts.Build'

3. Entrada:"10.50" salida: [[0.05, 0.05, �. 0.05], �� [10.0,0.5]]. M�todo 'MoneyParts.Build'
