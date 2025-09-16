using Bogus;
using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class RotaConstrutor
{
    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData ("", null)]
    public void RetornaErroSeOrigemOuDestinoEhVazioOuNulo(string origem, string destino)
    {

        //Arrenge
        var fake = new Faker<Rota>().CustomInstantiator(f =>
        new Rota(origem, destino));


        //Act

        var rota = fake.Generate();



        //Assert

        Assert.False(rota.EhValido);
        Assert.Equal(2, rota.Erros.Count());
        

    }



}
