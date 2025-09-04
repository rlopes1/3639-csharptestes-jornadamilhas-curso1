using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class OfertaViagemDesconto
{
    [Fact]

    public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
    {
        // arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(DateTime.Parse("2024-02-01"), DateTime.Parse("2024-2-5"));
        double precoOriginal = 100.0;
        double desconto = 20.0;
        double precoComDesconto = precoOriginal - desconto;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);



        // act
        oferta.Desconto = desconto;

        // assert
        Assert.Equal(precoComDesconto, oferta.Preco);

    }

    [Fact]

    public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
    {
        // arrange
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        Periodo periodo = new Periodo(DateTime.Parse("2024-02-01"), DateTime.Parse("2024-2-5"));
        double precoOriginal = 100.0;
        double desconto = 120.00;
        double precoComDesconto = 30;
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);



        // act
        oferta.Desconto = desconto;

        // assert
        Assert.Equal(precoComDesconto, oferta.Preco);

    }



}
