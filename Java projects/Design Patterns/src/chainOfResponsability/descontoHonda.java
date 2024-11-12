package chainOfResponsability;

import java.math.BigDecimal;

public class descontoHonda extends descontoCarro {

    public descontoHonda(descontoCarro proximo) {
        super(proximo);
    }

    @Override
    public BigDecimal desconta(carro carro) {
        if (TipoCarro.HONDA.equals(carro.getTipo())){
            return carro.getValor().add(new BigDecimal(-5500));
        }
        return proximo.desconta(carro);
    }

}
