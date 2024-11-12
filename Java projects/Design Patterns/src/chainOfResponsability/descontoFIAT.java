package chainOfResponsability;

import java.math.BigDecimal;



public class descontoFIAT extends descontoCarro {


    public descontoFIAT(descontoCarro proximo) {
        super(proximo);
    }

    @Override
    public BigDecimal desconta(carro carro) {
        if (TipoCarro.FIAT.equals(carro.getTipo())){
            return carro.getValor().add(new BigDecimal(-20000));
        }
        return proximo.desconta(carro);
    }
}
