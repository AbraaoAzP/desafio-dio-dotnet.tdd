using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTest
{
    private CalculadoraImplementacao _calc;

    public CalculadoraTest()
    {
        _calc = new CalculadoraImplementacao();
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(4, 5, 9)]
    public void DeveSomar2NumerosERetornarOResultado(int num1, int num2, int resultado)
    {
        // Arrange
        // Act
        int resultadoCalculadora = _calc.Somar(num1, num2);

        // Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(10, 2, 8)]
    public void DeveSubtrair2NumerosERetornarOResultado(int num1, int num2, int resultado)
    {
        //Arrange

        //Act
        int resultadoCalculadora = _calc.Subtrair(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(10, 2, 20)]
    public void DeveMultiplicar2NumerosERetornarOResultado(int num1, int num2, int resultado)
    {
        //Arrange

        //Act
        int resultadoCalculadora = _calc.Multiplicar(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(20, 2, 10)]
    public void DeveDividir2NumerosERetornarOResultado(int num1, int num2, int resultado)
    {
        //Arrange

        //Act
        int resultadoCalculadora = _calc.Dividir(num1, num2);

        //Assert
        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDivisaoPorZero()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Dividir(3,0));
    }

    [Fact]
    public void TestarHistorico()
    {
        _calc.Somar(1, 2);
        _calc.Somar(2, 8);
        _calc.Somar(3, 7);
        _calc.Somar(4, 1);

        var lista = _calc.Historico();

        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}