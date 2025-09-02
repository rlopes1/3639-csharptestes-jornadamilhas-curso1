using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutor
{
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-2-5", 100, true)]
    [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
    [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
    [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]
    public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {

        //cenário - arrange
        Rota rota = new Rota(origem, destino);
        Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

        //ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);


        //validação - assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQUandoRotaNula()
    {

        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;
        

        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);

        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void TestandoOfertaComPeriodoErrado()
    {

        Rota rota = null;
        Periodo periodo = new Periodo(new DateTime(2025, 2, 1), new DateTime(2025, 1, 5));
        double preco = 100.0;


        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);

        Assert.False(oferta.EhValido);
    }

    [Theory]
    [InlineData("Origem1", "Destino1", "2025-2-1", "2025-2-5", -250)]
    [InlineData("Origem1", "Destino1", "2025-2-1", "2025-2-5", 0)]
    public void RetornaMensagemDeErroDePreçoInvalidoQuandoPrecoMenorQueZero(string origem, string destino, string dataInicio, string dataFim, double preco)
    {
        //cenário - arrange
        Rota rota = new Rota(origem, destino);

        Periodo periodo = new Periodo(DateTime.Parse(dataInicio), DateTime.Parse(dataFim));


        //act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

        //asert
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);

    }





}