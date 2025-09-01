using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemTest
{
    [Fact]
    public void TestandoOfertaValida()
    {

        //cenário - arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;
        var validacao = true;

        //ação - act
        OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);


        //validação - assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void TestandoOfertaComRotaNulta()
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





}