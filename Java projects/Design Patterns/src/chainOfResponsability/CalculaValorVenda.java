package chainOfResponsability;

import java.math.BigDecimal;

public class CalculaValorVenda {

    public BigDecimal calculaValorVenda(carro carro){
       descontoCarro desconto = new descontoFIAT(new descontoCarro100K(new nenhumDescontoCarro(null)));

       return desconto.desconta(carro);
    }
}
