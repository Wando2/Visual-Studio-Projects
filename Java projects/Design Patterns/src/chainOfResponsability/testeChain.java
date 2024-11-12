package chainOfResponsability;

import java.math.BigDecimal;

public class testeChain {
    public static void main(String[] args) {
        CalculaValorVenda calculador = new CalculaValorVenda();

        carro carro = new carro(new BigDecimal(110000), TipoCarro.FIAT);
        System.out.println(calculador.calculaValorVenda(carro));

        carro carro2 = new carro(new BigDecimal(50000), TipoCarro.HONDA);
        System.out.println(calculador.calculaValorVenda(carro2));

        carro carro3 = new carro(new BigDecimal(310000), TipoCarro.CHERY);
        System.out.println(calculador.calculaValorVenda(carro3));

    }
}
